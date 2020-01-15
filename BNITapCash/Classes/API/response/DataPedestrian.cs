using Newtonsoft.Json;

namespace BNITapCash.Classes.API.response
{
    public class DataPedestrian : BaseResponse
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("fare")]
        public int Fare;

        public DataPedestrian(string name, int fare)
        {
            Name = name;
            Fare = fare;
        }
    }
}
