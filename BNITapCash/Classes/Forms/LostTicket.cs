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
                string masterDataFile = TKHelper.GetApplicationExecutableDirectoryName() + Constant.PATH_FILE_MASTER_DATA_PARKING_OUT;
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
                notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Error", Constant.ERROR_MESSAGE_FAIL_TO_FETCH_VEHICLE_TYPE_DATA, ToolTipIcon.Error);
            }
        }

        private void InitLiveCamera()
        {
            CameraHelper.StartIpCamera(liveCamera);
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
            CameraHelper.StopIpCamera(liveCamera);
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
                    notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Warning", response.Message, ToolTipIcon.Warning);
                }
            }
            else
            {
                notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Error", Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_SERVER, ToolTipIcon.Error);
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
                notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Warning", Constant.WARNING_MESSAGE_VEHICLE_TYPE_NOT_EMPTY, ToolTipIcon.Warning);
                return false;
            }
            if (nomor_plat.Text.ToLower() == "nomor plat kendaraan" || nomor_plat.Text == "")
            {
                notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Warning", Constant.WARMING_MESSAGE_PLATE_NUMBER_NOT_EMPTY, ToolTipIcon.Warning);
                return false;
            }
            if (waktu_keluar.Text == "- - -  00:00:00")
            {
                notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Warning", Constant.WARNING_MESSAGE_DATETIME_LEAVE_NOT_EMPTY, ToolTipIcon.Warning);
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
                    string base64WebcamImage = CameraHelper.CaptureWebcamImage(camera, webcamImage);
                    string base64LiveCameraSnapshotImage = CameraHelper.SnapshotLiveCamera();
                    if (!string.IsNullOrEmpty(base64LiveCameraSnapshotImage))
                    {
                        ParkingOut parkingOut = SendDataToServer(base64WebcamImage, base64LiveCameraSnapshotImage, paymentMethod, totalFare);
                        StoreDataToDatabase(responseDeduct, parkingOut);
                        notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Success", Constant.TRANSACTION_SUCCESS, ToolTipIcon.Info);
                        Clear();
                    }
                }
                else
                {
                    notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Error", responseDeduct.Message, ToolTipIcon.Error);
                }
            }
            else
            {
                string base64WebcamImage = CameraHelper.CaptureWebcamImage(camera, webcamImage);
                string base64LiveCameraSnapshotImage = CameraHelper.SnapshotLiveCamera();
                if (!string.IsNullOrEmpty(base64LiveCameraSnapshotImage))
                {
                    SendDataToServer(base64WebcamImage, base64LiveCameraSnapshotImage, paymentMethod, totalFare);
                    notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Success", Constant.TRANSACTION_SUCCESS, ToolTipIcon.Info);
                    Clear();
                }
            }
        }

        private ParkingOut SendDataToServer(string webcamCapturedImage, string liveCameraSnapshotImage, string paymentMethod, int totalFare)
        {
            string vehicle = tipe_kendaraan.SelectedItem.ToString();
            string username = Properties.Settings.Default.Username;
            string datetimeOut = TKHelper.ConvertDatetimeToDefaultFormat(waktu_keluar.Text.ToString());
            string plateNumber = nomor_plat.Text.ToString();
            string ipAddress = TKHelper.GetLocalIPAddress();

            LostTicketRequest lostTicketRequest = new LostTicketRequest(vehicle, username, datetimeOut, totalFare, plateNumber, ipAddress, paymentMethod, webcamCapturedImage, liveCameraSnapshotImage);
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
                    notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Warning", response.Message, ToolTipIcon.Warning);
                    return null;
                }
            }
            else
            {
                notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Error", Constant.ERROR_MESSAGE_INVALID_RESPONSE_FROM_SERVER, ToolTipIcon.Error);
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
                notifyIcon.ShowBalloonTip(Constant.NOTIFICATION_TRAY_TIMEOUT, "Error", ex.Message, ToolTipIcon.Error);
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
