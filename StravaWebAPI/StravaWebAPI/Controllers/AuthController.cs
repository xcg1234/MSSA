using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StravaWebAPI.Models;

namespace StravaWebAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager) : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

        public class LoginModel
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input.");
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return Ok(new { message = "Registered and logged in successfully." });
            }

            return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input.");
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok(new { message = "Logged in successfully." });
            }

            return Unauthorized(new { message = "Invalid email or password." });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Logged out successfully." });
        }

        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return Ok(new { email = User.Identity.Name });
            }
            return Unauthorized();
        }
    }
}
