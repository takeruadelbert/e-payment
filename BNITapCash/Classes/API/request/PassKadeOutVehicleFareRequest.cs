using Newtonsoft.Json;

namespace BNITapCash.Classes.API.request
{
    class PassKadeOutVehicleFareRequest
    {
        [JsonProperty("vehicle")]
        private string VehicleType;

        public PassKadeOutVehicleFareRequest(string vehicleType)
        {
            VehicleType = vehicleType;
        }
    }
}
