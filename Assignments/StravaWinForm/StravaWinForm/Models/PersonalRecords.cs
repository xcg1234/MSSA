namespace StravaWinForm.Models
{
    public class PersonalRecords
    {
        public ActivityRecord? LongestRun { get; set; }
        public ActivityRecord? FastestRunPace { get; set; }
        public ActivityRecord? LongestRide { get; set; }
        public ActivityRecord? FastestRide { get; set; }
        public ActivityRecord? MostElevationGain { get; set; }
    }

    public class ActivityRecord
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Value { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
    }
}
