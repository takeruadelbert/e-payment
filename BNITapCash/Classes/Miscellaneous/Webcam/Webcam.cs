using AForge.Video;
using AForge.Video.DirectShow;
using BNITapCash.Classes.Forms;
using BNITapCash.Forms;
using System;
using System.ComponentModel;
using System.Drawing;

namespace BNITapCash.Miscellaneous.Webcam
{
    public class Webcam
    {
        private Cashier cashier;
        private LostTicket lostTicket;
        private FreePass freePass;
        private PassKadeIn passKadeIn;
        private PassKadeOut passKadeOut;
        private static FilterInfoCollection Devices;
        private VideoCaptureDevice frame;
        private static bool hasCaptured = false;

        public Webcam(Cashier cashier)
        {
            this.cashier = cashier;
            InitializeWebcam();
        }

        public Webcam(LostTicket lostTicket)
        {
            this.lostTicket = lostTicket;
            InitializeWebcam();
        }

        public Webcam(FreePass freePass)
        {
            this.freePass = freePass;
            InitializeWebcam();
        }

        public Webcam(PassKadeIn passKadeIn)
        {
            this.passKadeIn = passKadeIn;
            InitializeWebcam();
        }

        public Webcam(PassKadeOut passKadeOut)
        {
            this.passKadeOut = passKadeOut;
            InitializeWebcam();
        }

        [Description("retry to connect the webcam device in case user just plugged it")]
        private void InitializeWebcam()
        {
            try
            {
                Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                frame = new VideoCaptureDevice(Devices[0].MonikerString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                frame = new VideoCaptureDevice(Devices[0].MonikerString);
            }
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
                else if (lostTicket != null)
                {
                    lostTicket.webcamImage.Image = (Image)e.Frame.Clone();
                }
                else if (passKadeIn != null)
                {
                    passKadeIn.webcamImage.Image = (Image)e.Frame.Clone();
                }
                else if (passKadeOut != null)
                {
                    passKadeOut.webcamImage.Image = (Image)e.Frame.Clone();
                }
                else
                {
                    freePass.webcamImage.Image = (Image)e.Frame.Clone();
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
