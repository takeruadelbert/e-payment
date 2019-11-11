using Newtonsoft.Json;

namespace BNITapCash.API.request
{
    class FineFareRequest
    {
        [JsonProperty("vehicle")]
        private string Vehicle { get; set; }

        public FineFareRequest(string vehicle)
        {
            Vehicle = vehicle;
        }
    }
}
