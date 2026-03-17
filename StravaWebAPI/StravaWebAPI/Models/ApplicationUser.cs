using Microsoft.AspNetCore.Identity;

namespace StravaWebAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? StravaAccessToken { get; set; }
        public string? StravaRefreshToken { get; set; }
        public DateTime? StravaTokenExpiresAtUtc { get; set; }
    }
}
