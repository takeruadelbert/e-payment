using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using BNITapCash.Forms;

namespace BNITapCash.Miscellaneous.Webcam
{
    class Webcam
    {
        private Cashier cashier;
        VideoCaptureDevice frame;
        FilterInfoCollection Devices;

        public Webcam(Cashier cashier)
        {
            this.cashier = cashier;
        }

        public void StartWebcam()
        {
            Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            frame = new VideoCaptureDevice(Devices[0].MonikerString);
            frame.NewFrame += new NewFrameEventHandler(NewFrame_event);
            frame.Start();
        }

        public void StopWebcam()
        {
            frame.Stop();
        }

        void NewFrame_event(object send, NewFrameEventArgs e)
        {
            try
            {
                this.cashier.webcamImage.Image = (Image)e.Frame.Clone();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
