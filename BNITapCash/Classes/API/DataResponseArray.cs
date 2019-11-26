using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BNITapCash.API
{
    class DataResponseArray : DataResponse
    {
        [JsonProperty("data")]
        public JArray Data
        {
            get;
            set;
        }
    }
}
