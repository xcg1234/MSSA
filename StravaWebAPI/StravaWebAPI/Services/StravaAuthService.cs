using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using StravaWebAPI.Models;

namespace StravaWebAPI.Services
{
    public class StravaAuthService : IStravaAuthService
    {
        private const string LocalBootstrapUserEmail = "local@stravaapp.dev";

        private readonly StravaOptions _options;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<ApplicationUser> _userManager;

        public StravaAuthService(
            IOptions<StravaOptions> options,
            IHttpClientFactory httpClientFactory,
            UserManager<ApplicationUser> userManager)
        {
            _options = options.Value;
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        public string GetAuthorizationUrl()
        {
            const string scope = "read,activity:read_all";
            var redirectUri = Uri.EscapeDataString(_options.RedirectUri);
            var scopeEncoded = Uri.EscapeDataString(scope);

            return $"https://www.strava.com/oauth/authorize?client_id={_options.ClientId}&redirect_uri={redirectUri}&response_type=code&approval_prompt=force&scope={scopeEncoded}";
        }

        public async Task<StravaTokenResponse?> ExchangeCodeForTokensAsync(string code)
        {
            var client = _httpClientFactory.CreateClient();

            var values = new Dictionary<string, string>
            {
                ["client_id"] = _options.ClientId,
                ["client_secret"] = _options.ClientSecret,
                ["code"] = code,
                ["grant_type"] = "authorization_code"
            };

            using var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://www.strava.com/oauth/token", content);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<StravaTokenResponse>(json);
            await SaveTokensAsync(tokenResponse);
            return tokenResponse;
        }

        public async Task<StravaTokenResponse?> RefreshAccessTokenAsync(string refreshToken)
        {
            var client = _httpClientFactory.CreateClient();

            var values = new Dictionary<string, string>
            {
                ["client_id"] = _options.ClientId,
                ["client_secret"] = _options.ClientSecret,
                ["refresh_token"] = refreshToken,
                ["grant_type"] = "refresh_token"
            };

            using var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://www.strava.com/oauth/token", content);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<StravaTokenResponse>(json);
            await SaveTokensAsync(tokenResponse);
            return tokenResponse;
        }

        public async Task<string?> GetValidAccessTokenAsync()
        {
            var tokens = await LoadTokensAsync();
            if (tokens == null)
            {
                return null;
            }

            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (now > tokens.expires_at - 300)
            {
                var newTokens = await RefreshAccessTokenAsync(tokens.refresh_token);
                return newTokens?.access_token;
            }

            return tokens.access_token;
        }

        public async Task<bool> IsAuthorizedAsync()
        {
            var token = await GetValidAccessTokenAsync();
            return !string.IsNullOrWhiteSpace(token);
        }

        public Task ClearTokensAsync()
        {
            return SaveTokensAsync(null);
        }

        private async Task SaveTokensAsync(StravaTokenResponse? tokens)
        {
            var user = await GetOrCreateLocalUserAsync();
            if (user == null)
            {
                return;
            }

            if (tokens == null)
            {
                user.StravaAccessToken = null;
                user.StravaRefreshToken = null;
                user.StravaTokenExpiresAtUtc = null;
            }
            else
            {
                user.StravaAccessToken = tokens.access_token;
                user.StravaRefreshToken = tokens.refresh_token;
                user.StravaTokenExpiresAtUtc = DateTimeOffset
                    .FromUnixTimeSeconds(tokens.expires_at)
                    .UtcDateTime;
            }

            await _userManager.UpdateAsync(user);
        }

        private async Task<StravaTokenResponse?> LoadTokensAsync()
        {
            var user = await GetOrCreateLocalUserAsync();
            if (user == null || string.IsNullOrWhiteSpace(user.StravaAccessToken))
            {
                return null;
            }

            var expiresAt = user.StravaTokenExpiresAtUtc ?? DateTime.UtcNow;
            var expiresAtUnix = new DateTimeOffset(DateTime.SpecifyKind(expiresAt, DateTimeKind.Utc)).ToUnixTimeSeconds();

            return new StravaTokenResponse
            {
                access_token = user.StravaAccessToken,
                refresh_token = user.StravaRefreshToken ?? string.Empty,
                expires_at = expiresAtUnix,
                expires_in = (int)Math.Max(0, expiresAtUnix - DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            };
        }

        private async Task<ApplicationUser?> GetOrCreateLocalUserAsync()
        {
            var user = await _userManager.FindByEmailAsync(LocalBootstrapUserEmail);
            if (user != null)
            {
                return user;
            }

            user = new ApplicationUser
            {
                UserName = LocalBootstrapUserEmail,
                Email = LocalBootstrapUserEmail,
                EmailConfirmed = true
            };

            var createResult = await _userManager.CreateAsync(user);
            return createResult.Succeeded ? user : null;
        }
    }
}
