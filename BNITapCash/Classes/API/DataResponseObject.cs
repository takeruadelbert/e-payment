using Newtonsoft.Json;

namespace BNITapCash.API
{
    class DataResponseObject : DataResponseArray
    {
        [JsonProperty("data")]
        public JsonObjectAttribute Data { get; set; }
    }
}
