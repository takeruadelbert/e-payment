using Newtonsoft.Json;

namespace BNITapCash.API.request
{
    class SignInRequest
    {
        [JsonProperty("username")]
        private string Username { get; set; }
        [JsonProperty("password")]
        private string Password { get; set; }

        public SignInRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
