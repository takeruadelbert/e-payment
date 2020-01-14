using Newtonsoft.Json;

namespace BNITapCash.Classes.API.response
{
    class PassKadeOutVehicleFare : BaseResponse
    {
        [JsonProperty("kendaraan")]
        public string VehicleType;

        [JsonProperty("tarif")]
        public int Fare;

        [JsonProperty("waktu_keluar")]
        public string DatetimeOut;

        public PassKadeOutVehicleFare(string type, int fare, string dtOut)
        {
            VehicleType = type;
            Fare = fare;
            DatetimeOut = dtOut;
        }
    }
}
