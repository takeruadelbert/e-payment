using BNITapCash.API;
using BNITapCash.API.request;
using BNITapCash.Card.Mifare;
using BNITapCash.ConstantVariable;
using BNITapCash.DB;
using BNITapCash.Forms;
using BNITapCash.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BNITapCash
{
    public partial class Login : Form
    {
        private Setting setting;
        private Cashier cashier;
        private DatabaseConfig DBConfig;
        private About about;
        private TMID tmid;
        private TKHelper tk = new TKHelper();

        public Login()
        {
            InitializeComponent();
            InitData();
            this.setting = new Setting(this);
            this.DBConfig = new DatabaseConfig(this);
            this.about = new About();
            this.tmid = new TMID(this);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.ChangeTextListener("username", true);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password.PasswordChar = '●';
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (username.Text == "Username")
                this.ChangeTextListener("username");
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (password.Text == "Password")
                this.ChangeTextListener("password");
        }

        private void ChangeTextListener(string field, bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (field == "username")
                {
                    username.Clear();
                }
                else
                {
                    password.Clear();
                }
            }
            username.BackgroundImage = Properties.Resources.username5;
            panel1.ForeColor = Color.FromArgb(78, 184, 206);
            username.ForeColor = Color.FromArgb(78, 184, 206);

            password.BackgroundImage = Properties.Resources.password3;
            panel2.ForeColor = Color.FromArgb(78, 184, 206); ;
            password.ForeColor = Color.FromArgb(78, 184, 206); ;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void SignIn()
        {
            for (int i = 0; i <= 300; i++)
            {
                Thread.Sleep(10);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.username.Text.ToString();
            string password = this.password.Text.ToString();

            if (Validate(username, password))
            {
                using (Loading loading = new Loading(SignIn))
                {
                    loading.ShowDialog(this);

                    // check local database connection
                    DBConnect database = new DBConnect();
                    if (!database.CheckMySQLConnection())
                    {
                        MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_LOCAL_DATABASE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // check reader connection
                    MifareCard mifareCard = new MifareCard();
                    if (!mifareCard.CheckReaderConnection())
                    {
                        MessageBox.Show(Constant.ERROR_MESSAGE_DEVICE_READER_NOT_FOUND, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // remember me feature
                    if (checkBox1.Checked)
                    {
                        Properties.Settings.Default.Username = username;
                        Properties.Settings.Default.Password = password;
                        Properties.Settings.Default.RememberMe = "yes";
                    }
                    else
                    {
                        Properties.Settings.Default.Username = username;
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.RememberMe = "no";
                    }
                    Properties.Settings.Default.Save();

                    string ip_address_server = "http://" + this.setting.IPAddressServer;

                    // pull some data from server e.g. Vehicle Types
                    if (PullDataFromServer(ip_address_server))
                    {
                        ApiSignIn(username, password, ip_address_server);
                    }
                }
            }
        }

        private bool Validate(string username, string password)
        {
            if (username == "" || username == "Username")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_USERNAME_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (password == "" || password == "Password")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_PASSWORD_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.setting.IPAddressServer))
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_IP_ADDRESS_SERVER, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.setting.IPAddressLiveCamera))
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_IP_ADDRESS_LIVE_CAMERA, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // validate TID & Settlement MID for further transaction
            if (string.IsNullOrEmpty(this.tmid.TID))
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_TID, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.tmid.MID))
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_MID, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private bool PullDataFromServer(string ip_address_server)
        {
            string APIPullData = Properties.Resources.RequestVehicleTypeAPIURL;
            RESTAPI pull = new RESTAPI();
            DataResponseArray receivedData = (DataResponseArray)pull.get(ip_address_server, APIPullData);
            if (receivedData != null)
            {
                switch (receivedData.Status)
                {
                    case 206:
                        JArray receivedVehicleTypes = receivedData.Data;
                        JObject vehicleTypes = new JObject();
                        vehicleTypes.Add(new JProperty("VehicleTypes", receivedVehicleTypes));

                        // write into a file called 'master-data.json'
                        try
                        {
                            string savedDir = tk.GetApplicationExecutableDirectoryName() + "\\src\\master-data.json";
                            string json = JsonConvert.SerializeObject(vehicleTypes);
                            System.IO.File.WriteAllText(@savedDir, json);
                            //MessageBox.Show("Pull Master Data is Success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    default:
                        MessageBox.Show(receivedData.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }
            }
            else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ApiSignIn(string username, string password, string ip_address_server)
        {
            var APIUrl = Properties.Resources.LoginAPIURL;
            SignInRequest signInRequest = new SignInRequest(username, password);
            string sent_param = JsonConvert.SerializeObject(signInRequest);

            RESTAPI api = new RESTAPI();
            DataResponseArray response = (DataResponseArray)api.post(ip_address_server, APIUrl, false, sent_param);
            if (response != null)
            {
                switch (response.Status)
                {
                    case 201:
                        try
                        {
                            this.cashier = new Cashier(this);
                            this.cashier.Show();
                            Hide();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_WEBCAM, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void InitData()
        {
            if (Properties.Settings.Default.Username != string.Empty)
            {
                if (Properties.Settings.Default.RememberMe == "yes")
                {
                    username.Text = Properties.Settings.Default.Username;
                    password.Text = Properties.Settings.Default.Password;
                    checkBox1.Checked = true;
                }
                else
                {
                    username.Text = Properties.Settings.Default.Username;
                }
            }
        }

        public void Clear()
        {
            password.Clear();
            checkBox1.Checked = false;
        }

        private void iPv4ServerCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            setting.Show();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                contextMenuStrip1.Show(this.PointToScreen(e.Location));
            }
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            DBConfig.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!about.Visible)
            {
                about = new About();
                about.Show();
            }
        }

        private void tIDSettlementMIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            tmid.Show();
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
    }
}
