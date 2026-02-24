using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using StravaWinForm.Models;

namespace StravaWinForm.Services
{
    public class StravaAuthService
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _redirectUri;
        private const string TokenFilePath = "strava_tokens.dat"; // 改为 .dat 表示加密数据
        
        // ✅ 优化1: 静态只读字段，避免重复创建
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
           
        };

        public StravaAuthService(string clientId, string clientSecret, string redirectUri)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _redirectUri = redirectUri;
        }

        public async Task<string> GetAuthorizationCodeAsync(CancellationToken cancellationToken = default)
        {
            string scope = "read,activity:read_all";
            string authUrl = $"https://www.strava.com/oauth/authorize?client_id={_clientId}&redirect_uri={_redirectUri}&response_type=code&approval_prompt=force&scope={scope}";

            using HttpListener listener = new HttpListener();
            listener.Prefixes.Add(_redirectUri);
            listener.Start();

            try
            {
                Process.Start(new ProcessStartInfo(authUrl) { UseShellExecute = true });
                
                HttpListenerContext context = await listener.GetContextAsync().WaitAsync(cancellationToken);
                
                string? error = context.Request.QueryString["error"];
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception($"Authorization failed: {error}");
                }
                
                string? code = context.Request.QueryString["code"];
                
                return code ?? throw new Exception("No authorization code received");
            }
            finally
            {
                listener.Stop();
            }
        }

        public async Task<StravaTokenResponse?> ExchangeCodeForTokensAsync(string code)
        {
            using var client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "code", code },
                { "grant_type", "authorization_code" }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://www.strava.com/oauth/token", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<StravaTokenResponse>(json);

                await SaveTokensAsync(tokenResponse);

                return tokenResponse;
            }

            return null;
        }

        public async Task<StravaTokenResponse?> RefreshAccessTokenAsync(string refreshToken)
        {
            using var client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "refresh_token", refreshToken },
                { "grant_type", "refresh_token" }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://www.strava.com/oauth/token", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<StravaTokenResponse>(json);

                await SaveTokensAsync(tokenResponse);

                return tokenResponse;
            }

            return null;
        }

        public async Task<string?> GetValidAccessTokenAsync()
        {
            var tokens = await LoadTokensAsync();

            if (tokens == null)
            {
                return null;
            }

            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (now > (tokens.expires_at - 300))
            {
                var newTokens = await RefreshAccessTokenAsync(tokens.refresh_token);
                return newTokens?.access_token;
            }

            return tokens.access_token;
        }

        // ✅ 优化版本：异步 + 加密 + 使用静态 JsonOptions
        private async Task SaveTokensAsync(StravaTokenResponse? tokens)
        {
            if (tokens == null) return;

            try
            {
                // 使用静态的 JsonOptions，避免重复创建
                var json = JsonSerializer.Serialize(tokens, JsonOptions);
                var data = Encoding.UTF8.GetBytes(json);
                
                // ✅ 优化3: 使用 DPAPI 加密（仅当前用户可解密）
                var encryptedData = ProtectedData.Protect(
                    data,
                    null,
                    DataProtectionScope.CurrentUser);
                
                // ✅ 优化4: 异步写入
                await File.WriteAllBytesAsync(TokenFilePath, encryptedData);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to save tokens: {ex.Message}");
                // 可以选择重新抛出或记录日志
            }
        }

        private async Task<StravaTokenResponse?> LoadTokensAsync()
        {
            if (!File.Exists(TokenFilePath))
                return null;

            try
            {
                // 异步读取加密数据
                var encryptedData = await File.ReadAllBytesAsync(TokenFilePath);
                

                // 解密
                var data = ProtectedData.Unprotect(
                    encryptedData,
                    null,
                    DataProtectionScope.CurrentUser);
                
                var json = Encoding.UTF8.GetString(data);
                Debug.WriteLine($"Loaded tokens: {json}"); 


                return JsonSerializer.Deserialize<StravaTokenResponse>(json, JsonOptions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to load tokens: {ex.Message}");
                return null;
            }
        }

        public bool IsAuthorized()
        {
            return File.Exists(TokenFilePath);
        }
    }
}