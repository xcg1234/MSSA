using System.Text.Json;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using StravaWebAPI.Models;

namespace StravaWebAPI.Services
{
    public class StravaAuthService : IStravaAuthService
    {
        private const string TokenFilePath = "strava_tokens.dat";

        private readonly StravaOptions _options;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDataProtector _protector;
        private readonly string _tokenFileAbsolutePath;

        public StravaAuthService(
            IOptions<StravaOptions> options,
            IHttpClientFactory httpClientFactory,
            IDataProtectionProvider dataProtectionProvider,
            IWebHostEnvironment env)
        {
            _options = options.Value;
            _httpClientFactory = httpClientFactory;
            _protector = dataProtectionProvider.CreateProtector("StravaWebAPI.Tokens");
            _tokenFileAbsolutePath = Path.Combine(env.ContentRootPath, TokenFilePath);
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
            if (File.Exists(_tokenFileAbsolutePath))
            {
                File.Delete(_tokenFileAbsolutePath);
            }

            return Task.CompletedTask;
        }

        private async Task SaveTokensAsync(StravaTokenResponse? tokens)
        {
            if (tokens == null)
            {
                return;
            }

            var json = JsonSerializer.Serialize(tokens);
            var protectedPayload = _protector.Protect(json);
            await File.WriteAllTextAsync(_tokenFileAbsolutePath, protectedPayload);
        }

        private async Task<StravaTokenResponse?> LoadTokensAsync()
        {
            if (!File.Exists(_tokenFileAbsolutePath))
            {
                return null;
            }

            try
            {
                var protectedPayload = await File.ReadAllTextAsync(_tokenFileAbsolutePath);
                var json = _protector.Unprotect(protectedPayload);
                return JsonSerializer.Deserialize<StravaTokenResponse>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}
