using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<string> Data
        {
            get;
            set;
        }
    }
}
