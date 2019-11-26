using Newtonsoft.Json;

namespace BNITapCash.API.request
{
    class RequestFareRequest
    {
        [JsonProperty("type")]
        private string Type { get; set; }

        [JsonProperty("uid")]
        private string UID { get; set; }

        [JsonProperty("vehicle")]
        private string Vehicle { get; set; }

        public RequestFareRequest(string type, string uid, string vehicle)
        {
            Type = type;
            UID = uid;
            Vehicle = vehicle;
        }
    }
}
