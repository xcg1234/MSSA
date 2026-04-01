namespace StravaWebAPI.Models
{
    public class MonthlyMileageComparison
    {
        public int CurrentYear { get; set; }
        public int LastYear { get; set; }
        public List<double> RunCurrentYearMiles { get; set; } = [];
        public List<double> RunLastYearMiles { get; set; } = [];
        public List<double> RideCurrentYearMiles { get; set; } = [];
        public List<double> RideLastYearMiles { get; set; } = [];
    }
}
