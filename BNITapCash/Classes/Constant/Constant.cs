namespace BNITapCash.ConstantVariable
{
    class Constant
    {
        // common
        public static readonly string BREAKLINE = "\n";
        public static readonly string WHITESPACE = " ";
        public static readonly string APP_NAME = "E-Payment";
        public static readonly string LOCALHOST_VALUE = "localhost";
        public static readonly string CONFIRMATION_MESSAGE_BEFORE_EXIT = "Are you sure you want to exit?";
        public static readonly int BARCODE_LENGTH = 16;
        public static readonly int DELAY_TIME_WEBCAM = 1000; // in milliseconds
        public static readonly string URL_PROTOCOL = "http://";

        // error message
        public static readonly string ERROR_MESSAGE_FAIL_TO_WRITE_MASTER_DATA_FILE = "Fail to Write Master Data File.";
        public static readonly string ERROR_MESSAGE_FAIL_TO_SAVE_DATA_INTO_LOCAL_SERVER = "Error : Fail to Save Data Into Local Server.";

        // validation
        public static readonly string WARNING_MESSAGE_USERNAME_NOT_EMPTY = "Username Harus Diisi.";
        public static readonly string WARNING_MESSAGE_PASSWORD_NOT_EMPTY = "Password Harus Diisi.";
        public static readonly string WARNING_MESSAGE_HOST_NOT_EMPTY = "Host Harus Diisi.";
        public static readonly string WARNING_MESSAGE_DATABASE_NAME_NOT_EMPTY = "Field 'Database Name' Harus Diisi.";
        public static readonly string WARNING_MESSAGE_IP_ADDRESS_SERVER_NOT_EMPTY = "IP Address Server Harus Diisi.";
        public static readonly string WARNING_MESSAGE_IP_ADDRESS_LIVE_CAMERA_NOT_EMPTY = "IP Address Live Camera Harus Diisi.";
        public static readonly string WARNING_MESSAGE_TID_NOT_EMPTY = "TID Harus Diisi.";
        public static readonly string WARNING_MESSAGE_MID_NOT_EMPTY = "Settlement MID Harus Diisi.";
        public static readonly string WARMING_MESSAGE_PLATE_NUMBER_NOT_EMPTY = "Field 'Nomor Plat Kendaraan' Harus Diisi.";
        public static readonly string WARNING_MESSAGE_DATETIME_LEAVE_NOT_EMPTY = "Field 'Waktu Keluar' Kosong.";
        public static readonly string WARNING_MESSAGE_UID_CARD_NOT_EMPTY = "Field 'UID Card' Harus Diisi.";
        public static readonly string WARNING_MESSAGE_VEHICLE_TYPE_NOT_EMPTY = "Field 'Tipe Kendaraan' Harus Dipilih.";
        public static readonly string WARNING_MESSAGE_INVALID_IP_ADDRESS_SERVER = "Invalid IP Address Server.";
        public static readonly string WARNING_MESSAGE_INVALID_IP_ADDRESS_LIVE_CAMERA = "Invalid IP Address Live Camera.";
        public static readonly string WARNING_MESSAGE_INVALID_TID = "Invalid 'TID' value.";
        public static readonly string WARNING_MESSAGE_INVALID_MID = "Invalid 'MID' value.";
        public static readonly string WARNING_MESSAGE_INVALID_HOST = "Invalid Host.";
        public static readonly string WARNING_MESSAGE_UNTAPPED_CARD = "Silahkan Tap Kartunya Terlebih Dahulu.";
        public static readonly string WARNING_MESSAGE_BARCODE_NOT_EMPTY = "Field 'Barcode' Harus Diisi.";
        public static readonly string WARNING_MESSAGE_OUTLOAD_NOT_EMPTY = "Field 'Tarif Muatan' Harus Dipilih.";
        public static readonly string WARNING_MESSAGE_NO_DETAIL_DATA_YET = "Tidak Ada Data Tarif.";

        public static readonly string DATABASE_CONFIG_VALIDATION_SUCCESS = "Konfigurasi Database Berhasil Diupdate.";
        public static readonly string SETTING_UPDATE_SUCCESS = "Setting Berhasil Diupdate.";

        // API
        public static readonly string ERROR_MESSAGE_FAIL_TO_CONNECT_LOCAL_DATABASE = "Error : Can't Establish Connection to Local Database." + BREAKLINE + "Please setup properly.";
        public static readonly string ERROR_MESSAGE_FAIL_TO_CONNECT_SERVER = "Error : Can't establish connection to server.";
        public static readonly string ERROR_MESSAGE_FAIL_TO_FETCH_VEHICLE_TYPE_DATA = "Error : failed to fetch vehicle type data.";
        public static readonly string ERROR_MESSAGE_FAIL_TO_FETCH_OUTLOAD = "Error : failed to fetch data outload.";
        public static readonly string ERROR_MESSAGE_FAIL_TO_FETCH_PEDESTRIAN_DATA = "Error : failed to fetch pedestrian type data.";
        public static readonly string ERROR_MESSAGE_INVALID_RESPONSE_FROM_SERVER = "Error found when receiving server response.";
        public static readonly string ERROR_MESSAGE_INVALID_GATE = "Gate Tidak Terdaftar di Server.";        

        public static readonly string STATUS_CONNECTION_ESTABLISH = "Connection Established.";
        public static readonly string REPRINT_TICKET_SUCCESS = "Print Ulang Tiket Berhasil.";
        public static readonly string PRINT_REPORT_OPERATOR_SUCCESS = "Print Report Sukses.";

        // reader device attributes
        public static readonly byte LED_BLUE = 0x01;
        public static readonly byte LED_ORANGE = 0x02;
        public static readonly byte LED_GREEN = 0x04;
        public static readonly byte LED_RED = 0x08;
        public static readonly byte LED_ANT_RED = 0x10;
        public static readonly byte LED_ANT_GREEN = 0x20;
        public static readonly byte LED_ANT_BLUE = 0x40;

        public static readonly string READER_NAME = "ACS ACR123U-A1";
        public static readonly string CARD_INSERTED = "Card inserted.";
        public static readonly string CARD_REMOVED = "Card removed.";
        public static readonly string MESSAGE_PROCESSING = "Processing ...";
        public static readonly string MESSAGE_SCANNING = "Scanning ...";
        public static readonly string MESSAGE_WAITING_CARD = "Waiting Card ...";
        public static readonly string MESSAGE_SUCCESS_DEDUCT = "Success ...";

        public static readonly string ERROR_MESSAGE_DEVICE_READER_NOT_FOUND = "Error : Contactless Reader not available." + BREAKLINE + "Please plug it and then try again.";
        public static readonly string ERROR_FAIL_TO_READ_LIST_READER = "Fail to read list reader.";
        public static readonly string ERROR_FAIL_TO_READ_UID_CARD = "Cannot Read UID Card.";
        public static readonly string ERROR_FAIL_TO_ESTABLISH_CONTEXT = "Check your device and please restart again.";
        public static readonly string ERROR_FAIL_PROCESS = "Fail to Process.";
        public static readonly string ERROR_MESSAGE_INSUFFICIENT_BALANCE = "Insufficient Bal";

        // web cam
        public static readonly string ERROR_MESSAGE_FAIL_TO_CONNECT_WEBCAM = "Error : Can't Connect to Webcam.";
        public static readonly string ERROR_MESSAGE_WEBCAM_TROUBLE = "Webcam Bermasalah : Pastikan Webcam dipasang dengan benar.";
        public static readonly string ERROR_MESSAGE_WEBCAM_SNAPSHOOT_FAILED = "Snapshoot Webcam Bermasalah.";

        // live camera
        public static readonly string ERROR_MESSAGE_FAIL_TO_CONNECT_LIVE_CAMERA = "Error : Cannot Connect to Live Camera.";
        public static readonly string ERROR_MESSAGE_SNAPSHOT_FAILED = "Fail to snapshoot IP Camera.";

        // miscellaneous
        public static readonly string DIR_PATH_SOURCE = @"\src";
        public static readonly string PATH_FILE_MASTER_DATA_PARKING_OUT = DIR_PATH_SOURCE + @"\master-data-parking-out.json";
        public static readonly string PATH_FILE_MASTER_DATA_PARKING_IN = DIR_PATH_SOURCE + @"\master-data-parking-in.json";

        // BNI
        public static readonly string MESSAGE_OK = "OK";
        public static readonly string MESSAGE_INTIALIZING_SAM = "Initializing SAM ...";
        public static readonly string MESSAGE_SAM_ALREADY_INITIALIZED = "SAM has already been initialized.";
        public static readonly string ERROR_MESSAGE_FAILED_INITIALIZE_SAM = "Failed to Initialize SAM : No Reader found or selected.";
        public static readonly string ERROR_MESSAGE_FAILED_GET_SAM_STATUS = "Failed to Get SAM Status : No Reader found or selected.";
        public static readonly string ERROR_MESSAGE_CANNOT_DEDUCT_INSUFFICIENT_BALANCE = "Can't Deduct : Insufficient Balance.";
        public static readonly string TRANSACTION_SUCCESS = "Transaksi Berhasil.";
        public static readonly string RC_CODE_LIST_FILE_PATH = DIR_PATH_SOURCE + @"\RC\BNIListRC.json";
    }
}
