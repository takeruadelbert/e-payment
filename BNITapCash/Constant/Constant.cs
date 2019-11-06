namespace BNITapCash.ConstantVariable
{
    class Constant
    {
        // common
        public static readonly string BREAKLINE = "\n";
        public static readonly string WHITESPACE = " ";
        public static readonly string APP_NAME = "E-Payment";

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
        public static readonly string MESSAGE_WAITING_CARD = "Waiting Card ...";
        public static readonly string MESSAGE_SUCCESS_DEDUCT = "Success ...";

        public static readonly string ERROR_FAIL_TO_READ_LIST_READER = "Fail to read list reader.";
        public static readonly string ERROR_FAIL_TO_READ_UID_CARD = "Cannot Read UID Card.";
        public static readonly string ERROR_FAIL_TO_ESTABLISH_CONTEXT = "Check your device and please restart again.";
        public static readonly string ERROR_FAIL_PROCESS = "Fail to Process.";
        public static readonly string ERROR_MESSAGE_INSUFFICIENT_BALANCE = "Insufficient Bal";

        // BNI
        public static readonly string MESSAGE_OK = "OK";
        public static readonly string MESSAGE_INTIALIZING_SAM = "Initializing SAM ...";
        public static readonly string MESSAGE_SAM_ALREADY_INITIALIZED = "SAM has already been initialized.";
        public static readonly string ERROR_MESSAGE_FAILED_INITIALIZE_SAM = "Failed to Initialize SAM : No Reader found or selected.";
        public static readonly string ERROR_MESSAGE_FAILED_GET_SAM_STATUS = "Failed to Get SAM Status : No Reader found or selected.";
        public static readonly string ERROR_MESSAGE_CANNOT_DEDUCT_INSUFFICIENT_BALANCE = "Can't Deduct : Insufficient Balance.";
        
    }
}
