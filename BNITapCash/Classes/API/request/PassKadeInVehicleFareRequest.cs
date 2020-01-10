using Newtonsoft.Json;

namespace BNITapCash.Classes.API.request
{
    class PassKadeInVehicleFareRequest
    {
        [JsonProperty("vehicle")]
        public string VehicleType { get; set; }

        public PassKadeInVehicleFareRequest(string type)
        {
            VehicleType = type;
        }
    }
}
