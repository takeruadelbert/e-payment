using Newtonsoft.Json;
using System.Collections.Generic;

namespace BNITapCash.Classes.API.request
{
    class PedestrianRequest
    {
        [JsonProperty("pedestrian")]
        private List<DataPedestrianTypeQuantity> DataPedestrianList;

        [JsonProperty("ipv4")]
        private string IpAddress;

        [JsonProperty("waktu_datang")]
        private string DatetimeIn;

        [JsonProperty("username")]
        private string Username;

        [JsonProperty("cargo_fare")]
        private int CargoFare;

        [JsonProperty("cargo_type")]
        private string CargoType;

        [JsonProperty("payment_method")]
        private string PaymentMethod;

        [JsonProperty("bank_code")]
        private string BankCode;

        public PedestrianRequest(List<DataPedestrianTypeQuantity> dataPedestrian, string ipv4, string datetimeIn, string username, int cargoFare, string cargoType,
            string paymentMethod, string bankCode)
        {
            DataPedestrianList = dataPedestrian;
            IpAddress = ipv4;
            DatetimeIn = datetimeIn;
            Username = username;
            CargoFare = cargoFare;
            CargoType = cargoType;
            PaymentMethod = paymentMethod;
            BankCode = bankCode;
        }
    }
}
