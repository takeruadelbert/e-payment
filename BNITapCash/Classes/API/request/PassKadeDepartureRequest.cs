using Newtonsoft.Json;

namespace BNITapCash.Classes.API.request
{
    class PassKadeDepartureRequest
    {
        [JsonProperty("type")]
        public string UidType;

        [JsonProperty("uid")]
        public string Uid;

        [JsonProperty("vehicle")]
        public string VehicleType;

        [JsonProperty("waktu_berangkat")]
        public string DepartureDatetime;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("plate_number")]
        public string PlateNumber;

        [JsonProperty("vehicle_fare")]
        public int VehicleFare;

        [JsonProperty("cargo_fare")]
        public int CargoFare;

        [JsonProperty("cargo_type")]
        public string CargoType;

        [JsonProperty("ipv4")]
        public string IpAddress;

        [JsonProperty("payment_method")]
        public string PaymentMethod;

        [JsonProperty("bank_code")]
        public string BankCode;

        [JsonProperty("image")]
        public string Base64WebcamImage;

        [JsonProperty("camera_image")]
        public string Base64IpCameraImage;

        public PassKadeDepartureRequest(string uidType, string uid, string vehicleType, string departureDatetime, string username, string plateNumber, int vehicleFare, int cargoFare,
            string cargoType, string ipAddress, string paymentMethod, string bankCode, string base64Webcam, string base64IpCamera)
        {
            UidType = uidType;
            Uid = uid;
            VehicleType = vehicleType;
            DepartureDatetime = departureDatetime;
            Username = username;
            PlateNumber = plateNumber;
            VehicleFare = vehicleFare;
            CargoFare = cargoFare;
            CargoType = cargoType;
            IpAddress = ipAddress;
            PaymentMethod = paymentMethod;
            BankCode = bankCode;
            Base64WebcamImage = base64Webcam;
            Base64IpCameraImage = base64IpCamera;
        }
    }
}
