using Newtonsoft.Json;
using System.Collections.Generic;

namespace BNITapCash.Classes.API.response
{
    public class ParkingInPedestrian : BaseResponse
    {
        [JsonProperty("pedestrian")]
        public List<DataPedestrian> Pedestrians;

        [JsonProperty("cargo")]
        public List<Cargo> Cargos;

        [JsonProperty("notes")]
        public List<string> Notes;

        public ParkingInPedestrian(List<DataPedestrian> pedestrians, List<Cargo> cargos, List<string> notes)
        {
            Pedestrians = pedestrians;
            Cargos = cargos;
            Notes = notes;
        }
    }
}
