using AForge.Video;
using BNITapCash.API;
using BNITapCash.API.request;
using BNITapCash.API.response;
using BNITapCash.Bank.BNI;
using BNITapCash.Bank.DataModel;
using BNITapCash.Card.Mifare;
using BNITapCash.ConstantVariable;
using BNITapCash.DB;
using BNITapCash.Forms;
using BNITapCash.Helper;
using BNITapCash.Miscellaneous.Webcam;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BNITapCash
{
    public partial class Cashier : Form
    {
        private Login home;
        private BNI bni;
        private readonly string liveCameraURL = Constant.URL_PROTOCOL + Properties.Settings.Default.IPAddressLiveCamera + "/snapshot";
        private JPEGStream stream;
        private DBConnect database;
        public PictureBox webcamImage;
        private Webcam camera;
        private MifareCard mifareCard;
        private RESTAPI restApi;
        private AutoCompleteStringCollection autoComplete;
        private string ip_address_server;
        private ParkingIn parkingIn;

        public string UIDCard
        {
            get
            {
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
            }
        }

        public Cashier(Login home)
        {
            InitializeComponent();
            this.home = home;
            Initialize();
            this.webcamImage = webcam;
            this.camera = new Webcam(this);
            this.restApi = new RESTAPI();
            this.database = new DBConnect();
            this.parkingIn = new ParkingIn();
            autoComplete = new AutoCompleteStringCollection();
        }

        private void Initialize()
        {
            nonCash.Checked = true;
            ip_address_server = Properties.Settings.Default.IPAddressServer;

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
            this.bni = new BNI();

            this.mifareCard = new MifareCard(this);
            this.mifareCard.RunMain();

            // initialize vehicle type options            
            try
            {
                comboBox1.Items.Add("- Pilih Tipe Kendaraan -");
                string masterDataFile = TKHelper.GetApplicationExecutableDirectoryName() + Constant.PATH_FILE_MASTER_DATA;
                using (StreamReader reader = new StreamReader(masterDataFile))
                {
                    string json = reader.ReadToEnd();
                    dynamic vehicleTypes = JsonConvert.DeserializeObject(json);
                    foreach (var types in vehicleTypes["VehicleTypes"])
                    {
                        comboBox1.Items.Add(types);
                    }
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_FETCH_VEHICLE_TYPE_DATA, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cashier_Load(object sender, EventArgs e)
        {

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
                        string base64WebcamImage = CaptureWebcamImage();
                        if (!string.IsNullOrEmpty(base64WebcamImage))
                        {
                            ParkingOut parkingOut = SendDataToServer(totalFare, base64WebcamImage, paymentMethod);
                            StoreDataToDatabase(responseDeduct, parkingOut);
                            MessageBox.Show(Constant.TRANSACTION_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        ParkingOut parkingOut = SendDataToServer(totalFare, base64WebcamImage, paymentMethod);
                        MessageBox.Show(Constant.TRANSACTION_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.Clear(true);
            }
            else
            {
                MessageBox.Show(feedback, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private ParkingOut SendDataToServer(int totalFare, string base64Image, string paymentMethod, string bankCode = "")
        {
            string uid = textBox1.Text.ToString();
            string uidType = TKHelper.GetUidType(uid);
            string vehicle = comboBox1.Text.ToString();
            string datetimeOut = TKHelper.ConvertDatetimeToDefaultFormat(textBox4.Text.ToString());
            string username = Properties.Settings.Default.Username;
            string plateNumber = textBox2.Text.ToString();
            string ipAddressLocal = TKHelper.GetLocalIPAddress();
            ParkingOutRequest parkingOutRequest = new ParkingOutRequest(uidType, uid, vehicle, datetimeOut, username, plateNumber, totalFare, ipAddressLocal, paymentMethod, bankCode, base64Image);
            var sent_param = JsonConvert.SerializeObject(parkingOutRequest);

            DataResponseObject response = (DataResponseObject)restApi.post(ip_address_server, Properties.Resources.SaveDataParkingAPIURL, true, sent_param);
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
            else
            {
                camera.StopWebcam();
                Bitmap bmp = new Bitmap(webcamImage.Image, Properties.Settings.Default.WebcamWidth, Properties.Settings.Default.WebcamHeight);
                return bmp.ToBase64String(ImageFormat.Png);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear(true);
        }

        public void Clear(bool include_uid = false)
        {
            if (include_uid)
                textBox1.Text = "UID Card";
            textBox2.Text = "Nomor Plat Kendaraan";
            textBox3.Text = "Waktu Masuk";
            textBox4.Text = TKHelper.GetCurrentDatetime();
            txtHour.Text = "";
            txtMinute.Text = "";
            txtSecond.Text = "";
            txtGrandTotal.Text = "0";
            this.ResetComboBox();

            PictFace.Image = Properties.Resources.no_image;
            PictFace.SizeMode = PictureBoxSizeMode.StretchImage;
            PictVehicle.Image = Properties.Resources.no_image;
            PictVehicle.SizeMode = PictureBoxSizeMode.StretchImage;

            nonCash.Checked = true;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToLower() == "uid card")
                this.TextListener("uid card");
        }

        private void TextListener(string field, bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (field == "nomor plat kendaraan")
                {
                    textBox2.Clear();
                }
                if (field == "uid card")
                {
                    textBox1.Clear();
                }
            }
            textBox1.ForeColor = Color.FromArgb(78, 184, 206);
            textBox2.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constant.CONFIRMATION_MESSAGE_BEFORE_EXIT, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.RememberMe = "no";
                Properties.Settings.Default.Save();

                // redirect to sign-in form
                Hide();
                this.home.Clear();
                this.home.Show();
            }
        }

        private void logout_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(logout, "Logout");
        }

        private void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            LiveCamera.Image = bmp;
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.TextListener("Nomor Plat Kendaraan", true);
            textBox2.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.ToLower() == "nomor plat kendaraan")
                this.TextListener("nomor plat kendaraan");
        }

        private string ValidateFields()
        {
            if (textBox2.Text.ToLower() == "nomor plat kendaraan" || textBox2.Text == "")
            {
                return Constant.WARMING_MESSAGE_PLATE_NUMBER_NOT_EMPTY;
            }

            if (textBox4.Text.ToLower() == "- - -  00:00:00" || textBox4.Text == "")
            {
                return Constant.WARNING_MESSAGE_DATETIME_LEAVE_NOT_EMPTY;
            }

            if (textBox1.Text.ToLower() == "uid card" || textBox1.Text == "")
            {
                return Constant.WARNING_MESSAGE_UID_CARD_NOT_EMPTY;
            }

            if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedIndex == 0)
            {
                return Constant.WARNING_MESSAGE_VEHICLE_TYPE_NOT_EMPTY;
            }
            return Constant.MESSAGE_OK;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            textBox4.Text = TKHelper.GetCurrentDatetime();
        }

        private void StartTimer()
        {
            System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000; // 1 second
            tmr.Tick += new EventHandler(TimerTick);
            tmr.Enabled = true;
        }

        private void ResetComboBox()
        {
            comboBox1.SelectedIndex = 0;
            comboBox1.ResetText();
            comboBox1.SelectedText = "- Pilih Tipe Kendaraan -";
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                if (textBox1.Text != "" && textBox1.Text != "UID Card")
                {
                    // send data API
                    var APIUrl = Properties.Resources.RequestUIDFareAPIURL;

                    string uidType = TKHelper.GetUidType(UIDCard);
                    string vehicle = comboBox1.Text.ToString();
                    RequestFareRequest requestFare = new RequestFareRequest(uidType, UIDCard, vehicle);
                    var sent_param = JsonConvert.SerializeObject(requestFare);

                    DataResponseObject response = (DataResponseObject)restApi.post(ip_address_server, APIUrl, true, sent_param);
                    if (response != null)
                    {
                        switch (response.Status)
                        {
                            case 206:
                                parkingIn = JsonConvert.DeserializeObject<ParkingIn>(response.Data.ToString());

                                txtHour.Text = TKHelper.GetValueTime(parkingIn.DatetimeIn, "hour");
                                txtMinute.Text = TKHelper.GetValueTime(parkingIn.DatetimeIn, "minute");
                                txtSecond.Text = TKHelper.GetValueTime(parkingIn.DatetimeIn, "second");

                                txtGrandTotal.Text = TKHelper.IDR(parkingIn.Fare.ToString());

                                string[] datetimeIn = parkingIn.DatetimeIn.Split(' ');
                                textBox3.Text = TKHelper.ConvertDatetime(datetimeIn[0], datetimeIn[1]);

                                string[] datetimeOut = parkingIn.DatetimeOut.Split(' ');
                                textBox4.Text = TKHelper.ConvertDatetime(datetimeOut[0], datetimeOut[1]);

                                // Load Picture of face and plate number
                                string faceImage = parkingIn.FaceImage;
                                if (string.IsNullOrEmpty(faceImage))
                                {
                                    PictFace.Image = Properties.Resources.no_image;
                                }
                                else
                                {
                                    string URL_pict_face = Constant.URL_PROTOCOL + Properties.Settings.Default.IPAddressServer + Properties.Resources.repo + "/" + faceImage;
                                    PictFace.Load(URL_pict_face);
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
                                    string URL_pict_vehicle = Constant.URL_PROTOCOL + Properties.Settings.Default.IPAddressServer + Properties.Resources.repo + "/" + parkingIn.PlateNumberImage;
                                    PictVehicle.Load(URL_pict_vehicle);
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
                else
                {
                    MessageBox.Show(Constant.WARNING_MESSAGE_UNTAPPED_CARD, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ResetComboBox();
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constant.CONFIRMATION_MESSAGE_BEFORE_EXIT, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Dispose();
                System.Environment.Exit(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBarcodeSuggestion.Visible = true;
                string barcode = textBox1.Text.ToString();
                listBarcodeSuggestion.Items.Clear();
                SearchBarcode(barcode);
                listBarcodeSuggestion.DroppedDown = true;
                listBarcodeSuggestion.Focus();
                if (listBarcodeSuggestion.Items.Count == 0)
                {
                    listBarcodeSuggestion.Items.Add("Data Tidak Ditemukan");
                    textBox1.Focus();

                }
                else if (listBarcodeSuggestion.Items.Count == 1)
                {
                    textBox1.AutoCompleteCustomSource = autoComplete;
                }
            }
        }

        private void selectBarcode(object sender, EventArgs e)
        {
            if (listBarcodeSuggestion.SelectedItem.ToString() != "Data Tidak Ditemukan")
            {
                textBox1.Text = listBarcodeSuggestion.Text;
                textBox1.Text = listBarcodeSuggestion.Text;
                listBarcodeSuggestion.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReprintTicket();
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            PrintReportOperator();
        }

        private void ReprintTicket()
        {
            string reprintTicketApiUrl = Properties.Resources.ReprintTicketAPIURL;
            DataResponseObject response = (DataResponseObject)restApi.get(ip_address_server, reprintTicketApiUrl, true);
            if (response != null)
            {
                if (response.Status == 206)
                {
                    MessageBox.Show(Constant.REPRINT_TICKET_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_INVALID_RESPONSE_FROM_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReportOperator()
        {
            string generateReportApiUrl = Properties.Resources.GenerateReportAPIURL;
            PrintReportRequest printReportRequest = new PrintReportRequest(Properties.Settings.Default.Username);
            var sentParam = JsonConvert.SerializeObject(printReportRequest);
            DataResponseObject response = (DataResponseObject)restApi.post(ip_address_server, generateReportApiUrl, true, sentParam);
            if (response != null)
            {
                switch (response.Status)
                {
                    case 206:
                        MessageBox.Show(Constant.PRINT_REPORT_OPERATOR_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 208:
                        MessageBox.Show(response.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    default:
                        MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_INVALID_RESPONSE_FROM_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonLostTicket_Click(object sender, EventArgs e)
        {
            stream.Stop();
            LostTicket lostTicket = new LostTicket(home);
            lostTicket.Show();
            Hide();
        }
    }
}
