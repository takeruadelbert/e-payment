using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BNITapCash.API
{
    class DataResponseObject : DataResponse
    {
        [JsonProperty("data")]
        public JToken Data { get; set; }
    }
}
