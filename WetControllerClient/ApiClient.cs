using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WetControllerClient.Models;

namespace WetControllerClient
{
    public class TemperaturesClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _login;
        private readonly string _password;

        private string cachedAccessToken = string.Empty;

        public TemperaturesClient(string baseDomain, string login, string password)
        {
            _login = login;
            _password = password;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseDomain)
            };
        }

        public async Task<WetControllerModel> CreateReport(Guid cotrollerId, double value)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, "api/wets/reports"))
            {
                AddJwtBearerAuthorization(request, cachedAccessToken);

                var reportModel = new CreateWetReportModel
                {
                    ControllerId = cotrollerId,
                    WetPercent = value
                };

                request.Content = new StringContent(JsonConvert.SerializeObject(reportModel));
                AddJsonContentType(request);

                using (var response = await _httpClient.SendAsync(request))
                {
                    if (response.StatusCode != HttpStatusCode.OK) return null;

                    var stringContent = await response.Content.ReadAsStringAsync();
                    var wetSettings = JsonConvert.DeserializeObject<WetControllerModel>(stringContent);
                    return wetSettings;
                }
            }
        }

        public async Task<string> Authorize()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, "/api/identity/login"))
            {
                var loginBody = new LoginBody
                {
                    Username = _login,
                    Password = _password
                };

                var body = JsonConvert.SerializeObject(loginBody);
                request.Content = new StringContent(body);
                AddJsonContentType(request);

                using (var response = await _httpClient.SendAsync(request))
                {
                    if (response.StatusCode != HttpStatusCode.OK) return string.Empty;

                    var responseStringContent = await response.Content.ReadAsStringAsync();
                    var loginResult = JsonConvert.DeserializeObject<LoginResult>(responseStringContent);
                    return cachedAccessToken = loginResult.AccessToken;
                }
            }
        }

        private static void AddJwtBearerAuthorization(HttpRequestMessage message, string bearerToken)
        {
            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        }

        private static void AddJsonContentType(HttpRequestMessage message)
        {
            message.Content.Headers.ContentType.MediaType = "application/json";
        }
    }
}
