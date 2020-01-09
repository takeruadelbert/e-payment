using Newtonsoft.Json;

namespace BNITapCash.Classes.API.response
{
    public class Cargo : BaseResponse
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("fare")]
        public int Fare;

        public Cargo(string name, int fare)
        {
            Name = name;
            Fare = fare;
        }
    }
}
