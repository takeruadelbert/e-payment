using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BNITapCash.API
{
    class DataResponse
    {
        [JsonProperty("status")]
        public int Status
        {
            get;
            set;
        }

        [JsonProperty("message")]
        public string Message
        {
            get;
            set;
        }

        [JsonProperty("data")]
        public JArray Data
        {
            get;
            set;
        }
    }
}
