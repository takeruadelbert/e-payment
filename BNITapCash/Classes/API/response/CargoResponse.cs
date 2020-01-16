using Newtonsoft.Json;

namespace BNITapCash.Classes.API.response
{
    class CargoResponse : BaseResponse
    {
        [JsonProperty("id")]
        public int CargoFareId;

        [JsonProperty("total")]
        public int TotalFare;

        public CargoResponse(int id, int fare)
        {
            CargoFareId = id;
            TotalFare = fare;
        }
    }
}
