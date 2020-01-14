using Newtonsoft.Json;

namespace BNITapCash.Classes.API.request
{
    class PassKadeOutRequest
    {
        [JsonProperty("vehicle")]
        private string VehicleType;

        [JsonProperty("waktu_keluar")]
        private string DatetimeOut;

        [JsonProperty("username")]
        private string Username;

        [JsonProperty("plate_number")]
        private string PlateNumber;

        [JsonProperty("total_fare")]
        private int TotalFare;

        [JsonProperty("note")]
        private string Note;

        [JsonProperty("ipv4")]
        private string IpAddress;

        [JsonProperty("payment_method")]
        private string PaymentMethod;

        [JsonProperty("bank_code")]
        private string BankCode;

        [JsonProperty("image")]
        private string Base64WebcamImage;

        [JsonProperty("camera_image")]
        private string Base64IpCameraImage;

        public PassKadeOutRequest(string vehicleType, string datetimeOut, string username, string plateNumber, int totalFare, string note, string ipAddress,
            string paymentMethod, string bankCode, string base64Webcam, string base64IpCamera)
        {
            VehicleType = vehicleType;
            DatetimeOut = datetimeOut;
            Username = username;
            PlateNumber = plateNumber;
            TotalFare = totalFare;
            Note = note;
            IpAddress = ipAddress;
            PaymentMethod = paymentMethod;
            BankCode = bankCode;
            Base64WebcamImage = base64Webcam;
            Base64IpCameraImage = base64IpCamera;
        }
    }
}
