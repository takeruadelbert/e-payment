using Newtonsoft.Json;

namespace BNITapCash.Classes.API.response
{
    class PassKadeDeparture : BaseResponse
    {
        [JsonProperty("id")]
        public int ParkingInId { get; set; }

        [JsonProperty("total")]
        public int TotalFare { get; set; }
    }
}
