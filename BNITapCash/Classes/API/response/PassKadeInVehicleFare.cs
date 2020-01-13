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
        public string DepartureDatetime;

        public PassKadeInVehicleFare(string type, int fare, string departure)
        {
            VehicleType = type;
            Fare = fare;
            DepartureDatetime = departure;
        }
    }
}
