using Newtonsoft.Json;

namespace BNITapCash.API.response
{
    class Gate
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("ipv4")]
        public string IpAddress;

        public Gate(int id, string name, string ipAddress)
        {
            Id = id;
            Name = name;
            IpAddress = ipAddress;
        }
    }
}
