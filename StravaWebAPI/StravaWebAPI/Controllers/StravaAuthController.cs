using Microsoft.AspNetCore.Mvc;
using StravaWebAPI.Services;

namespace StravaWebAPI.Controllers
{
    [ApiController]
    [Route("api/strava/auth")]
    public class StravaAuthController(IStravaAuthService authService) : ControllerBase
    {
        private readonly IStravaAuthService _authService = authService;

        [HttpGet("url")]
        public IActionResult GetAuthorizationUrl()
        {
            return Ok(new { url = _authService.GetAuthorizationUrl() });
        }

        [HttpGet("callback")]
        public async Task<IActionResult> Callback([FromQuery] string? code, [FromQuery] string? error)
        {
            if (!string.IsNullOrWhiteSpace(error))
            {
                return BadRequest(new { error });
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                return BadRequest(new { error = "Missing authorization code." });
            }

            var tokens = await _authService.ExchangeCodeForTokensAsync(code);
            if (tokens == null)
            {
                return BadRequest(new { error = "Failed to exchange authorization code for tokens." });
            }

            return Ok(new
            {
                message = "Strava authorized successfully.",
                expiresAt = tokens.expires_at
            });
        }

        [HttpGet("status")]
        public async Task<IActionResult> Status()
        {
            return Ok(new { authorized = await _authService.IsAuthorizedAsync() });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.ClearTokensAsync();
            return NoContent();
        }
    }
}
