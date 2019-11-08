using Newtonsoft.Json;

namespace BNITapCash.API
{
    class DataResponseObject : DataResponse
    {
        [JsonProperty("data")]
        public JsonObjectAttribute Data { get; set; }
    }
}
