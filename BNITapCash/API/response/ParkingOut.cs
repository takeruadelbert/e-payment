using Newtonsoft.Json;

namespace BNITapCash.API.response
{
    class ParkingOut
    {
        [JsonProperty("id")]
        public int ParkingOutId { get; set; }

        [JsonProperty("total")]
        public int TotalFare { get; set; }
    }
}
