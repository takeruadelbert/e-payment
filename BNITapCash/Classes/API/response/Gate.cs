using Newtonsoft.Json;

namespace BNITapCash.API.response
{
    class Gate
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("ipv4")]
        public string IpAddress;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("link_snapshot")]
        public string SnapshotUri;

        [JsonProperty("link_rts")]
        public string RtspUri;

        [JsonProperty("enable_webcam")]
        public bool WebcamEnabled;

        [JsonProperty("webcam_width")]
        public int WebcamWidth;

        [JsonProperty("webcam_height")]
        public int WebcamHeight;

        public Gate(int id, string name, string ipAddress, string type, string snapshotUri, string rtspUri, bool webcamEnabled, int webcamWidth, int webcamHeight)
        {
            Id = id;
            Name = name;
            IpAddress = ipAddress;
            Type = type;
            SnapshotUri = snapshotUri;
            RtspUri = rtspUri;
            WebcamEnabled = webcamEnabled;
            WebcamWidth = webcamWidth;
            WebcamHeight = webcamHeight;
        }
    }
}
