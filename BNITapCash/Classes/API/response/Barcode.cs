using BNITapCash.Classes.API.response;

namespace BNITapCash.API.response
{
    class Barcode : BaseResponse
    {
        public long id { get; set; }
        public string barcode { get; set; }
    }
}
