using Newtonsoft.Json;

namespace BNITapCash.API.request
{
    class FreePassRequest
    {
        [JsonProperty("type")]
        private string Type { get; set; }

        [JsonProperty("uid")]
        private string UID { get; set; }

        public FreePassRequest(string type, string uid)
        {
            Type = type;
            UID = uid;
        }
    }
}
