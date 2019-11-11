using Newtonsoft.Json;

namespace BNITapCash.API.response
{
    class ParkingOut
    {
        [JsonProperty("id")]
        private int ParkingOutId { get; set; }

        [JsonProperty("total")]
        private int TotalFare { get; set; }
    }
}
