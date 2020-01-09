using System;
using Vlc.DotNet.Forms;

namespace BNITapCash.Classes.Helper
{
    public class IpCameraHelper
    {
        public static readonly string[] options = {
            ":network-caching:500"
        };

        public static void StartCamera(VlcControl vlcControl)
        {
            string uri = Properties.Settings.Default.UriAddressLiveCamera;
            vlcControl.Play(new Uri(uri), options);
        }

        public static void StopCamera(VlcControl vlcControl)
        {
            vlcControl.Stop();
            vlcControl.Dispose();
        }
    }
}
