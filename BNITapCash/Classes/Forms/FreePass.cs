using BNITapCash.API;
using BNITapCash.API.request;
using BNITapCash.API.response;
using BNITapCash.Card.Mifare;
using BNITapCash.Classes.Helper;
using BNITapCash.ConstantVariable;
using BNITapCash.Helper;
using BNITapCash.Interface;
using BNITapCash.Miscellaneous.Webcam;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BNITapCash.Forms
{
    public partial class FreePass : Form, EventFormHandler
    {
        private Login home;
        public PictureBox webcamImage;
        private Webcam camera;
        private MifareCard MifareCard;
        private RESTAPI restApi;
        private AutoCompleteStringCollection autoComplete;
        private string ip_address_server;
        private ParkingIn parkingIn;

        public string UIDCard
        {
            get
            {
                return supervisorCard.Text;
            }

            set
            {
                supervisorCard.Text = value;
            }
        }

        public FreePass(Login home)
        {
            InitializeComponent();
            this.home = home;
            Initialize();
        }

        private void Initialize()
        {
            this.webcamImage = webcam;
            this.camera = new Webcam(this);
            this.restApi = new RESTAPI();
            this.parkingIn = new ParkingIn();
            autoComplete = new AutoCompleteStringCollection();
            this.ip_address_server = Properties.Settings.Default.IPAddressServer;

            StartLiveCamera();

            this.MifareCard = new MifareCard(this);
            this.MifareCard.RunMain();

            InitDataVehicleType();
        }

        private void StartLiveCamera()
        {
            CameraHelper.StartIpCamera(liveCamera);
        }

        private void InitDataVehicleType()
        {
            try
            {
                vehicleType.Items.Add("- Pilih Tipe Kendaraan -");
                string masterDataFile = TKHelper.GetApplicationExecutableDirectoryName() + Constant.PATH_FILE_MASTER_DATA_PARKING_OUT;
                using (StreamReader reader = new StreamReader(masterDataFile))
                {
                    string json = reader.ReadToEnd();
                    dynamic vehicleTypes = JsonConvert.DeserializeObject(json);
                    foreach (var types in vehicleTypes["VehicleTypes"])
                    {
                        vehicleType.Items.Add(types);
                    }
                    vehicleType.SelectedIndex = 0;
                }
                TKHelper.ClearGarbage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_FETCH_VEHICLE_TYPE_DATA, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear(true);
        }

        private void buttonBackToCashier_Click(object sender, EventArgs e)
        {
            CameraHelper.StopIpCamera(liveCamera);
            MifareCard.Stop();
            Cashier cashier = new Cashier(home);
            cashier.Show();
            Dispose();
            UnsubscribeEvents();
            TKHelper.ClearGarbage();
        }

        private void vehicleType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (vehicleType.SelectedIndex != 0)
            {
                // send data API
                var APIUrl = Properties.Resources.RequestDataParkingFreePassAPIURL;

                string barcodeData = barcode.Text.ToString();
                string uidType = TKHelper.GetUidType(barcodeData);

                FreePassRequest freePassRequest = new FreePassRequest(uidType, barcodeData);
                var sent_param = JsonConvert.SerializeObject(freePassRequest);

                DataResponseObject response = (DataResponseObject)restApi.post(ip_address_server, APIUrl, true, sent_param);
                if (response != null)
                {
                    switch (response.Status)
                    {
                        case 206:
                            parkingIn = JsonConvert.DeserializeObject<ParkingIn>(response.Data.ToString());

                            txtGrandTotal.Text = TKHelper.IDR(parkingIn.Fare.ToString());

                            string[] datetimeIn = parkingIn.DatetimeIn.Split(' ');
                            timeIn.Text = TKHelper.ConvertDatetime(datetimeIn[0], datetimeIn[1]);

                            string[] datetimeOut = parkingIn.DatetimeOut.Split(' ');
                            timeOut.Text = TKHelper.ConvertDatetime(datetimeOut[0], datetimeOut[1]);

                            // Load Picture of face and plate number
                            string faceImage = parkingIn.FaceImage;
                            if (string.IsNullOrEmpty(faceImage))
                            {
                                PictFace.Image = Properties.Resources.no_image;
                            }
                            else
                            {
                                try
                                {
                                    string URL_pict_face = Constant.URL_PROTOCOL + Properties.Settings.Default.IPAddressServer + Properties.Resources.repo + "/" + faceImage;
                                    PictFace.Load(URL_pict_face);
                                }
                                catch (Exception)
                                {
                                    PictFace.Image = Properties.Resources.no_image;
                                }
                            }
                            PictFace.BackgroundImageLayout = ImageLayout.Stretch;
                            PictFace.SizeMode = PictureBoxSizeMode.StretchImage;

                            string plateNumberImage = parkingIn.PlateNumberImage;
                            if (string.IsNullOrEmpty(plateNumberImage))
                            {
                                PictVehicle.Image = Properties.Resources.no_image;
                            }
                            else
                            {
                                try
                                {
                                    string URL_pict_vehicle = Constant.URL_PROTOCOL + Properties.Settings.Default.IPAddressServer + Properties.Resources.repo + "/" + parkingIn.PlateNumberImage;
                                    PictVehicle.Load(URL_pict_vehicle);
                                }
                                catch (Exception)
                                {
                                    PictVehicle.Image = Properties.Resources.no_image;
                                }
                            }
                            PictVehicle.BackgroundImageLayout = ImageLayout.Stretch;
                            PictVehicle.SizeMode = PictureBoxSizeMode.StretchImage;
                            break;
                        default:
                            MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Clear();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Clear(bool include_uid = false)
        {
            if (include_uid)
            {
                supervisorCard.Text = "Tempel Kartu Supervisor";
            }
            plateNumber.Text = "Nomor Plat Kendaraan";
            timeIn.Text = "- - -  00:00:00";
            timeOut.Text = TKHelper.GetCurrentDatetime();
            txtGrandTotal.Text = "0";
            barcode.Text = "Scan Barcode";
            ResetComboBox();

            PictFace.Image = Properties.Resources.no_image;
            PictFace.SizeMode = PictureBoxSizeMode.StretchImage;
            PictVehicle.Image = Properties.Resources.no_image;
            PictVehicle.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ResetComboBox()
        {
            vehicleType.SelectedIndex = 0;
            vehicleType.ResetText();
            vehicleType.SelectedText = "- Pilih Tipe Kendaraan -";
        }

        private void barcode_Click(object sender, EventArgs e)
        {
            if (barcode.Text.ToLower() == "scan barcode")
            {
                TextListener("scan barcode");
            }
        }

        private void TextListener(string field, bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (field == "nomor plat kendaraan")
                {
                    plateNumber.Clear();
                }
                if (field == "scan barcode")
                {
                    barcode.Clear();
                }
            }
            barcode.ForeColor = Color.FromArgb(78, 184, 206);
            plateNumber.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void plateNumber_Click(object sender, EventArgs e)
        {
            if (plateNumber.Text.ToLower() == "nomor plat kendaraan")
            {
                TextListener("nomor plat kendaraan");
            }
        }

        private void plateNumber_TextChanged(object sender, EventArgs e)
        {
            TextListener("Nomor Plat Kendaraan", true);
            plateNumber.CharacterCasing = CharacterCasing.Upper;
        }

        private void barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBarcodeSuggestion.Visible = true;
                string dataBarcode = barcode.Text.ToString();
                listBarcodeSuggestion.Items.Clear();
                SearchBarcode(dataBarcode);
                listBarcodeSuggestion.DroppedDown = true;
                listBarcodeSuggestion.Focus();
                if (listBarcodeSuggestion.Items.Count == 0)
                {
                    listBarcodeSuggestion.Items.Add("Data Tidak Ditemukan");
                    barcode.Focus();

                }
                else if (listBarcodeSuggestion.Items.Count == 1)
                {
                    barcode.AutoCompleteCustomSource = autoComplete;
                }
            }
        }

        private AutoCompleteStringCollection SearchBarcode(string keyword)
        {
            var queryParam = "?barcode=" + keyword;
            var ApiURL = Properties.Resources.SearchBarcodeAPIURL + queryParam;
            DataResponseArray response = (DataResponseArray)restApi.get(ip_address_server, ApiURL, false);
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
                            //autoComplete.Add(barcode.barcode);
                        }
                    }
                }
            }
            return autoComplete;
        }

        private void selectBarcode(object sender, EventArgs e)
        {
            if (listBarcodeSuggestion.SelectedItem.ToString() != "Data Tidak Ditemukan")
            {
                barcode.Text = listBarcodeSuggestion.Text;
                barcode.Text = listBarcodeSuggestion.Text;
                listBarcodeSuggestion.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                string base64WebcamImage = CameraHelper.CaptureWebcamImage(camera, webcamImage);
                string base64LiveCameraSnapshotImage = CameraHelper.SnapshotLiveCamera();
                if (!string.IsNullOrEmpty(base64LiveCameraSnapshotImage))
                {
                    ParkingOut parkingOut = SendDataToServer(base64WebcamImage, base64LiveCameraSnapshotImage);
                    MessageBox.Show(Constant.TRANSACTION_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear(true);
                }
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(barcode.Text) || barcode.Text.ToLower() == "scan barcode")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_BARCODE_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(supervisorCard.Text) || supervisorCard.Text.ToLower() == "tempel kartu supervisor")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_UNTAPPED_CARD, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(timeOut.Text) || timeOut.Text == "- - -  00:00:00")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_DATETIME_LEAVE_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (vehicleType.SelectedIndex == 0)
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_VEHICLE_TYPE_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(plateNumber.Text) || (plateNumber.Text.ToLower() == "nomor plat kendaraan"))
            {
                MessageBox.Show(Constant.WARMING_MESSAGE_PLATE_NUMBER_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void supervisorCard_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UIDCard) || UIDCard.ToLower() != "tempel kartu supervisor")
            {
                CheckCard(UIDCard);
            }
        }

        private void CheckCard(string SupervisorUIDCard)
        {
            string ApiUrl = Properties.Resources.CheckSupervisorCardAPIURL + SupervisorUIDCard;
            DataResponseObject response = (DataResponseObject)restApi.get(ip_address_server, ApiUrl, true);
            if (response != null)
            {
                if (response.Status != 200)
                {
                    MessageBox.Show(response.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UIDCard = "Tempel Kartu Supervisor";
                }
            }
            else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_INVALID_RESPONSE_FROM_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ParkingOut SendDataToServer(string base64Image, string base64LiveCameraSnapshotImage)
        {
            string dataBarcode = barcode.Text.ToString();
            string uid = supervisorCard.Text.ToString();
            string uidType = TKHelper.GetUidType(dataBarcode);
            string vehicle = vehicleType.Text.ToString();
            string datetimeOut = TKHelper.ConvertDatetimeToDefaultFormat(timeOut.Text.ToString());
            string username = Properties.Settings.Default.Username;
            string dataPlateNumber = plateNumber.Text.ToString();
            string ipAddressLocal = TKHelper.GetLocalIPAddress();
            ParkingOutFreePassRequest freePassRequest = new ParkingOutFreePassRequest(vehicle, uidType, dataBarcode, username, datetimeOut, dataPlateNumber, ipAddressLocal, uid, base64Image, base64LiveCameraSnapshotImage);
            var sent_param = JsonConvert.SerializeObject(freePassRequest);

            DataResponseObject response = (DataResponseObject)restApi.post(ip_address_server, Properties.Resources.SaveDataFreePassAPIURL, true, sent_param);
            if (response != null)
            {
                switch (response.Status)
                {
                    case 206:
                        return JsonConvert.DeserializeObject<ParkingOut>(response.Data.ToString());
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

        public void UnsubscribeEvents()
        {
            listBarcodeSuggestion.SelectedIndexChanged -= selectBarcode;
            barcode.KeyDown -= barcode_KeyDown;
            barcode.Click -= barcode_Click;

            supervisorCard.TextChanged -= supervisorCard_TextChanged;

            plateNumber.Click -= plateNumber_Click;
            plateNumber.TextChanged -= plateNumber_TextChanged;

            btnClear.Click -= btnClear_Click;
            btnSave.Click -= btnSave_Click;
            btnMinimize.Click -= btnMinimize_Click;
            btnClose.Click -= btnClose_Click;
            buttonBackToCashier.Click -= buttonBackToCashier_Click;
        }
    }
}
