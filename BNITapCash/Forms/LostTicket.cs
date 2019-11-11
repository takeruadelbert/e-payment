using AForge.Video;
using BNITapCash.API;
using BNITapCash.API.request;
using BNITapCash.API.response;
using BNITapCash.ConstantVariable;
using BNITapCash.Helper;
using BNITapCash.Miscellaneous.Webcam;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BNITapCash.Forms
{
    public partial class LostTicket : Form
    {
        private TKHelper helper;
        private readonly string liveCameraURL = Constant.URL_PROTOCOL + Properties.Settings.Default.IPAddressLiveCamera + "/snapshot";
        private JPEGStream stream;
        private RESTAPI restApi;
        private string ipAddressServer;
        private Login home;
        public PictureBox webcamImage;
        private Webcam camera;

        public LostTicket(Login home)
        {
            InitializeComponent();
            this.home = home;
            this.webcamImage = webcam;
            this.camera = new Webcam(this);
            helper = new TKHelper();
            restApi = new RESTAPI();
            ipAddressServer = Properties.Settings.Default.IPAddressServer;
            InitData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constant.CONFIRMATION_MESSAGE_BEFORE_EXIT, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Dispose();
                System.Environment.Exit(1);
            }
        }

        private void InitData()
        {
            InitVehicleType();
            InitLiveCamera();
            cash.Checked = true;
        }

        private void InitVehicleType()
        {
            try
            {
                tipe_kendaraan.Items.Add("- Pilih Tipe Kendaraan -");
                string masterDataFile = this.helper.GetApplicationExecutableDirectoryName() + "\\src\\master-data.json";
                using (StreamReader reader = new StreamReader(masterDataFile))
                {
                    string json = reader.ReadToEnd();
                    dynamic vehicleTypes = JsonConvert.DeserializeObject(json);
                    foreach (var types in vehicleTypes["VehicleTypes"])
                    {
                        tipe_kendaraan.Items.Add(types);
                    }
                    tipe_kendaraan.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_FETCH_VEHICLE_TYPE_DATA, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitLiveCamera()
        {
            try
            {
                stream = new JPEGStream(liveCameraURL);
                stream.NewFrame += stream_NewFrame;
                stream.Login = Properties.Settings.Default.LiveCameraUsername;
                stream.Password = Properties.Settings.Default.LiveCameraPassword;
                stream.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_LIVE_CAMERA, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LiveCamera.Image = Properties.Resources.no_image;
            }
        }

        private void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            LiveCamera.Image = bmp;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void Clear()
        {
            waktu_keluar.Text = "- - -  00:00:00";
            txtGrandTotal.Text = "0";
            cash.Checked = true;
            ResetComboBox();
        }

        private void ResetComboBox()
        {
            tipe_kendaraan.SelectedIndex = 0;
            tipe_kendaraan.ResetText();
            tipe_kendaraan.SelectedText = "- Pilih Tipe Kendaraan -";
        }

        private void back_to_cashier_Click(object sender, EventArgs e)
        {
            stream.Stop();
            Cashier cashier = new Cashier(home);
            cashier.Show();
            Hide();
        }

        private void tipe_kendaraan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tipe_kendaraan.SelectedIndex != 0)
            {
                RequestFineFarePerVehicle(tipe_kendaraan.SelectedItem.ToString());
            }
        }

        private void RequestFineFarePerVehicle(string vehicle)
        {
            string requestFineApiUrl = Properties.Resources.RequestFineFareAPIURL;
            FineFareRequest fineFareRequest = new FineFareRequest(vehicle);
            var payload = JsonConvert.SerializeObject(fineFareRequest);
            DataResponseObject response = (DataResponseObject)restApi.post(ipAddressServer, requestFineApiUrl, true, payload);
            if (response != null)
            {
                if (response.Status == 206)
                {
                    FineFare fineFare = JsonConvert.DeserializeObject<FineFare>(response.Data.ToString());
                    string chargeFare = fineFare.ChargeFare.ToString();
                    txtGrandTotal.Text = helper.IDR(chargeFare);
                    string datetimeOut = fineFare.DatetimeOut.ToString();
                    string[] temp_dt_out = datetimeOut.Split(' ');
                    waktu_keluar.Text = helper.ConvertDatetime(temp_dt_out[0], temp_dt_out[1]);
                }
                else
                {
                    MessageBox.Show(response.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nomor_plat_TextChanged(object sender, EventArgs e)
        {
            TextListener("nomor plat kendaraan", true);
            nomor_plat.CharacterCasing = CharacterCasing.Upper;
        }

        private void nomor_plat_Click(object sender, EventArgs e)
        {
            if (nomor_plat.Text.ToLower() == "nomor plat kendaraan")
                this.TextListener("nomor plat kendaraan");
        }

        private void TextListener(string field, bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (field == "nomor plat kendaraan")
                {
                    nomor_plat.Clear();
                }
            }
            nomor_plat.ForeColor = Color.FromArgb(78, 184, 206);
            nomor_plat.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void btnLsTicketClear_Click(object sender, EventArgs e)
        {
            Clear();
        }


        private void btnLsTicketSave_Click(object sender, EventArgs e)
        {
            if (ValidateLostTicket())
            {
                string base64WebcamImage = CaptureWebcamImage();
                if (!string.IsNullOrEmpty(base64WebcamImage))
                {
                    SaveDataLostTicket(base64WebcamImage);
                }
            }
        }

        private bool ValidateLostTicket()
        {
            if (tipe_kendaraan.SelectedIndex == 0)
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_VEHICLE_TYPE_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (nomor_plat.Text.ToLower() == "nomor plat kendaraan" || nomor_plat.Text == "")
            {
                MessageBox.Show(Constant.WARMING_MESSAGE_PLATE_NUMBER_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (waktu_keluar.Text == "- - -  00:00:00")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_DATETIME_LEAVE_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void SaveDataLostTicket(string capturedImage)
        {
            string vehicle = tipe_kendaraan.SelectedItem.ToString();
            string username = Properties.Settings.Default.Username;
            string datetimeOut = helper.ConvertDatetimeToDefaultFormat(waktu_keluar.Text.ToString());
            int totalFare = helper.IDRToNominal(txtGrandTotal.Text.ToString());
            string plateNumber = nomor_plat.Text.ToString();
            string ipAddress = helper.GetLocalIPAddress();
            string paymentMethod = cash.Checked ? "CASH" : "NCSH";
            string webcamCapturedImage = capturedImage;
            LostTicketRequest lostTicketRequest = new LostTicketRequest(vehicle, username, datetimeOut, totalFare, plateNumber, ipAddress, paymentMethod, webcamCapturedImage);
            var payload = JsonConvert.SerializeObject(lostTicketRequest);

            string lostTicketApiUrl = Properties.Resources.LostTicketAPIURL;

            DataResponseObject response = (DataResponseObject)restApi.post(ipAddressServer, lostTicketApiUrl, true, payload);
            if (response != null)
            {
                if (response.Status == 206)
                {
                    ParkingOut parkingOut = JsonConvert.DeserializeObject<ParkingOut>(response.Data.ToString());
                    MessageBox.Show(Constant.TRANSACTION_SUCCESS, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(response.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_INVALID_RESPONSE_FROM_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CaptureWebcamImage()
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
            System.Threading.Thread.Sleep(Constant.DELAY_TIME_START_WEBCAM);
            if (webcamImage.Image == null)
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_WEBCAM_SNAPSHOOT_FAILED, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                camera.StopWebcam();
                return null;
            }
            camera.StopWebcam();
            Bitmap bmp = new Bitmap(webcamImage.Image, Properties.Settings.Default.WebcamWidth, Properties.Settings.Default.WebcamHeight);
            return bmp.ToBase64String(ImageFormat.Png);
        }
    }
}
