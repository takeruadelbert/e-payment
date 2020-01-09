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

        [JsonProperty("type")]
        public string Type;

        public Gate(int id, string name, string ipAddress, string type)
        {
            Id = id;
            Name = name;
            IpAddress = ipAddress;
            Type = type;
        }
    }
}
