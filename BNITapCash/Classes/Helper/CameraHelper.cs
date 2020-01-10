using BNITapCash.ConstantVariable;
using BNITapCash.Helper;
using BNITapCash.Miscellaneous.Webcam;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace BNITapCash.Classes.Helper
{
    public class CameraHelper
    {
        public static readonly string[] options = {
            ":network-caching:500"
        };
        private static readonly string SNAPSHOT_URI = Properties.Settings.Default.UriSnapshotLiveCamera;

        public static void StartIpCamera(VlcControl vlcControl)
        {
            string uri = Properties.Settings.Default.UriAddressLiveCamera;
            vlcControl.Play(new Uri(uri), options);
        }

        public static void StopIpCamera(VlcControl vlcControl)
        {
            vlcControl.Stop();
            vlcControl.Dispose();
        }

        public static string SnapshotLiveCamera()
        {
            int liveCameraWidth = Properties.Settings.Default.LiveCameraWidth;
            int liveCameraHeight = Properties.Settings.Default.LiveCameraHeight;
            try
            {
                HttpWebRequest request = WebRequest.Create(SNAPSHOT_URI) as HttpWebRequest;
                Bitmap bitmap;
                using (Stream stream = request.GetResponse().GetResponseStream())
                {
                    Image image = Image.FromStream(stream);
                    bitmap = new Bitmap(image, liveCameraWidth, liveCameraHeight);
                    return bitmap.ToBase64String(ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(Constant.ERROR_MESSAGE_SNAPSHOT_FAILED, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static string CaptureWebcamImage(Webcam camera, PictureBox webcamImage)
        {
            if (Properties.Settings.Default.WebcamEnabled)
            {
                try
                {
                    camera.StartWebcam();
                }
                catch (Exception)
                {
                    MessageBox.Show(Constant.ERROR_MESSAGE_WEBCAM_TROUBLE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                System.Threading.Thread.Sleep(Constant.DELAY_TIME_WEBCAM);
                if (webcamImage.Image == null)
                {
                    MessageBox.Show(Constant.ERROR_MESSAGE_WEBCAM_SNAPSHOOT_FAILED, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    camera.StopWebcam();
                    return null;
                }
                else
                {
                    camera.StopWebcam();
                    Bitmap bmp = new Bitmap(webcamImage.Image, Properties.Settings.Default.WebcamWidth, Properties.Settings.Default.WebcamHeight);
                    return bmp.ToBase64String(ImageFormat.Jpeg);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
