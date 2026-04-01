using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using StravaWebAPI.Models;

namespace StravaWebAPI.Services
{
    public class StravaAuthService : IStravaAuthService
    {
        private const string TokenCacheKey = "StravaAuth:Tokens";

        private readonly StravaOptions _options;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _cache;

        public StravaAuthService(
            IOptions<StravaOptions> options,
            IHttpClientFactory httpClientFactory,
            IMemoryCache cache)
        {
            _options = options.Value;
            _httpClientFactory = httpClientFactory;
            _cache = cache;
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

            var json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                // Helpful for debugging via exception page or logs.
                throw new InvalidOperationException($"Strava token exchange failed: {response.StatusCode} - {json}");
            }

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
            if (tokens == null)
            {
                _cache.Remove(TokenCacheKey);
            }
            else
            {
                // Cache until token expiry (with a small buffer).
                var ttlSeconds = Math.Max(60, tokens.expires_at - DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 30);
                _cache.Set(TokenCacheKey, tokens, TimeSpan.FromSeconds(ttlSeconds));
            }
            await Task.CompletedTask;
        }

        private async Task<StravaTokenResponse?> LoadTokensAsync()
        {
            _cache.TryGetValue(TokenCacheKey, out StravaTokenResponse? tokens);
            return await Task.FromResult(tokens);
        }
    }
}
