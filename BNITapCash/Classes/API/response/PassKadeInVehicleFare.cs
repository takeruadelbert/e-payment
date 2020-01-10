using Newtonsoft.Json;

namespace BNITapCash.Classes.API.response
{
    class PassKadeInVehicleFare : BaseResponse
    {
        [JsonProperty("kendaraan")]
        public string VehicleType;

        [JsonProperty("tarif")]
        public int Fare;

        [JsonProperty("waktu_berangkat")]
        public string DatetimeOut;

        public PassKadeInVehicleFare(string type, int fare, string datetimeOut)
        {
            VehicleType = type;
            Fare = fare;
            DatetimeOut = datetimeOut;
        }
    }
}
