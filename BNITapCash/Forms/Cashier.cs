using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using BNITapCash.API;
using BNITapCash.Bank.BNI;
using BNITapCash.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BNITapCash.Miscellaneous.Webcam;

namespace BNITapCash
{
    public partial class Cashier : Form
    {
        private Login home;
        private BNI bni;
        private TKHelper helper;
        private string liveCameraURL = "http://" + Properties.Settings.Default.IPAddressLiveCamera + "/snapshot";
        JPEGStream stream;

        public PictureBox webcamImage;
        private Webcam camera;

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
            InitializeWebcam();
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
                MessageBox.Show("Error : Cannot Connect to Live Camera. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LiveCamera.Image = Properties.Resources.no_image;
            }
            this.bni = new BNI(this);
            this.bni.RunMain();
            //this.StartTimer();

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
                MessageBox.Show("Error : failed to fetch vehicle type data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeWebcam()
        {
            camera = new Webcam(this);
            camera.StartWebcam();
        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.TextListener("Card UID", true);
        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Dispose();
                System.Environment.Exit(1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string feedback = this.ValidateFields();
            if (feedback == "ok")
            {
                int totalFare = this.helper.IDRToNominal(txtGrandTotal.Text.ToString());

                // encoded base64 Image from Webcam
                if(webcamImage.Image == null)
                {
                    MessageBox.Show("Snapshoot Webcam Bermasalah.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Bitmap bmp = new Bitmap(webcamImage.Image, 50, 30);
                //var compressedBmp = Base64Helper.GetCompressedBitmap(bmp, 30L);
                string base64Image = bmp.ToBase64String(ImageFormat.Png);

                // check the payment method whether it's cash or non-cash
                string type = nonCash.Checked ? "noncash" : "cash";
                if (type == "noncash")
                {
                    string paymentMethod = "NCSH";
                    string bankCode = "BNI";
                    // deduct balance of card
                    string responseDeduct = bni.DeductBalance(totalFare);
                    if (responseDeduct == "OK")
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

        }

        private void TextListener(string field, bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (textBox2.Text.ToLower() == "nomor plat kendaraan")
                {
                    textBox2.Clear();
                }
            }
            textBox1.ForeColor = Color.FromArgb(78, 184, 206);
            textBox2.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                this.TextListener("Nomor Plat Kendaraan");
        }

        private string ValidateFields()
        {
            if (textBox2.Text.ToLower() == "nomor plat kendaraan" || textBox2.Text == "")
            {
                return "Field 'Nomor Plat Kendaraan' Harus Diisi.";
            }

            if (textBox4.Text.ToLower() == "waktu keluar" || textBox4.Text == "")
            {
                return "Field 'Waktu Keluar' Kosong.";
            }

            if (textBox1.Text.ToLower() == "uid card" || textBox1.Text == "")
            {
                return "Field 'UID Card' Harus Diisi.";
            }

            if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedIndex == 0)
            {
                return "Field 'Tipe Kendaraan' Harus Dipilih.";
            }
            return "ok";
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
                        JObject param = new JObject();
                        param["uid"] = textBox1.Text;
                        param["vehicle"] = comboBox1.Text;
                        var sent_param = JsonConvert.SerializeObject(param);

                        RESTAPI api = new RESTAPI();
                        string ip_address_server = "http://" + Properties.Settings.Default.IPAddressServer;
                        DataResponse response = api.API_Post(ip_address_server, APIUrl, sent_param);
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
                            MessageBox.Show("Error : Can't establish connection to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Silahkan Tap Kartunya Terlebih Dahulu.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ResetComboBox();
                    return;
                }
            }
        }

        private void SendDataToServer(int totalFare, string base64Image, string paymentMethod, string bankCode = "")
        {
            JObject param = new JObject();
            param["uid"] = textBox1.Text.ToString();
            param["vehicle"] = comboBox1.Text.ToString();
            param["waktu_keluar"] = this.helper.ConvertDatetimeToDefaultFormat(textBox4.Text.ToString());
            param["username"] = Properties.Settings.Default.Username;
            param["plate_number"] = textBox2.Text.ToString();
            param["total_fare"] = totalFare;
            param["ipv4"] = this.helper.GetLocalIPAddress();
            param["payment_method"] = paymentMethod;
            param["bank_code"] = bankCode;
            param["image"] = base64Image;
            var sent_param = JsonConvert.SerializeObject(param);
            RESTAPI save = new RESTAPI();
            string ip_address_server = "http://" + Properties.Settings.Default.IPAddressServer;
            DataResponse response = save.API_Post(ip_address_server, Properties.Resources.SaveDataParkingAPIURL, sent_param);
            if (response != null)
            {
                switch (response.Status)
                {
                    case 206:
                        MessageBox.Show("Transaksi Berhasil.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Clear(true);
                        break;
                    default:
                        MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
