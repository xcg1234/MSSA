using System.Text.Json;
using StravaWinForm.Models;

namespace StravaWinForm.Services
{
    public class StravaApiService
    {
        private readonly StravaAuthService _authService;

        public StravaApiService(StravaAuthService authService)
        {
            _authService = authService;
        }

        public async Task<List<StravaActivity>> GetActivitiesAsync(int count = 5)
        {
            var accessToken = await _authService.GetValidAccessTokenAsync();

            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("No valid access token. Please authorize first.");
            }

            
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync($"https://www.strava.com/api/v3/athlete/activities?per_page={count}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var activities = JsonSerializer.Deserialize<List<StravaActivity>>(json);
                return activities ?? new List<StravaActivity>();
            }

            throw new Exception($"Failed to fetch activities: {response.StatusCode}");
        }

        public async Task<Dictionary<string, YearlyStats>> GetYearlyComparisonAsync()
        {
            var accessToken = await _authService.GetValidAccessTokenAsync();

            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("No valid access token. Please authorize first.");
            }

            var currentYear = DateTime.Now.Year;
            var lastYear = currentYear - 1;

            var result = new Dictionary<string, YearlyStats>
            {
                { currentYear.ToString(), new YearlyStats() },
                { lastYear.ToString(), new YearlyStats() }
            };

            // Fetch activities for current year
            await FetchYearActivities(accessToken, currentYear, result[currentYear.ToString()]);

            // Fetch activities for last year
            await FetchYearActivities(accessToken, lastYear, result[lastYear.ToString()]);

            return result;
        }

        public async Task<PersonalRecords> GetPersonalRecordsAsync()
        {
            var accessToken = await _authService.GetValidAccessTokenAsync();

            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("No valid access token. Please authorize first.");
            }

            var allActivities = await FetchAllActivities(accessToken);

            var records = new PersonalRecords();

            // Find longest run
            var longestRun = allActivities.Where(a => a.type == "Run").OrderByDescending(a => a.distance).FirstOrDefault();
            if (longestRun != null)
            {
                records.LongestRun = new ActivityRecord
                {
                    Name = longestRun.name,
                    Date = longestRun.start_date_local,
                    Value = $"{(longestRun.distance * 0.000621371):F2} mi",
                    Type = "Run",
                    Duration = longestRun.Duration
                };
            }

            // Find fastest run pace (lowest minutes per mile)
            var fastestRun = allActivities
                .Where(a => a.type == "Run" && a.distance > 1609) // At least 1 mile
                .OrderByDescending(a => a.average_speed)
                .FirstOrDefault();
            if (fastestRun != null)
            {
                records.FastestRunPace = new ActivityRecord
                {
                    Name = fastestRun.name,
                    Date = fastestRun.start_date_local,
                    Value = fastestRun.PacePerMile,
                    Type = "Run",
                    Duration = fastestRun.Duration
                };
            }

            // Find longest ride
            var longestRide = allActivities.Where(a => a.type == "Ride").OrderByDescending(a => a.distance).FirstOrDefault();
            if (longestRide != null)
            {
                records.LongestRide = new ActivityRecord
                {
                    Name = longestRide.name,
                    Date = longestRide.start_date_local,
                    Value = $"{(longestRide.distance * 0.000621371):F2} mi",
                    Type = "Ride",
                    Duration = longestRide.Duration
                };
            }

            // Find fastest ride (highest average speed)
            var fastestRide = allActivities
                .Where(a => a.type == "Ride" && a.distance > 1609)
                .OrderByDescending(a => a.average_speed)
                .FirstOrDefault();
            if (fastestRide != null)
            {
                records.FastestRide = new ActivityRecord
                {
                    Name = fastestRide.name,
                    Date = fastestRide.start_date_local,
                    Value = $"{(fastestRide.average_speed * 2.23694):F2} mph",
                    Type = "Ride",
                    Duration = fastestRide.Duration
                };
            }

            // Find most elevation gain
            var mostElevation = allActivities.OrderByDescending(a => a.total_elevation_gain).FirstOrDefault();
            if (mostElevation != null)
            {
                records.MostElevationGain = new ActivityRecord
                {
                    Name = mostElevation.name,
                    Date = mostElevation.start_date_local,
                    Value = $"{(mostElevation.total_elevation_gain * 3.28084):F0} ft",
                    Type = mostElevation.type,
                    Duration = mostElevation.Duration
                };
            }

            return records;
        }

        private async Task<List<StravaActivity>> FetchAllActivities(string accessToken)
        {
            var allActivities = new List<StravaActivity>();
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            int page = 1;
            bool hasMorePages = true;

            while (hasMorePages)
            {
                var url = $"https://www.strava.com/api/v3/athlete/activities?per_page=200&page={page}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var activities = JsonSerializer.Deserialize<List<StravaActivity>>(json);

                    if (activities == null || activities.Count == 0)
                    {
                        hasMorePages = false;
                    }
                    else
                    {
                        allActivities.AddRange(activities);
                        page++;
                    }
                }
                else
                {
                    hasMorePages = false;
                }
            }

            return allActivities;
        }

        private async Task FetchYearActivities(string accessToken, int year, YearlyStats stats)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var startDate = new DateTime(year, 1, 1);
            var endDate = new DateTime(year, 12, 31, 23, 59, 59);

            long afterTimestamp = ((DateTimeOffset)startDate).ToUnixTimeSeconds();
            long beforeTimestamp = ((DateTimeOffset)endDate).ToUnixTimeSeconds();

            int page = 1;
            bool hasMorePages = true;

            while (hasMorePages)
            {
                var url = $"https://www.strava.com/api/v3/athlete/activities?after={afterTimestamp}&before={beforeTimestamp}&per_page=200&page={page}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var activities = JsonSerializer.Deserialize<List<StravaActivity>>(json);

                    if (activities == null || activities.Count == 0)
                    {
                        hasMorePages = false;
                    }
                    else
                    {
                        foreach (var activity in activities)
                        {
                            double miles = activity.distance * 0.000621371;

                            if (activity.type == "Run")
                            {
                                stats.RunMiles += miles;
                                stats.RunCount++;
                            }
                            else if (activity.type == "Ride")
                            {
                                stats.BikeMiles += miles;
                                stats.BikeCount++;
                            }
                        }

                        page++;
                    }
                }
                else
                {
                    hasMorePages = false;
                }
            }
        }
    }

    public class YearlyStats
    {
        public double RunMiles { get; set; }
        public int RunCount { get; set; }
        public double BikeMiles { get; set; }
        public int BikeCount { get; set; }
    }
}
