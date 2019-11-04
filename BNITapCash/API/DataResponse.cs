using Newtonsoft.Json;

namespace BNITapCash.API
{
    abstract class DataResponse
    {
        [JsonProperty("status")]
        protected int Status { get; set; }

        [JsonProperty("message")]
        protected string message { get; set; }
    }
}
