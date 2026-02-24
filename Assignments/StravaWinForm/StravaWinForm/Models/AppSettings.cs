namespace StravaWinForm.Models
{
    public class AppSettings
    {
        public StravaConfig Strava { get; set; } = new();
    }

    public class StravaConfig
    {
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string RedirectUri { get; set; } = string.Empty;
    }
}