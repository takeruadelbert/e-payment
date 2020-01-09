using BNITapCash.Classes.API.response;
using Newtonsoft.Json;

namespace BNITapCash.API.response
{
    class ParkingIn : BaseResponse
    {
        [JsonProperty("lama_parkir")]
        public string ParkDuration { get; set; }

        [JsonProperty("tarif_parkir")]
        public int Fare { get; set; }

        [JsonProperty("gate")]
        public string Gate { get; set; }

        [JsonProperty("gambar_plate")]
        public string PlateNumberImage { get; set; }

        [JsonProperty("gambar_face")]
        public string FaceImage { get; set; }

        [JsonProperty("waktu_masuk")]
        public string DatetimeIn { get; set; }

        [JsonProperty("waktu_keluar")]
        public string DatetimeOut { get; set; }

        public ParkingIn()
        {

        }

        public ParkingIn(string duration, int fare, string gate, string plateNumber, string face, string datetimeIn, string datetimeOut)
        {
            ParkDuration = duration;
            Fare = fare;
            Gate = gate;
            PlateNumberImage = plateNumber;
            FaceImage = face;
            DatetimeIn = datetimeIn;
            DatetimeOut = datetimeOut;
        }
    }
}
