using BNITapCash.API;
using BNITapCash.API.request;
using BNITapCash.API.response;
using BNITapCash.Bank.BNI;
using BNITapCash.Bank.DataModel;
using BNITapCash.Classes.Helper;
using BNITapCash.ConstantVariable;
using BNITapCash.DB;
using BNITapCash.Helper;
using BNITapCash.Interface;
using BNITapCash.Miscellaneous.Webcam;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BNITapCash.Forms
{
    public partial class LostTicket : Form, EventFormHandler
    {
        private RESTAPI restApi;
        private string ipAddressServer;
        private Login home;
        public PictureBox webcamImage;
        private Webcam camera;
        private BNI bni;
        private DBConnect database;

        public LostTicket(Login home)
        {
            InitializeComponent();
            this.home = home;
            this.webcamImage = webcam;
            this.camera = new Webcam(this);
            this.bni = new BNI();
            this.database = new DBConnect();
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
            nonCash.Checked = true;
        }

        private void InitVehicleType()
        {
            try
            {
                tipe_kendaraan.Items.Add("- Pilih Tipe Kendaraan -");
                string masterDataFile = TKHelper.GetApplicationExecutableDirectoryName() + "\\src\\master-data.json";
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
            IpCameraHelper.StartCamera(liveCamera);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void Clear()
        {
            waktu_keluar.Text = "- - -  00:00:00";
            nomor_plat.Text = "Nomor Plat Kendaraan";
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
            IpCameraHelper.StopCamera(liveCamera);
            database.DisposeDatabaseConnection();
            Cashier cashier = new Cashier(home);
            cashier.Show();
            Dispose();
            UnsubscribeEvents();            
            TKHelper.ClearGarbage();
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
                    txtGrandTotal.Text = TKHelper.IDR(chargeFare);
                    string datetimeOut = fineFare.DatetimeOut.ToString();
                    string[] temp_dt_out = datetimeOut.Split(' ');
                    waktu_keluar.Text = TKHelper.ConvertDatetime(temp_dt_out[0], temp_dt_out[1]);
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
                SaveDataLostTicket();
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

        private void SaveDataLostTicket()
        {
            int totalFare = TKHelper.IDRToNominal(txtGrandTotal.Text.ToString());
            string paymentMethod = cash.Checked ? "CASH" : "NCSH";
            if (paymentMethod == "NCSH")
            {
                string bankCode = "BNI";
                string ipv4 = TKHelper.GetLocalIPAddress();
                string TIDSettlement = Properties.Settings.Default.TID;
                string operator_name = Properties.Settings.Default.Username;

                DataDeduct responseDeduct = bni.DeductBalance(bankCode, ipv4, TIDSettlement, operator_name);
                if (!responseDeduct.IsError)
                {
                    string base64WebcamImage = CaptureWebcamImage();
                    if (!string.IsNullOrEmpty(base64WebcamImage))
                    {
                        ParkingOut parkingOut = SendDataToServer(base64WebcamImage, paymentMethod, totalFare);
                        StoreDataToDatabase(responseDeduct, parkingOut);
                        MessageBox.Show(Constant.TRANSACTION_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                else
                {
                    MessageBox.Show(responseDeduct.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string base64WebcamImage = CaptureWebcamImage();
                if (!string.IsNullOrEmpty(base64WebcamImage))
                {
                    SendDataToServer(base64WebcamImage, paymentMethod, totalFare);
                    MessageBox.Show(Constant.TRANSACTION_SUCCESS, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
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
            System.Threading.Thread.Sleep(Constant.DELAY_TIME_WEBCAM);
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

        private ParkingOut SendDataToServer(string webcamCapturedImage, string paymentMethod, int totalFare)
        {
            string vehicle = tipe_kendaraan.SelectedItem.ToString();
            string username = Properties.Settings.Default.Username;
            string datetimeOut = TKHelper.ConvertDatetimeToDefaultFormat(waktu_keluar.Text.ToString());
            string plateNumber = nomor_plat.Text.ToString();
            string ipAddress = TKHelper.GetLocalIPAddress();

            LostTicketRequest lostTicketRequest = new LostTicketRequest(vehicle, username, datetimeOut, totalFare, plateNumber, ipAddress, paymentMethod, webcamCapturedImage);
            var payload = JsonConvert.SerializeObject(lostTicketRequest);

            string lostTicketApiUrl = Properties.Resources.LostTicketAPIURL;

            DataResponseObject response = (DataResponseObject)restApi.post(ipAddressServer, lostTicketApiUrl, true, payload);
            if (response != null)
            {
                if (response.Status == 206)
                {
                    return JsonConvert.DeserializeObject<ParkingOut>(response.Data.ToString());
                }
                else
                {
                    MessageBox.Show(response.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }
            else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_INVALID_RESPONSE_FROM_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void StoreDataToDatabase(DataDeduct dataDeduct, ParkingOut parkingOut)
        {
            try
            {
                // store deduct result card to server
                string result = dataDeduct.DeductResult;
                int amount = dataDeduct.Amount;
                string created = dataDeduct.CreatedDatetime;
                string bank = dataDeduct.Bank;
                string ipv4 = dataDeduct.IpAddress;
                string operatorName = dataDeduct.OperatorName;
                string idReader = dataDeduct.IdReader;
                int parkingOutId = parkingOut.ParkingOutId;

                string query = "INSERT INTO deduct_card_results (parking_out_id, result, amount, transaction_dt, bank, ipv4, operator, ID_reader, created) VALUES('" + parkingOutId + "', '" +
                    result + "', '" + amount + "', '" + created + "', '" + bank + "', '" + ipv4 + "', '" + operatorName + "', '" + idReader + "', '" + created + "')";

                database.Insert(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void UnsubscribeEvents()
        {
            tipe_kendaraan.SelectionChangeCommitted -= tipe_kendaraan_SelectionChangeCommitted;
            nomor_plat.Click -= nomor_plat_Click;
            nomor_plat.TextChanged -= nomor_plat_TextChanged;
            btnLsTicketClear.Click -= btnLsTicketClear_Click;
            btnLsTicketSave.Click -= btnLsTicketSave_Click;
            btnMinimize.Click -= btnMinimize_Click;
            btnClose.Click -= btnClose_Click;
            buttonBackToCashier.Click -= back_to_cashier_Click;
        }
    }
}
