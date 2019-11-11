using Newtonsoft.Json;

namespace BNITapCash.API.request
{
    class LostTicketRequest
    {
        [JsonProperty("vehicle")]
        private string Vehicle { get; set; }

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

        [JsonProperty("payment_method")]
        private string PaymentMethod { get; set; }

        [JsonProperty("image")]
        private string CapturedWebcamImage { get; set; }

        public LostTicketRequest(string vehicle, string username, string datetimeOut, int totalFare, string plateNumber, string ipAddress, string paymentMethod, string image)
        {
            Vehicle = vehicle;
            Username = username;
            DatetimeOut = datetimeOut;
            TotalFare = totalFare;
            PlateNumber = plateNumber;
            IpAddress = ipAddress;
            PaymentMethod = paymentMethod;
            CapturedWebcamImage = image;
        }
    }
}
