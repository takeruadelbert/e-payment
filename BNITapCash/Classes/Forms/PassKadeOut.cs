using BNITapCash.API;
using BNITapCash.Bank.BNI;
using BNITapCash.Bank.DataModel;
using BNITapCash.Card.Mifare;
using BNITapCash.Classes.API.request;
using BNITapCash.Classes.API.response;
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

namespace BNITapCash.Classes.Forms
{
    public partial class PassKadeOut : Form, EventFormHandler
    {
        private Login home;
        private RESTAPI restApi;
        public PictureBox webcamImage;
        private Webcam camera;
        private BNI bni;
        private DBConnect database;
        private MifareCard mifareCard;

        private readonly string MasterDataFileParkingOut = TKHelper.GetApplicationExecutableDirectoryName() + Constant.PATH_FILE_MASTER_DATA_PARKING_OUT;
        private readonly string IpAddressServer = Properties.Settings.Default.IPAddressServer;
        private string datetimeOut = null;

        public PassKadeOut(Login home)
        {
            InitializeComponent();
            this.home = home;
            Initialize();
        }

        public void Initialize()
        {
            InitializeVehicleType();
            CameraHelper.StartIpCamera(liveCamera);
            this.webcamImage = webcam;
            if (Properties.Settings.Default.WebcamEnabled)
            {
                this.camera = new Webcam(this);
            }
            nonCash.Checked = true;
            this.restApi = new RESTAPI();
            this.database = new DBConnect();
            this.bni = new BNI();
            this.mifareCard = new MifareCard(this);
            this.mifareCard.RunMain();
        }

        private void InitializeVehicleType()
        {
            try
            {
                tipe_kendaraan.Items.Add("- Pilih Tipe Kendaraan -");
                using (StreamReader reader = new StreamReader(MasterDataFileParkingOut))
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

        private void tipe_kendaraan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tipe_kendaraan.SelectedIndex != 0)
            {
                var ApiUrl = Properties.Resources.RequestVehicleFarePassKadeOutApiUrl;
                string vehicleType = tipe_kendaraan.Text;
                PassKadeOutVehicleFareRequest passKadeOutVehicleFareRequest = new PassKadeOutVehicleFareRequest(vehicleType);
                var sentParam = JsonConvert.SerializeObject(passKadeOutVehicleFareRequest);

                DataResponseObject response = (DataResponseObject)restApi.post(IpAddressServer, ApiUrl, true, sentParam);
                if (response != null)
                {
                    if (response.Status == 206)
                    {
                        PassKadeOutVehicleFare passKadeOutVehicleFare = JsonConvert.DeserializeObject<PassKadeOutVehicleFare>(response.Data.ToString());
                        txtGrandTotal.Text = TKHelper.IDR(passKadeOutVehicleFare.Fare.ToString());
                        datetimeOut = passKadeOutVehicleFare.DatetimeOut.ToString();
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void nomor_plat_TextChanged(object sender, EventArgs e)
        {
            this.TextListener("nomor plat kendaraan", true);
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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            tipe_kendaraan.SelectedIndex = 0;
            txtGrandTotal.Text = "0";
            nomor_plat.Text = "Nomor Plat Kendaraan";
            datetimeOut = null;
            note.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string feedback = ValidateFields();
            if (feedback == Constant.MESSAGE_OK)
            {
                // check the payment method whether it's cash or non-cash
                int totalFare = TKHelper.IDRToNominal(txtGrandTotal.Text.ToString());
                string paymentMethod = nonCash.Checked ? "NCSH" : "CASH";

                if (paymentMethod == "NCSH")
                {
                    string bankCode = "BNI";
                    string ipv4 = TKHelper.GetLocalIPAddress();
                    string TIDSettlement = Properties.Settings.Default.TID;
                    string operator_name = Properties.Settings.Default.Username;

                    // need to disconnect SCard from WinsCard.dll beforehand in order to execute further actions to avoid 'Outstanding Connection' Exception.
                    mifareCard.disconnect();

                    DataDeduct responseDeduct = bni.DeductBalance(bankCode, ipv4, TIDSettlement, operator_name);
                    if (!responseDeduct.IsError)
                    {
                        string base64WebcamImage = CameraHelper.CaptureWebcamImage(camera, webcamImage);
                        string base64LiveCameraSnapshot = CameraHelper.SnapshotLiveCamera();
                        if (!string.IsNullOrEmpty(base64LiveCameraSnapshot))
                        {
                            PassKadeOutResponse passKadeOutResponse = SendDataToServer(totalFare, base64WebcamImage, base64LiveCameraSnapshot, paymentMethod, bankCode);
                            if (passKadeOutResponse != null)
                            {
                                StoreDataToDatabase(responseDeduct, passKadeOutResponse);
                                MessageBox.Show(Constant.TRANSACTION_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(responseDeduct.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string base64WebcamImage = CameraHelper.CaptureWebcamImage(camera, webcamImage);
                    string base4LiveCameraSnapshot = CameraHelper.SnapshotLiveCamera();
                    if (!string.IsNullOrEmpty(base4LiveCameraSnapshot))
                    {
                        PassKadeOutResponse passKadeOutResponse = SendDataToServer(totalFare, base64WebcamImage, base4LiveCameraSnapshot, paymentMethod);
                        if (passKadeOutResponse != null)
                        {
                            MessageBox.Show(Constant.TRANSACTION_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(feedback, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private PassKadeOutResponse SendDataToServer(int totalFare, string base64Image, string base64LiveCameraImage, string paymentMethod, string bankCode = "")
        {
            string vehicle = tipe_kendaraan.Text.ToString();
            string username = Properties.Settings.Default.Username;
            string plateNumber = nomor_plat.Text.ToString();
            string ipAddressLocal = TKHelper.GetLocalIPAddress();
            string noteValue = note.Text.ToString();
            PassKadeOutRequest passKadeOutRequest = new PassKadeOutRequest(vehicle, datetimeOut, username, plateNumber, totalFare, noteValue, ipAddressLocal, paymentMethod, bankCode, base64Image, base64LiveCameraImage);
            var sent_param = JsonConvert.SerializeObject(passKadeOutRequest);

            DataResponseObject response = (DataResponseObject)restApi.post(IpAddressServer, Properties.Resources.SaveDataPassKadeOutApiUrl, true, sent_param);
            if (response != null)
            {
                switch (response.Status)
                {
                    case 206:
                        return JsonConvert.DeserializeObject<PassKadeOutResponse>(response.Data.ToString());
                    default:
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

        private void StoreDataToDatabase(DataDeduct dataDeduct, PassKadeOutResponse passKadeOutResponse)
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
                int parkingOutId = passKadeOutResponse.ParkingOutId;

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

        private string ValidateFields()
        {
            if (nomor_plat.Text.ToLower() == "nomor plat kendaraan" || nomor_plat.Text == "")
            {
                return Constant.WARMING_MESSAGE_PLATE_NUMBER_NOT_EMPTY;
            }

            if (tipe_kendaraan.SelectedIndex == -1 || tipe_kendaraan.SelectedIndex == 0)
            {
                return Constant.WARNING_MESSAGE_VEHICLE_TYPE_NOT_EMPTY;
            }

            return Constant.MESSAGE_OK;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            CameraHelper.StopIpCamera(liveCamera);
            mifareCard.Stop();
            database.DisposeDatabaseConnection();
            Cashier cashier = new Cashier(home);
            cashier.Show();
            Hide();
            Dispose();
            UnsubscribeEvents();
            TKHelper.ClearGarbage();
        }

        public void UnsubscribeEvents()
        {
            tipe_kendaraan.SelectionChangeCommitted -= tipe_kendaraan_SelectionChangeCommitted;

            nomor_plat.Click -= nomor_plat_Click;
            nomor_plat.TextChanged -= nomor_plat_TextChanged;

            btnClose.Click -= btnClose_Click;
            btnMinimize.Click -= btnMinimize_Click;
            btnClear.Click -= btnClear_Click;
            btnSave.Click -= btnSave_Click;
        }
    }
}