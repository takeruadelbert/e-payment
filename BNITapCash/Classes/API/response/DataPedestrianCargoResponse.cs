using Newtonsoft.Json;
using System.Collections.Generic;

namespace BNITapCash.Classes.API.response
{
    class DataPedestrianCargoResponse : BaseResponse
    {
        [JsonProperty("cargo")]
        public CargoResponse Cargo;

        [JsonProperty("pedestrian")]
        public List<PedestrianResponse> Pedestrians;

        public DataPedestrianCargoResponse(CargoResponse cargo, List<PedestrianResponse> pedestrians)
        {
            Cargo = cargo;
            Pedestrians = pedestrians;
        }
    }
}
