using Newtonsoft.Json;

namespace BNITapCash.API
{
    abstract class DataResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
