using BNITapCash.API;
using BNITapCash.API.request;
using BNITapCash.API.response;
using BNITapCash.Classes.API.response;
using BNITapCash.Classes.Forms;
using BNITapCash.ConstantVariable;
using BNITapCash.DB;
using BNITapCash.Forms;
using BNITapCash.Helper;
using BNITapCash.Interface;
using BNITapCash.Readers.Contactless.Acr123U;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BNITapCash
{
    public partial class Login : Form, EventFormHandler
    {
        private Cashier cashier;
        private About about;
        private PassKadeIn passKadeIn;
        private RESTAPI restApi;
        private string ip_address_server;

        public Login()
        {
            InitializeComponent();
            InitData();
            about = new About();
            this.restApi = new RESTAPI();
        }

        private void Login_Load(object sender, EventArgs e)
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
            if (username.Text.ToLower() == "username")
                this.ChangeTextListener("username");
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (password.Text.ToLower() == "password")
                this.ChangeTextListener("password");
        }

        private void ChangeTextListener(string field, bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (field.ToLower() == "username")
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
                    database.DisposeDatabaseConnection();

                    // check reader connection
                    Acr123U acr123U = new Acr123U();
                    string[] readerList = acr123U.getReaderList();
                    if (readerList.Length <= 0)
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

                    this.ip_address_server = Properties.Settings.Default.IPAddressServer;

                    if (CheckGate())
                    {
                        // pull some data from server e.g. Vehicle Types
                        if (PullDataFromServer(Properties.Settings.Default.GateType))
                        {
                            ApiSignIn(username, password);
                            loading.Dispose();
                            TKHelper.ClearGarbage();
                        }
                    }
                }
            }
        }

        private bool Validate(string username, string password)
        {
            if (username == "" || username.ToLower() == "Username")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_USERNAME_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (password == "" || password.ToLower() == "Password")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_PASSWORD_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.IPAddressServer))
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_IP_ADDRESS_SERVER, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.UriAddressLiveCamera))
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_IP_ADDRESS_LIVE_CAMERA, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // validate TID & Settlement MID for further transaction
            if (string.IsNullOrEmpty(Properties.Settings.Default.TID))
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_TID, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.MID))
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_MID, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private bool PullDataFromServer(string GateType)
        {
            return GateType.ToLower() == "in" ? PullDataParkingIn() : PullDataParkingOut();
        }

        private bool PullDataParkingIn()
        {
            string APIPullData = Properties.Resources.RequestDataParkingPedestrianAPIURL;
            DataResponseObject response = (DataResponseObject)restApi.get(ip_address_server, APIPullData, true);
            if (response != null)
            {
                if (response.Status == 206)
                {
                    ParkingInPedestrian parkingInPedestrian = JsonConvert.DeserializeObject<ParkingInPedestrian>(response.Data.ToString());
                    if (TKHelper.WriteDataIntoJSONFile(parkingInPedestrian, Constant.DIR_PATH_SOURCE, Constant.PATH_FILE_MASTER_DATA_PARKING_IN))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_WRITE_MASTER_DATA_FILE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool PullDataParkingOut()
        {
            string APIPullData = Properties.Resources.RequestVehicleTypeAPIURL;
            DataResponseArray receivedData = (DataResponseArray)restApi.get(this.ip_address_server, APIPullData);
            if (receivedData != null)
            {
                switch (receivedData.Status)
                {
                    case 206:
                        JArray receivedVehicleTypes = receivedData.Data;
                        JObject vehicleTypes = new JObject();
                        vehicleTypes.Add(new JProperty("VehicleTypes", receivedVehicleTypes));

                        if (TKHelper.WriteDataIntoJSONFile(vehicleTypes, Constant.DIR_PATH_SOURCE, Constant.PATH_FILE_MASTER_DATA_PARKING_OUT))
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_WRITE_MASTER_DATA_FILE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ApiSignIn(string username, string password)
        {
            var APIUrl = Properties.Resources.LoginAPIURL;
            SignInRequest signInRequest = new SignInRequest(username, password);
            string sent_param = JsonConvert.SerializeObject(signInRequest);

            DataResponseArray response = (DataResponseArray)restApi.post(this.ip_address_server, APIUrl, false, sent_param);
            if (response != null)
            {
                switch (response.Status)
                {
                    case 201:
                        try
                        {
                            if (Properties.Settings.Default.GateType.ToLower() == "in")
                            {
                                this.passKadeIn = new PassKadeIn(this);
                                this.passKadeIn.Show();
                            }
                            else
                            {
                                this.cashier = new Cashier(this);
                                this.cashier.Show();
                            }
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
            Setting setting = new Setting(this);
            setting.Show();
            TKHelper.ClearGarbage();
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
            DatabaseConfig DBConfig = new DatabaseConfig(this);
            DBConfig.Show();
            TKHelper.ClearGarbage();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!about.Visible)
            {
                about = new About();
                about.Show();
            }
            TKHelper.ClearGarbage();
        }

        private void tIDSettlementMIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            TMID tmid = new TMID(this);
            tmid.Show();
            TKHelper.ClearGarbage();
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

        private bool CheckGate()
        {
            string CheckGateApiUrl = Properties.Resources.CheckGateAPIURL;
            DataResponseObject response = (DataResponseObject)restApi.get(this.ip_address_server, CheckGateApiUrl, true);
            if (response != null)
            {
                switch (response.Status)
                {
                    case 206:
                        string data = response.Data.ToString();
                        Gate gate = JsonConvert.DeserializeObject<Gate>(data);

                        Properties.Settings.Default.GateID = gate.Id;
                        Properties.Settings.Default.GateName = gate.Name;
                        Properties.Settings.Default.GateType = gate.Type;
                        Properties.Settings.Default.UriAddressLiveCamera = gate.RtspUri;
                        Properties.Settings.Default.UriSnapshotLiveCamera = gate.SnapshotUri;
                        Properties.Settings.Default.WebcamEnabled = gate.WebcamEnabled;
                        Properties.Settings.Default.WebcamWidth = gate.WebcamWidth;
                        Properties.Settings.Default.WebcamHeight = gate.WebcamHeight;

                        return true;
                    case 401:
                        MessageBox.Show(Constant.ERROR_MESSAGE_INVALID_GATE, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    default:
                        MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }
            }
            else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void UnsubscribeEvents()
        {
            username.Click -= textBox1_Click;
            username.TextChanged -= textBox1_TextChanged;
            username.KeyDown -= username_KeyDown;
            password.Click -= textBox2_Click;
            password.TextChanged -= textBox2_TextChanged;
            password.KeyDown -= password_KeyDown;

            btnLogin.Click -= btnLogin_Click;
            button1.Click -= button1_Click;
            button2.Click -= button2_Click;

            pictureBox2.MouseDown -= pictureBox2_MouseDown;

            databaseToolStripMenuItem.Click -= databaseToolStripMenuItem_Click;
            iPv4ServerCameraToolStripMenuItem.Click -= iPv4ServerCameraToolStripMenuItem_Click;
            tIDSettlementMIDToolStripMenuItem.Click -= tIDSettlementMIDToolStripMenuItem_Click;
            aboutToolStripMenuItem.Click -= aboutToolStripMenuItem_Click;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
