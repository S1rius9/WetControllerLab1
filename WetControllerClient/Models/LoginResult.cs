using Newtonsoft.Json;

namespace WetControllerClient.Models
{
    public class LoginResult
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}
