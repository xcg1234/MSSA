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
        private const string TokenFilePath = "strava_tokens.dat"; // using .dat to indicate it's encrypted

        // setting an empty JsonSerializerOptions to avoid repeated creation
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
           
        };

        // constructor with parameters for client ID, secret, and redirect URI
        public StravaAuthService(string clientId, string clientSecret, string redirectUri)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _redirectUri = redirectUri;
        }


        // Asyc method to get authorization code,
        // using HttpListener to handle the redirect and capture the code
        // https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
        public async Task<string> GetAuthorizationCodeAsync(CancellationToken cancellationToken = default)
        {
            string scope = "read,activity:read_all";
            string authUrl = $"https://www.strava.com/oauth/authorize?client_id={_clientId}&redirect_uri={_redirectUri}&response_type=code&approval_prompt=force&scope={scope}";

            using HttpListener listener = new HttpListener();
            //listen to the 8080 port which was set in the strava API settings, and wait for the redirect with the code
            listener.Prefixes.Add(_redirectUri);
            listener.Start();

            try
            {   //asking browser to open the authorization URL, which will redirect back to our listener with the code
                Process.Start(new ProcessStartInfo(authUrl) { UseShellExecute = true });

                // Wait for the incoming request with the authorization code, and handle cancellation
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
            {   //get the json response, deserialize it to StravaTokenResponse, save the tokens, and return the token response
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

        
        private async Task SaveTokensAsync(StravaTokenResponse? tokens)
        {
            if (tokens == null) return;

            try
            {
                // using static JsonSerializerOptions to avoid repeated creation, and serialize the tokens to JSON
                var json = JsonSerializer.Serialize(tokens, JsonOptions);
                var data = Encoding.UTF8.GetBytes(json);

                // using Windows Data Protection API to encrypt the token data, which will be tied to the current user and machine
                var encryptedData = ProtectedData.Protect(
                    data,
                    null,
                    DataProtectionScope.CurrentUser);

                // writing the encrypted data to a file asynchronously, which will be used to store the tokens securely
                await File.WriteAllBytesAsync(TokenFilePath, encryptedData);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to save tokens: {ex.Message}");
                
            }
        }

        private async Task<StravaTokenResponse?> LoadTokensAsync()
        {
            if (!File.Exists(TokenFilePath))
                return null;

            try
            {
                // loading the encrypted token data from the file asynchronously, which will be used to retrieve the tokens
                var encryptedData = await File.ReadAllBytesAsync(TokenFilePath);


                // decrypting the data using Windows Data Protection API,
                // which will only succeed if the data was encrypted on the same machine and user account
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