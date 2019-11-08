using Newtonsoft.Json;

namespace BNITapCash.API.request
{
    class ParkingOutRequest
    {
        [JsonProperty("uid")]
        private string UID { get; set; }

        [JsonProperty("vehicle")]
        private string Vehicle { get; set; }

        [JsonProperty("waktu_keluar")]
        private string DatetimeOut { get; set; }

        [JsonProperty("username")]
        private string Username { get; set; }

        [JsonProperty("plate_number")]
        private string PlateNumber { get; set; }

        [JsonProperty("total_fare")]
        private int TotalFare { get; set; }

        [JsonProperty("ipv4")]
        private string IpAddress { get; set; }

        [JsonProperty("payment_method")]
        private string PaymentMethod { get; set; }

        [JsonProperty("bank_code")]
        private string BankCode { get; set; }

        [JsonProperty("image")]
        private string Image { get; set; }

        public ParkingOutRequest(string uid, string vehicle, string datetimeOut, string username, string plateNumber, int totalFare, string ipAddress, string paymentMethod, string bankCode, string image)
        {
            UID = uid;
            Vehicle = vehicle;
            DatetimeOut = datetimeOut;
            Username = username;
            PlateNumber = plateNumber;
            TotalFare = totalFare;
            IpAddress = ipAddress;
            PaymentMethod = paymentMethod;
            BankCode = bankCode;
            Image = image;
        }
    }
}
