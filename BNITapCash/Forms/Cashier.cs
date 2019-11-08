using AForge.Video;
using BNITapCash.API;
using BNITapCash.API.request;
using BNITapCash.API.response;
using BNITapCash.Bank.BNI;
using BNITapCash.Card.Mifare;
using BNITapCash.ConstantVariable;
using BNITapCash.Helper;
using BNITapCash.Miscellaneous.Webcam;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private TKHelper helper;
        private readonly string liveCameraURL = "http://" + Properties.Settings.Default.IPAddressLiveCamera + "/snapshot";
        JPEGStream stream;

        public PictureBox webcamImage;
        private Webcam camera;
        private MifareCard mifareCard;
        private RESTAPI restApi;
        private AutoCompleteStringCollection autoComplete;

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
            autoComplete = new AutoCompleteStringCollection();
        }

        private void Initialize()
        {
            nonCash.Checked = true;
            this.helper = new TKHelper();
            //textBox4.Text = this.helper.GetCurrentDatetime();            
            try
            {
                stream = new JPEGStream(liveCameraURL);
                stream.NewFrame += stream_NewFrame;
                stream.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_LIVE_CAMERA, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LiveCamera.Image = Properties.Resources.no_image;
            }
            this.bni = new BNI();
            //this.bni.RunMain();
            //this.StartTimer();

            this.mifareCard = new MifareCard(this);
            this.mifareCard.RunMain();

            // initialize vehicle type options            
            try
            {
                comboBox1.Items.Add("- Pilih Tipe Kendaraan -");
                string masterDataFile = this.helper.GetApplicationExecutableDirectoryName() + "\\src\\master-data.json";
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
                int totalFare = this.helper.IDRToNominal(txtGrandTotal.Text.ToString());

                // encoded base64 Image from Webcam
                try
                {
                    camera.StartWebcam();
                }
                catch (Exception)
                {
                    MessageBox.Show(Constant.ERROR_MESSAGE_WEBCAM_TROUBLE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (webcamImage.Image == null)
                {
                    MessageBox.Show(Constant.ERROR_MESSAGE_WEBCAM_SNAPSHOOT_FAILED, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    camera.StopWebcam();
                    return;
                }
                camera.StopWebcam();
                Bitmap bmp = new Bitmap(webcamImage.Image, Properties.Settings.Default.WebcamWidth, Properties.Settings.Default.WebcamHeight);
                string base64Image = bmp.ToBase64String(ImageFormat.Png);

                // check the payment method whether it's cash or non-cash
                string type = nonCash.Checked ? "noncash" : "cash";
                if (type == "noncash")
                {
                    string paymentMethod = "NCSH";
                    string bankCode = "BNI";
                    // deduct balance of card
                    string ipv4 = helper.GetLocalIPAddress();
                    string TIDSettlement = Properties.Settings.Default.TID;
                    string operator_name = Properties.Settings.Default.Username;
                    string responseDeduct = bni.DeductBalance(bankCode, ipv4, TIDSettlement, operator_name);
                    if (responseDeduct == Constant.MESSAGE_OK)
                    {
                        // API POST Data to server
                        this.SendDataToServer(totalFare, base64Image, paymentMethod, bankCode);
                    }
                    else
                    {
                        MessageBox.Show(responseDeduct, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    string paymentMethod = "CASH";
                    this.SendDataToServer(totalFare, base64Image, paymentMethod);
                }
            }
            else
            {
                MessageBox.Show(feedback, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
            textBox4.Text = this.helper.GetCurrentDatetime();
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

            if (textBox4.Text.ToLower() == "waktu keluar" || textBox4.Text == "")
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
            textBox4.Text = this.helper.GetCurrentDatetime();
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
                    if (comboBox1.SelectedIndex != 0)
                    {
                        // send data API
                        var APIUrl = Properties.Resources.RequestUIDFareAPIURL;

                        string uidType = helper.GetUidType(UIDCard);
                        string vehicle = comboBox1.Text.ToString();
                        RequestFareRequest requestFare = new RequestFareRequest(uidType, UIDCard, vehicle);
                        var sent_param = JsonConvert.SerializeObject(requestFare);

                        RESTAPI api = new RESTAPI();
                        string ip_address_server = "http://" + Properties.Settings.Default.IPAddressServer;

                        DataResponseArray response = (DataResponseArray)api.post(ip_address_server, APIUrl, false, sent_param);
                        if (response != null)
                        {
                            switch (response.Status)
                            {
                                case 206:
                                    //MessageBox.Show(response.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    foreach (JObject data in response.Data)
                                    {
                                        // Duration Data Process
                                        string duration = data["lama_parkir"].ToString();
                                        string[] temp = duration.Split(':');
                                        txtHour.Text = temp[0];
                                        txtMinute.Text = temp[1];
                                        txtSecond.Text = temp[2];

                                        // Total Fare Process
                                        txtGrandTotal.Text = data["tarif_parkir"].ToString();

                                        // Datetime Parking In
                                        string datetime_in = data["waktu_masuk"].ToString();
                                        string[] temp_dt_in = datetime_in.Split(' ');
                                        textBox3.Text = this.helper.ConvertDatetime(temp_dt_in[0], temp_dt_in[1]);

                                        // Datetime Out
                                        string datetime_out = data["waktu_keluar"].ToString();
                                        string[] temp_dt_out = datetime_out.Split(' ');
                                        textBox4.Text = this.helper.ConvertDatetime(temp_dt_out[0], temp_dt_out[1]);

                                        // Load Picture of face and plate number
                                        string URL_pict_face = "http://" + Properties.Settings.Default.IPAddressServer + Properties.Resources.repo + "/" + data["gambar_face"].ToString();
                                        PictFace.Load(URL_pict_face);
                                        PictFace.BackgroundImageLayout = ImageLayout.Stretch;
                                        PictFace.SizeMode = PictureBoxSizeMode.StretchImage;
                                        string URL_pict_vehicle = "http://" + Properties.Settings.Default.IPAddressServer + Properties.Resources.repo + "/" + data["gambar_plate"].ToString();
                                        PictVehicle.Load(URL_pict_vehicle);
                                        PictVehicle.BackgroundImageLayout = ImageLayout.Stretch;
                                        PictVehicle.SizeMode = PictureBoxSizeMode.StretchImage;

                                        // Total Fare Process
                                        string total_fare = data["tarif_parkir"].ToString();
                                        txtGrandTotal.Text = this.helper.IDR(total_fare);
                                    }
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
                else
                {
                    MessageBox.Show(Constant.WARNING_MESSAGE_UNTAPPED_CARD, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ResetComboBox();
                    return;
                }
            }
        }

        private void SendDataToServer(int totalFare, string base64Image, string paymentMethod, string bankCode = "")
        {
            string uid = textBox1.Text.ToString();
            string vehicle = comboBox1.Text.ToString();
            string datetimeOut = this.helper.ConvertDatetimeToDefaultFormat(textBox4.Text.ToString());
            string username = Properties.Settings.Default.Username;
            string plateNumber = textBox2.Text.ToString();
            string ipAddressLocal = this.helper.GetLocalIPAddress();
            ParkingOutRequest parkingOutRequest = new ParkingOutRequest(uid, vehicle, datetimeOut, username, plateNumber, totalFare, ipAddressLocal, paymentMethod, bankCode, base64Image);
            var sent_param = JsonConvert.SerializeObject(parkingOutRequest);

            string ip_address_server = "http://" + Properties.Settings.Default.IPAddressServer;
            DataResponseObject response = (DataResponseObject)restApi.post(ip_address_server, Properties.Resources.SaveDataParkingAPIURL, true, sent_param);
            if (response != null)
            {
                switch (response.Status)
                {
                    case 206:
                        MessageBox.Show(Constant.TRANSACTION_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Clear(true);
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
            string ip_address_server = "http://" + Properties.Settings.Default.IPAddressServer;
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
                            autoComplete.Add(barcode.barcode);
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
                string barcode = textBox1.Text.ToString();
                autoComplete.Clear();
                autoComplete = SearchBarcode(barcode);
                if (autoComplete != null)
                {
                    textBox1.AutoCompleteCustomSource = autoComplete;
                }
            }
        }
    }
}
