using System.Text.Json.Serialization;

namespace StravaWinForm.Models
{
    public class StravaActivity
    {
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public float distance { get; set; } // in meters
        public int moving_time { get; set; } // in seconds
        public string type { get; set; } = string.Empty; // "Run" or "Ride"
        public string sport_type { get; set; } = string.Empty;
        
        [JsonPropertyName("start_date")]
        public DateTime start_date { get; set; }
        
        [JsonPropertyName("start_date_local")]
        public DateTime start_date_local { get; set; }
        
        public float? average_speed { get; set; }
        public float? average_heartrate { get; set; }
        public float total_elevation_gain { get; set; }

        // Computed properties for display
        public string DistanceInMiles => $"{(distance * 0.000621371):F2} mi";
        public string DistanceInKm => $"{(distance / 1000):F2} km";
        public string PacePerMile => type == "Run" ? CalculatePace() : "N/A";
        public string Duration => TimeSpan.FromSeconds(moving_time).ToString(@"hh\:mm\:ss");

        private string CalculatePace()
        {
            if (distance == 0) return "N/A";
            double milesPerHour = (distance * 0.000621371) / (moving_time / 3600.0);
            double minutesPerMile = 60.0 / milesPerHour;
            int minutes = (int)minutesPerMile;
            int seconds = (int)((minutesPerMile - minutes) * 60);
            return $"{minutes}:{seconds:D2} /mi";
        }
    }
}