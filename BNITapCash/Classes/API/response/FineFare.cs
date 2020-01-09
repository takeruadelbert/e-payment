using BNITapCash.Classes.API.response;
using Newtonsoft.Json;

namespace BNITapCash.API.response
{
    class FineFare : BaseResponse
    {
        [JsonProperty("vehicle")]
        private string Vehicle { get; set; }

        [JsonProperty("denda")]
        public int ChargeFare;

        [JsonProperty("waktu_keluar")]
        public string DatetimeOut;

        public FineFare(string vehicle, int chargeFare, string datetimeOut)
        {
            Vehicle = vehicle;
            ChargeFare = chargeFare;
            DatetimeOut = datetimeOut;
        }
    }
}
