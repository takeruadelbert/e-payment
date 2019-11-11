using AForge.Video;
using AForge.Video.DirectShow;
using BNITapCash.Forms;
using System;
using System.Drawing;

namespace BNITapCash.Miscellaneous.Webcam
{
    class Webcam
    {
        private Cashier cashier;
        private LostTicket lostTicket;

        VideoCaptureDevice frame;
        FilterInfoCollection Devices;

        public Webcam(Cashier cashier)
        {
            this.cashier = cashier;
        }

        public Webcam(LostTicket lostTicket)
        {
            this.lostTicket = lostTicket;
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
            try
            {
                frame.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        void NewFrame_event(object send, NewFrameEventArgs e)
        {
            try
            {
                if (cashier != null)
                {
                    cashier.webcamImage.Image = (Image)e.Frame.Clone();
                }
                else
                {
                    lostTicket.webcamImage.Image = (Image)e.Frame.Clone();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
