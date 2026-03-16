using StravaWebAPI.Models;

namespace StravaWebAPI.Services
{
    public interface IStravaApiService
    {
        Task<List<StravaActivity>> GetActivitiesAsync(int count = 5);
        Task<Dictionary<string, YearlyStats>> GetYearlyComparisonAsync();
        Task<PersonalRecords> GetPersonalRecordsAsync();
    }
}
