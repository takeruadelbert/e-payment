using Newtonsoft.Json;

namespace BNITapCash.API.request
{
    class ParkingOutFreePassRequest
    {
        [JsonProperty("vehicle")]
        private string Vehicle { get; set; }

        [JsonProperty("type")]
        private string Type { get; set; }

        [JsonProperty("uid")]
        private string UID { get; set; }

        [JsonProperty("username")]
        private string Username { get; set; }

        [JsonProperty("waktu_keluar")]
        private string DatetimeOut { get; set; }

        [JsonProperty("total_fare")]
        private int TotalFare { get; set; }

        [JsonProperty("plate_number")]
        private string PlateNumber { get; set; }

        [JsonProperty("ipv4")]
        private string IpAddress { get; set; }

        [JsonProperty("supervisor")]
        private string SupervisorUIDCard { get; set; }

        [JsonProperty("image")]
        private string Base64Image { get; set; }

        [JsonProperty("camera_image")]
        private string Base64LiveCameraSnapshotImage { get; set; }

        public ParkingOutFreePassRequest(string vehicle, string type, string uid, string username, string datetimeOut, string plateNumber, string ipAddress, string supervisorUidCard, string base64image, string base64LiveCameraSnapshotImage)
        {
            Vehicle = vehicle;
            Type = type;
            UID = uid;
            Username = username;
            DatetimeOut = datetimeOut;
            TotalFare = 0;
            PlateNumber = plateNumber;
            IpAddress = ipAddress;
            SupervisorUIDCard = supervisorUidCard;
            Base64Image = base64image;
            Base64LiveCameraSnapshotImage = base64LiveCameraSnapshotImage;
        }
    }
}
