using Newtonsoft.Json;

namespace BNITapCash.Classes.API.response
{
    public class Pedestrian : BaseResponse
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("fare")]
        public int Fare;

        public Pedestrian(string name, int fare)
        {
            Name = name;
            Fare = fare;
        }
    }
}
