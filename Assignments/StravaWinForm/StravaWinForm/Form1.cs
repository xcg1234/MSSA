using System.Text.Json;
using StravaWinForm.Models;
using StravaWinForm.Services;

namespace StravaWinForm
{
    public partial class Form1 : Form
    {
        private StravaAuthService? _authService;
        private StravaApiService? _apiService;

        public Form1()
        {
            InitializeComponent();
            InitializeServices();
        }

        private void InitializeServices()
        {
            try
            {
                var json = File.ReadAllText("appsettings.json");
                var settings = JsonSerializer.Deserialize<AppSettings>(json);

                if (settings?.Strava != null)
                {
                    _authService = new StravaAuthService(
                        settings.Strava.ClientId,
                        settings.Strava.ClientSecret,
                        settings.Strava.RedirectUri
                    );

                    _apiService = new StravaApiService(_authService);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading configuration: {ex.Message}\n\nMake sure appsettings.json exists!",
                    "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (_authService?.IsAuthorized() == true)
            {
                lblStatus.Text = "Connected to Strava";
                await LoadActivitiesAsync();
            }
            else
            {
                lblStatus.Text = "Click 'Connect to Strava' to begin";
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (_authService == null) return;

            try
            {
                btnConnect.Enabled = false;
                progressBar.Visible = true;
                lblStatus.Text = "Opening browser for authorization...";

                string code = await _authService.GetAuthorizationCodeAsync();

                if (string.IsNullOrEmpty(code))
                {
                    lblStatus.Text = "Authorization failed";
                    return;
                }

                lblStatus.Text = "Exchanging code for tokens...";

                var tokens = await _authService.ExchangeCodeForTokensAsync(code);

                if (tokens != null)
                {
                    lblStatus.Text = "Connected to Strava!";
                    MessageBox.Show("Successfully connected to Strava!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await LoadActivitiesAsync();
                }
                else
                {
                    lblStatus.Text = "Failed to get tokens";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnConnect.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private async void btnRefreshActivities_Click(object sender, EventArgs e)
        {
            await LoadActivitiesAsync();
        }

        private async Task LoadActivitiesAsync()
        {
            if (_apiService == null) return;

            try
            {
                progressBar.Visible = true;
                lblStatus.Text = "Loading activities...";

                var activities = await _apiService.GetActivitiesAsync(5);

                dgvActivities.DataSource = activities.Select(a => new
                {
                    Date = a.start_date_local.ToString("yyyy-MM-dd"),
                    Name = a.name,
                    Type = a.type,
                    Distance = a.DistanceInMiles,
                    Duration = a.Duration,
                    Pace = a.PacePerMile,
                    Elevation = $"{a.total_elevation_gain:F0} m"
                }).ToList();

                lblStatus.Text = $"Loaded {activities.Count} activities";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error loading activities";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        private async void btnRefreshDashboard_Click(object sender, EventArgs e)
        {
            await LoadYearlyComparisonAsync();
        }

        private async Task LoadYearlyComparisonAsync()
        {
            if (_apiService == null) return;

            try
            {
                progressBar.Visible = true;
                lblStatus.Text = "Loading yearly statistics...";

                var stats = await _apiService.GetYearlyComparisonAsync();

                var currentYear = DateTime.Now.Year.ToString();
                var lastYear = (DateTime.Now.Year - 1).ToString();

                lblRunThisYear.Text = $"{currentYear} Running: {stats[currentYear].RunMiles:F2} mi ({stats[currentYear].RunCount} runs)";
                lblRunLastYear.Text = $"{lastYear} Running: {stats[lastYear].RunMiles:F2} mi ({stats[lastYear].RunCount} runs)";

                lblBikeThisYear.Text = $"{currentYear} Biking: {stats[currentYear].BikeMiles:F2} mi ({stats[currentYear].BikeCount} rides)";
                lblBikeLastYear.Text = $"{lastYear} Biking: {stats[lastYear].BikeMiles:F2} mi ({stats[lastYear].BikeCount} rides)";

                lblStatus.Text = "Dashboard updated";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error loading dashboard";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
            }
        }


        private async void btnRefreshPRs_Click(object sender, EventArgs e)
        {
            await LoadPersonalRecordsAsync();
        }

        private async Task LoadPersonalRecordsAsync()
        {
            if (_apiService == null) return;

            try
            {
                progressBar.Visible = true;
                lblStatus.Text = "Loading personal records...";

                var records = await _apiService.GetPersonalRecordsAsync();

                if (records.LongestRun != null)
                {
                    lblLongestRun.Text = $"Longest Run: {records.LongestRun.Value} ({records.LongestRun.Duration}) - \"{records.LongestRun.Name}\" on {records.LongestRun.Date:MMM dd, yyyy}";
                }

                if (records.FastestRunPace != null)
                {
                    lblFastestPace.Text = $"Fastest Run Pace: {records.FastestRunPace.Value} ({records.FastestRunPace.Duration}) - \"{records.FastestRunPace.Name}\" on {records.FastestRunPace.Date:MMM dd, yyyy}";
                }

                if (records.LongestRide != null)
                {
                    lblLongestRide.Text = $"Longest Ride: {records.LongestRide.Value} ({records.LongestRide.Duration}) - \"{records.LongestRide.Name}\" on {records.LongestRide.Date:MMM dd, yyyy}";
                }

                if (records.FastestRide != null)
                {
                    lblFastestRide.Text = $"Fastest Ride: {records.FastestRide.Value} ({records.FastestRide.Duration}) - \"{records.FastestRide.Name}\" on {records.FastestRide.Date:MMM dd, yyyy}";
                }

                if (records.MostElevationGain != null)
                {
                    lblMostElevation.Text = $"Most Elevation Gain: {records.MostElevationGain.Value} ({records.MostElevationGain.Duration}) - \"{records.MostElevationGain.Name}\" on {records.MostElevationGain.Date:MMM dd, yyyy}";
                }

                lblStatus.Text = "Personal records loaded";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error loading personal records";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
            }
        }
    }
}
