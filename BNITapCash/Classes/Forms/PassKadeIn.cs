using BNITapCash.API;
using BNITapCash.API.response;
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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BNITapCash.Classes.Forms
{
    public partial class PassKadeIn : Form, EventFormHandler
    {
        private Login home;
        private RESTAPI restApi;
        private MifareCard mifareCard;
        private BNI bni;
        public PictureBox webcamImage;
        private Webcam camera;
        private DBConnect database;
        private readonly string MasterDataFileParkingIn = TKHelper.GetApplicationExecutableDirectoryName() + Constant.PATH_FILE_MASTER_DATA_PARKING_IN;
        private readonly string MasterDataFileParkingOut = TKHelper.GetApplicationExecutableDirectoryName() + Constant.PATH_FILE_MASTER_DATA_PARKING_OUT;
        private readonly string IpAddressServer = Properties.Settings.Default.IPAddressServer;

        private Dictionary<string, int> outloadDict = new Dictionary<string, int>();
        private Dictionary<string, string> outloadTypeDict = new Dictionary<string, string>();
        private int VehicleFare = 0;
        private int CargoFare = 0;

        private AutoCompleteStringCollection autoComplete;

        public string UIDCard
        {
            get
            {
                return ticket.Text;
            }

            set
            {
                ticket.Text = value;
            }
        }

        public PassKadeIn(Login home)
        {
            InitializeComponent();
            this.home = home;
            this.restApi = new RESTAPI();
            this.database = new DBConnect();
            Initialize();
        }

        private void Initialize()
        {
            InitializeVehicleType();
            InitializeOutload();
            CameraHelper.StartIpCamera(liveCamera);
            nonCash.Checked = true;

            this.bni = new BNI();
            this.webcamImage = webcam;
            if (Properties.Settings.Default.WebcamEnabled)
            {
                this.camera = new Webcam(this);
            }

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

        private void InitializeOutload()
        {
            try
            {
                tarifMuatan.Items.Add("- Pilih Tipe Muatan -");
                using (StreamReader reader = new StreamReader(MasterDataFileParkingIn))
                {
                    string json = reader.ReadToEnd();
                    dynamic outloads = JsonConvert.DeserializeObject(json);
                    foreach (var outload in outloads["cargo"])
                    {
                        int outloadFare = outload["fare"];
                        string outloadType = outload["name"];
                        string outloadTypeWithFare = outload["name"] + " - " + TKHelper.IDRWithCurrency(outloadFare.ToString());
                        tarifMuatan.Items.Add(outloadTypeWithFare);
                        outloadDict.Add(outloadTypeWithFare, outloadFare);
                        outloadTypeDict.Add(outloadTypeWithFare, outloadType);
                    }
                    tarifMuatan.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_FETCH_OUTLOAD, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tipe_kendaraan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tipe_kendaraan.SelectedIndex != 0)
            {
                var ApiUrl = Properties.Resources.RequestVehicleFarePassKadeAPIURL;
                string vehicleType = tipe_kendaraan.Text;
                PassKadeInVehicleFareRequest passKadeInVehicleFareRequest = new PassKadeInVehicleFareRequest(vehicleType);
                var sentParam = JsonConvert.SerializeObject(passKadeInVehicleFareRequest);

                DataResponseObject response = (DataResponseObject)restApi.post(IpAddressServer, ApiUrl, true, sentParam);
                if (response != null)
                {
                    if (response.Status == 206)
                    {
                        PassKadeInVehicleFare passKadeInVehicleFare = JsonConvert.DeserializeObject<PassKadeInVehicleFare>(response.Data.ToString());

                        txtPassKadeFare.Text = TKHelper.IDR(passKadeInVehicleFare.Fare.ToString());
                        VehicleFare = passKadeInVehicleFare.Fare;
                        int grandTotal = VehicleFare + CargoFare;
                        txtGrandTotal.Text = TKHelper.IDR(grandTotal.ToString());

                        string[] departure = passKadeInVehicleFare.DepartureDatetime.Split(' ');
                        departureDatetime.Text = TKHelper.ConvertDatetime(departure[0], departure[1]);
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

        private void tarifMuatan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tarifMuatan.SelectedIndex != 0)
            {
                string outloadType = tarifMuatan.Text;
                CargoFare = TKHelper.DictionaryGetValueByKey(outloadDict, outloadType);
                int grandTotal = CargoFare + VehicleFare;
                txtGrandTotal.Text = TKHelper.IDR(grandTotal.ToString());
            }
        }

        private void TextListener(string field, bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (field == "nomor plat kendaraan")
                {
                    nomor_plat.Clear();
                }
                if (field == "barcode/uid kartu")
                {
                    ticket.Clear();
                }
            }
            nomor_plat.ForeColor = Color.FromArgb(78, 184, 206);
            ticket.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void ticket_Click(object sender, EventArgs e)
        {
            if (ticket.Text.ToLower() == "barcode/uid kartu")
                this.TextListener("barcode/uid kartu");
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

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constant.CONFIRMATION_MESSAGE_BEFORE_EXIT, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.RememberMe = "no";
                Properties.Settings.Default.Save();

                CameraHelper.StopIpCamera(liveCamera);
                mifareCard.Stop();
                database.DisposeDatabaseConnection();

                // redirect to sign-in form
                Hide();
                this.home.Clear();
                this.home.Show();
                Dispose();
                UnsubscribeEvents();
                TKHelper.ClearGarbage();
            }
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
            tarifMuatan.SelectedIndex = 0;
            tipe_kendaraan.SelectedIndex = 0;
            txtGrandTotal.Text = "0";
            departureDatetime.Text = "- - -  00:00:00";
            txtPassKadeFare.Text = "0";
            nonCash.Checked = true;
            nomor_plat.Text = "Nomor Plat Kendaraan";
            nomor_plat.CharacterCasing = CharacterCasing.Lower;
            ticket.Text = "Barcode/UID Kartu";
            VehicleFare = 0;
            CargoFare = 0;
        }

        private void ticket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBarcodeSuggestion.Visible = true;
                string barcode = ticket.Text.ToString();
                listBarcodeSuggestion.Items.Clear();
                SearchBarcode(barcode);
                listBarcodeSuggestion.DroppedDown = true;
                listBarcodeSuggestion.Focus();
                if (listBarcodeSuggestion.Items.Count == 0)
                {
                    listBarcodeSuggestion.Items.Add("Data Tidak Ditemukan");
                    ticket.Focus();

                }
                else if (listBarcodeSuggestion.Items.Count == 1)
                {
                    ticket.AutoCompleteCustomSource = autoComplete;
                }
            }
        }

        private void selectBarcode(object sender, EventArgs e)
        {
            if (listBarcodeSuggestion.SelectedItem.ToString() != "Data Tidak Ditemukan")
            {
                ticket.Text = listBarcodeSuggestion.Text;
                ticket.Text = listBarcodeSuggestion.Text;
                listBarcodeSuggestion.Visible = false;
            }
        }

        private AutoCompleteStringCollection SearchBarcode(string keyword)
        {
            var queryParam = "?barcode=" + keyword;
            var ApiURL = Properties.Resources.SearchBarcodeAPIURL + queryParam;
            DataResponseArray response = (DataResponseArray)restApi.get(IpAddressServer, ApiURL, false);
            if (response != null)
            {
                if (response.Status == 206)
                {
                    string data = response.Data.ToString();
                    List<Barcode> barcodes = JsonConvert.DeserializeObject<List<Barcode>>(data);
                    if (barcodes.Count > 0)
                    {
                        foreach (Barcode barcode in barcodes)
                        {
                            listBarcodeSuggestion.Items.Add(barcode.barcode);
                        }
                    }
                }
            }
            return autoComplete;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string feedback = this.ValidateFields();
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
                            PassKadeDeparture passKadeDeparture = SendDataToServer(base64WebcamImage, base64LiveCameraSnapshot, paymentMethod, bankCode);
                            StoreDataToDatabase(responseDeduct, passKadeDeparture);
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
                    string base64WebcamImage = CameraHelper.CaptureWebcamImage(camera, webcamImage);
                    string base4LiveCameraSnapshot = CameraHelper.SnapshotLiveCamera();
                    if (!string.IsNullOrEmpty(base4LiveCameraSnapshot))
                    {
                        PassKadeDeparture passKadeDeparture = SendDataToServer(base64WebcamImage, base4LiveCameraSnapshot, paymentMethod);
                        if(passKadeDeparture != null)
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

        private PassKadeDeparture SendDataToServer(string base64WebcamImage, string base64IpCameraImage, string paymentMethod, string bankCode = "")
        {
            int vehicleFare = TKHelper.IDRToNominal(txtPassKadeFare.Text.ToString());
            string uid = ticket.Text.ToString();
            string uidType = TKHelper.GetUidType(uid);
            string vehicleType = tipe_kendaraan.Text.ToString();
            string departure = TKHelper.ConvertDatetimeToDefaultFormat(departureDatetime.Text.ToString());
            string username = Properties.Settings.Default.Username;
            string plateNumber = nomor_plat.Text.ToString();
            string IpAddress = TKHelper.GetLocalIPAddress();
            string cargoType = TKHelper.DictionaryGetValueByKey(outloadTypeDict, tarifMuatan.Text.ToString());
            PassKadeDepartureRequest passKadeDepartureRequest = new PassKadeDepartureRequest(uidType, uid, vehicleType, departure, username, plateNumber, vehicleFare, CargoFare, cargoType, IpAddress, paymentMethod, bankCode, base64WebcamImage, base64IpCameraImage);
            var sentParam = JsonConvert.SerializeObject(passKadeDepartureRequest);

            string passKadeDepartureRequestApiUrl = Properties.Resources.SaveDataPassKadeDepartureApiUrl;
            DataResponseObject response = (DataResponseObject)restApi.post(IpAddressServer, passKadeDepartureRequestApiUrl, true, sentParam);
            if(response != null)
            {
                if(response.Status == 206)
                {
                    return JsonConvert.DeserializeObject<PassKadeDeparture>(response.Data.ToString());
                } else
                {
                    MessageBox.Show(response.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            } else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_INVALID_RESPONSE_FROM_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void StoreDataToDatabase(DataDeduct dataDeduct, PassKadeDeparture passKadeDeparture)
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
                int parkingInId = passKadeDeparture.ParkingInId;

                string query = "INSERT INTO deduct_card_results (parking_in_id, result, amount, transaction_dt, bank, ipv4, operator, ID_reader, created) VALUES('" + parkingInId + "', '" +
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

            if (departureDatetime.Text.ToLower() == "- - -  00:00:00" || departureDatetime.Text == "")
            {
                return Constant.WARNING_MESSAGE_DATETIME_LEAVE_NOT_EMPTY;
            }

            if (ticket.Text.ToLower() == "barcode/uid card" || ticket.Text == "")
            {
                return Constant.WARNING_MESSAGE_UID_CARD_NOT_EMPTY;
            }

            if (tipe_kendaraan.SelectedIndex == -1 || tipe_kendaraan.SelectedIndex == 0)
            {
                return Constant.WARNING_MESSAGE_VEHICLE_TYPE_NOT_EMPTY;
            }

            if (tarifMuatan.SelectedIndex == -1 || tarifMuatan.SelectedIndex == 0)
            {
                return Constant.WARNING_MESSAGE_OUTLOAD_NOT_EMPTY;
            }
            return Constant.MESSAGE_OK;
        }

        public void UnsubscribeEvents()
        {
            tipe_kendaraan.SelectionChangeCommitted -= tipe_kendaraan_SelectionChangeCommitted;
            tarifMuatan.SelectionChangeCommitted -= tarifMuatan_SelectionChangeCommitted;

            buttonLogout.Click -= buttonLogout_Click;
            btnClose.Click -= btnClose_Click;
            btnMinimize.Click -= btnMinimize_Click;
            btnClear.Click -= btnClear_Click;
            ticket.Click -= ticket_Click;
            nomor_plat.Click -= nomor_plat_Click;
            btnSave.Click -= btnSave_Click;

            nomor_plat.TextChanged -= nomor_plat_TextChanged;

            ticket.KeyDown -= ticket_KeyDown;

            listBarcodeSuggestion.SelectedIndexChanged -= selectBarcode;
        }
    }
}
