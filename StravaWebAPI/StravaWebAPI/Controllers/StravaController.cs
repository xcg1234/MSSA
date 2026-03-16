using Microsoft.AspNetCore.Mvc;
using StravaWebAPI.Services;

namespace StravaWebAPI.Controllers
{
    [ApiController]
    [Route("api/strava")]
    public class StravaController(IStravaApiService apiService) : ControllerBase
    {
        private readonly IStravaApiService _apiService = apiService;

        [HttpGet("activities")]
        public async Task<IActionResult> GetActivities([FromQuery] int count = 5)
        {
            try
            {
                return Ok(await _apiService.GetActivitiesAsync(count));
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("yearly-comparison")]
        public async Task<IActionResult> GetYearlyComparison()
        {
            try
            {
                return Ok(await _apiService.GetYearlyComparisonAsync());
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("personal-records")]
        public async Task<IActionResult> GetPersonalRecords()
        {
            try
            {
                return Ok(await _apiService.GetPersonalRecordsAsync());
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
