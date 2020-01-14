using Newtonsoft.Json;

namespace BNITapCash.Classes.API.response
{
    class PassKadeOutResponse : BaseResponse
    {
        [JsonProperty("id")]
        public int ParkingOutId;

        [JsonProperty("total")]
        public int Total;

        public PassKadeOutResponse(int id, int total)
        {
            ParkingOutId = id;
            Total = total;
        }
    }
}
