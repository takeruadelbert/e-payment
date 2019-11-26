using Newtonsoft.Json;

namespace BNITapCash.API.request
{
    class PrintReportRequest
    {
        [JsonProperty("username")]
        private string Username { get; set; }

        public PrintReportRequest(string username)
        {
            Username = username;
        }
    }
}
