using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BNITapCash.API;
using BNITapCash.Bank.BNI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BNITapCash.Helper;
using System.Threading;
using BNITapCash.Miscellaneous;
using BNITapCash.DB;
using BNITapCash.Forms;

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
            panel2.ForeColor = Color.WhiteSmoke;
            password.ForeColor = Color.WhiteSmoke;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Hide();
            //setting.Show();
        }

        private void SignIn()
        {
            for (int i = 0; i <= 500; i++)
            {
                Thread.Sleep(10);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.username.Text.ToString();
            string password = this.password.Text.ToString();
            if (username == "" || username == "Username")
            {
                MessageBox.Show("Username Harus Diisi.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password == "" || password == "Password")
            {
                MessageBox.Show("Password Harus Diisi.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(this.setting.IPAddressServer))
            {
                MessageBox.Show("Invalid IP Address Server.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(this.setting.IPAddressLiveCamera))
            {
                MessageBox.Show("Invalid IP Address Live Camera.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validate TID & Settlement MID for further transaction
            if (string.IsNullOrEmpty(this.tmid.TID))
            {
                MessageBox.Show("Invalid 'TID' value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(this.tmid.MID))
            {
                MessageBox.Show("Invalid 'Settlement MID' value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Loading loading = new Loading(SignIn))
            {
                loading.ShowDialog(this);

                // check local database connection
                DBConnect database = new DBConnect();
                if (!database.CheckMySQLConnection())
                {
                    MessageBox.Show("Error : Can't Establish Connection to Local Database.\nPlease setup properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // check reader connection
                BNI bni = new BNI();
                if (!bni.CheckReaderConn())
                {
                    MessageBox.Show("Error : Contactless Reader not available.\nPlease plug it and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string APIPullData = Properties.Resources.RequestVehicleTypeAPIURL;
                RESTAPI pull = new RESTAPI();
                DataResponse receivedData = pull.API_Get(ip_address_server, APIPullData);
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
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        default:
                            MessageBox.Show(receivedData.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Error : Can't establish connection to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // send data API
                var APIUrl = Properties.Resources.LoginAPIURL;
                JObject param = new JObject();
                param["username"] = username;
                param["password"] = password;
                var sent_param = JsonConvert.SerializeObject(param);

                RESTAPI api = new RESTAPI();
                DataResponse response = api.API_Post(ip_address_server, APIUrl, sent_param);
                if (response != null)
                {
                    switch (response.Status)
                    {
                        case 201:
                            //MessageBox.Show(response.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            try
                            {
                this.cashier = new Cashier(this);
                this.cashier.Show();
                Hide();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error : Can't Connect to Webcam.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error : Can't establish connection to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
