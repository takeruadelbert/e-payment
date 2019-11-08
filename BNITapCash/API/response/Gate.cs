using Newtonsoft.Json;

namespace BNITapCash.API.response
{
    class Gate
    {
        [JsonProperty("id")]
        private long Id { get; set; }

        [JsonProperty("name")]
        private string Name { get; set; }

        [JsonProperty("ipv4")]
        private string IpAddress { get; set; }

        public Gate(long id, string name, string ipAddress)
        {
            Id = id;
            Name = name;
            IpAddress = ipAddress;
        }
    }
}
