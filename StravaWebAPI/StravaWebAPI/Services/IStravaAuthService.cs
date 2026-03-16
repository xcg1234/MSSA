using StravaWebAPI.Models;

namespace StravaWebAPI.Services
{
    public interface IStravaAuthService
    {
        string GetAuthorizationUrl();
        Task<StravaTokenResponse?> ExchangeCodeForTokensAsync(string code);
        Task<StravaTokenResponse?> RefreshAccessTokenAsync(string refreshToken);
        Task<string?> GetValidAccessTokenAsync();
        Task<bool> IsAuthorizedAsync();
        Task ClearTokensAsync();
    }
}
