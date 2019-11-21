using AForge.Video;
using AForge.Video.DirectShow;
using BNITapCash.Forms;
using System;
using System.Drawing;

namespace BNITapCash.Miscellaneous.Webcam
{
    public class Webcam
    {
        private Cashier cashier;
        private LostTicket lostTicket;
        private static FilterInfoCollection Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice frame = new VideoCaptureDevice(Devices[0].MonikerString);
        private static bool hasCaptured = false;

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

            frame.NewFrame += new NewFrameEventHandler(NewFrame_event);
            frame.Start();
            while (true)
            {
                if (hasCaptured == true)
                {
                    // give delay until webcam has snapshot.
                    break;
                }
            }
        }

        public void StopWebcam()
        {
            try
            {
                frame.Stop();
                frame.NewFrame -= new NewFrameEventHandler(NewFrame_event);
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
                hasCaptured = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
