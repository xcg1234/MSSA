using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using StravaWebAPI.Models;

namespace StravaWebAPI.Services
{
    public class StravaApiService(
        IStravaAuthService authService, 
        IHttpClientFactory httpClientFactory,
        IWebHostEnvironment env) : IStravaApiService
    {
        private readonly IStravaAuthService _authService = authService;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly string _recordsFilePath = Path.Combine(env.ContentRootPath, "personal_records_cache.json");

        public async Task<List<StravaActivity>> GetActivitiesAsync(int count = 5)
        {
            var accessToken = await _authService.GetValidAccessTokenAsync();
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new InvalidOperationException("No valid access token. Please authorize first.");
            }

            using var client = CreateAuthorizedClient(accessToken);
            var response = await client.GetAsync($"https://www.strava.com/api/v3/athlete/activities?per_page={count}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch activities: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<StravaActivity>>(json) ?? [];
        }

        //fetech the last year and this year's activities in parallel
        //and return a dictionary with the results for easy comparison in the UI
        public async Task<Dictionary<string, YearlyStats>> GetYearlyComparisonAsync()
        {
            var accessToken = await _authService.GetValidAccessTokenAsync();
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new InvalidOperationException("No valid access token. Please authorize first.");
            }

            var currentYear = DateTime.Now.Year;
            var lastYear = currentYear - 1;
            var currentYearKey = currentYear.ToString();
            var lastYearKey = lastYear.ToString();

            var result = new Dictionary<string, YearlyStats>
            {
                [currentYearKey] = new YearlyStats(),
                [lastYearKey] = new YearlyStats()
            };

            var currentYearTask = FetchYearActivities(accessToken, currentYear, result[currentYearKey]);
            var lastYearTask = FetchYearActivities(accessToken, lastYear, result[lastYearKey]);

            await Task.WhenAll(currentYearTask, lastYearTask);

            return result;
        }

        public async Task<PersonalRecords> GetPersonalRecordsAsync()
        {
            var accessToken = await _authService.GetValidAccessTokenAsync();
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new InvalidOperationException("No valid access token. Please authorize first.");
            }

            var cache = await LoadRecordsCacheAsync() ?? new PersonalRecordsCache();

            List<StravaActivity> newActivities;

            if (cache.LastSyncTimestamp == 0)
            {
                // First run: fetch everything
                newActivities = await FetchAllActivities(accessToken);
            }
            else
            {
                // Subsequent runs: fetch only new activities since last sync
                newActivities = await FetchActivitiesAfterAsync(accessToken, cache.LastSyncTimestamp);
            }

            if (newActivities.Count > 0)
            {
                UpdateRecords(cache, newActivities);

                var latestActivityTimestamp = newActivities
                    .Max(activity => new DateTimeOffset(activity.start_date).ToUnixTimeSeconds());

                cache.LastSyncTimestamp = Math.Max(cache.LastSyncTimestamp, latestActivityTimestamp);
                await SaveRecordsCacheAsync(cache);
            }
            else if (cache.LastSyncTimestamp == 0)
            {
                cache.LastSyncTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                await SaveRecordsCacheAsync(cache);
            }

            return cache.Records;
        }

        private void UpdateRecords(PersonalRecordsCache cache, List<StravaActivity> activities)
        {
            var longestRun = activities.Where(a => a.type == "Run").OrderByDescending(a => a.distance).FirstOrDefault();
            if (longestRun != null && longestRun.distance > cache.LongestRunDistance)
            {
                cache.LongestRunDistance = longestRun.distance;
                cache.Records.LongestRun = new ActivityRecord
                {
                    Name = longestRun.name,
                    Date = longestRun.start_date_local,
                    Value = $"{(longestRun.distance * 0.000621371):F2} mi",
                    Type = "Run",
                    Duration = longestRun.Duration
                };
            }

            var fastestRun = activities
                .Where(a => a.type == "Run" && a.distance > 1609)
                .OrderByDescending(a => a.average_speed)
                .FirstOrDefault();
            if (fastestRun != null && fastestRun.average_speed > cache.FastestRunSpeed)
            {
                cache.FastestRunSpeed = fastestRun.average_speed ?? 0;
                cache.Records.FastestRunPace = new ActivityRecord
                {
                    Name = fastestRun.name,
                    Date = fastestRun.start_date_local,
                    Value = fastestRun.PacePerMile,
                    Type = "Run",
                    Duration = fastestRun.Duration
                };
            }

            var longestRide = activities.Where(a => a.type == "Ride").OrderByDescending(a => a.distance).FirstOrDefault();
            if (longestRide != null && longestRide.distance > cache.LongestRideDistance)
            {
                cache.LongestRideDistance = longestRide.distance;
                cache.Records.LongestRide = new ActivityRecord
                {
                    Name = longestRide.name,
                    Date = longestRide.start_date_local,
                    Value = $"{(longestRide.distance * 0.000621371):F2} mi",
                    Type = "Ride",
                    Duration = longestRide.Duration
                };
            }

            var fastestRide = activities
                .Where(a => a.type == "Ride" && a.distance > 1609)
                .OrderByDescending(a => a.average_speed)
                .FirstOrDefault();
            if (fastestRide != null && fastestRide.average_speed > cache.FastestRideSpeed)
            {
                cache.FastestRideSpeed = fastestRide.average_speed ?? 0;
                cache.Records.FastestRide = new ActivityRecord
                {
                    Name = fastestRide.name,
                    Date = fastestRide.start_date_local,
                    Value = $"{(fastestRide.average_speed * 2.23694):F2} mph",
                    Type = "Ride",
                    Duration = fastestRide.Duration
                };
            }

            var mostElevation = activities.OrderByDescending(a => a.total_elevation_gain).FirstOrDefault();
            if (mostElevation != null && mostElevation.total_elevation_gain > cache.MostElevationGain)
            {
                cache.MostElevationGain = mostElevation.total_elevation_gain;
                cache.Records.MostElevationGain = new ActivityRecord
                {
                    Name = mostElevation.name,
                    Date = mostElevation.start_date_local,
                    Value = $"{(mostElevation.total_elevation_gain * 3.28084):F0} ft",
                    Type = mostElevation.type,
                    Duration = mostElevation.Duration
                };
            }
        }

        private async Task<List<StravaActivity>> FetchAllActivities(string accessToken)
        {
            var allActivities = new List<StravaActivity>();
            using var client = CreateAuthorizedClient(accessToken);

            int page = 1;
            bool hasMorePages = true;

            while (hasMorePages)
            {
                var url = $"https://www.strava.com/api/v3/athlete/activities?per_page=200&page={page}";
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    break;
                }

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

            return allActivities;
        }

        private async Task<List<StravaActivity>> FetchActivitiesAfterAsync(string accessToken, long afterTimestamp)
        {
            var newActivities = new List<StravaActivity>();
            using var client = CreateAuthorizedClient(accessToken);

            int page = 1;
            bool hasMorePages = true;

            while (hasMorePages)
            {
                var url = $"https://www.strava.com/api/v3/athlete/activities?after={afterTimestamp}&per_page=200&page={page}";
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    break;
                }

                var json = await response.Content.ReadAsStringAsync();
                var activities = JsonSerializer.Deserialize<List<StravaActivity>>(json);

                if (activities == null || activities.Count == 0)
                {
                    hasMorePages = false;
                }
                else
                {
                    newActivities.AddRange(activities);
                    page++;
                }
            }

            return newActivities;
        }

        private async Task FetchYearActivities(string accessToken, int year, YearlyStats stats)
        {
            using var client = CreateAuthorizedClient(accessToken);

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

                if (!response.IsSuccessStatusCode)
                {
                    break;
                }

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
        }

        private HttpClient CreateAuthorizedClient(string accessToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return client;
        }
        
        private async Task<PersonalRecordsCache?> LoadRecordsCacheAsync()
        {
            if (!File.Exists(_recordsFilePath))
            {
                return null;
            }

            try
            {
                var json = await File.ReadAllTextAsync(_recordsFilePath);
                return JsonSerializer.Deserialize<PersonalRecordsCache>(json);
            }
            catch
            {
                return null;
            }
        }

        private async Task SaveRecordsCacheAsync(PersonalRecordsCache cache)
        {
            var json = JsonSerializer.Serialize(cache);
            await File.WriteAllTextAsync(_recordsFilePath, json);
        }

        private class PersonalRecordsCache
        {
            public PersonalRecords Records { get; set; } = new();
            public long LastSyncTimestamp { get; set; }
            
            // Raw internal values so that subsequent updates don't have to parse display strings.
            public double LongestRunDistance { get; set; }
            public double FastestRunSpeed { get; set; }
            public double LongestRideDistance { get; set; }
            public double FastestRideSpeed { get; set; }
            public double MostElevationGain { get; set; }
        }
    }
}
