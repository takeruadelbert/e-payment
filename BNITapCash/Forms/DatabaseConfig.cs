using BNITapCash.DB;
using BNITapCash.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;
using BNITapCash.ConstantVariable;

namespace BNITapCash.Forms
{
    public partial class DatabaseConfig : Form
    {
        private Form home;

        public DatabaseConfig(Form home)
        {
            InitializeComponent();
            this.home = home;
            InitData();
        }

        public string DBHost { get; set; }

        public string DBName { get; set; }

        public string DBUsername { get; set; }

        public string DBPassword { get; set; }

        private void InitData()
        {
            if (Properties.Settings.Default.DBHost != string.Empty)
            {
                txtDBHost.Text = Properties.Settings.Default.DBHost;
                this.DBHost = Properties.Settings.Default.DBHost;
            }

            if (Properties.Settings.Default.DBName != string.Empty)
            {
                txtDBName.Text = Properties.Settings.Default.DBName;
                this.DBName = Properties.Settings.Default.DBName;
            }

            if (Properties.Settings.Default.DBUsername != string.Empty)
            {
                txtDBUsername.Text = Properties.Settings.Default.DBUsername;
                this.DBUsername = Properties.Settings.Default.DBUsername;
            }

            if (Properties.Settings.Default.DBPassword != string.Empty)
            {
                txtDBPassword.Text = Properties.Settings.Default.DBPassword;
                this.DBPassword = Properties.Settings.Default.DBPassword;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constant.CONFIRMATION_MESSAGE_BEFORE_EXIT, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Dispose();
                System.Environment.Exit(1);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            home.Show();
            Dispose();
        }

        private void save_Click(object sender, EventArgs e)
        {
            string db_host = txtDBHost.Text.ToString();
            string db_name = txtDBName.Text.ToString();
            string db_username = txtDBUsername.Text.ToString();
            string db_password = txtDBPassword.Text.ToString();
            if (ValidateFields(db_host, db_name, db_username))
            {
                Properties.Settings.Default.DBHost = db_host;
                Properties.Settings.Default.DBName = db_name;
                Properties.Settings.Default.DBUsername = db_username;
                Properties.Settings.Default.DBPassword = db_password;

                this.DBHost = db_host;
                this.DBName = db_name;
                this.DBUsername = db_username;
                this.DBPassword = db_password;
                Properties.Settings.Default.Save();
                MessageBox.Show(Constant.DATABASE_CONFIG_VALIDATION_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDBHost_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener(true);
        }

        private void txtDBName_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener(true);
        }

        private void txtDBUsername_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener(true);
        }

        private void txtDBPassword_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener(true);
        }

        private void txtDBHost_Click(object sender, EventArgs e)
        {
            this.TextChangeListener();
        }

        private void txtDBName_Click(object sender, EventArgs e)
        {
            this.TextChangeListener();
        }

        private void txtDBUsername_Click(object sender, EventArgs e)
        {
            this.TextChangeListener();
        }

        private void TextChangeListener(bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (txtDBHost.Text == "Host")
                    txtDBHost.Clear();
                if (txtDBName.Text == "Database Name")
                    txtDBName.Clear();
                if (txtDBUsername.Text == "Username")
                    txtDBUsername.Clear();
                if (txtDBPassword.Text == "Password")
                    txtDBPassword.Clear();
            }
            txtDBPassword.PasswordChar = '●';
            txtDBHost.ForeColor = Color.FromArgb(78, 184, 206);
            txtDBName.ForeColor = Color.FromArgb(78, 184, 206);
            txtDBUsername.ForeColor = Color.FromArgb(78, 184, 206);
            txtDBPassword.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void txtDBPassword_Click(object sender, EventArgs e)
        {
            this.TextChangeListener();
        }

        private bool ValidateFields(string db_host, string db_name, string db_username)
        {
            bool result = true;
            if (string.IsNullOrEmpty(db_host) || db_host == "Host")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_HOST_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (db_host.ToLower() != Constant.LOCALHOST_VALUE)
            {
                if (!TKHelper.ValidateIPv4(db_host))
                {
                    MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_HOST, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (string.IsNullOrEmpty(db_name) || db_name == "Database Name")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_DATABASE_NAME_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(db_username) || db_username == "Username")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_USERNAME_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return result;
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DatabaseConfig_Load(object sender, EventArgs e)
        {

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

        private void TestDatabaseConnection()
        {
            string host = txtDBHost.Text;
            string dbname = txtDBName.Text;
            string username = txtDBUsername.Text;
            string password = txtDBPassword.Text;
            if (this.ValidateFields(host, dbname, username))
            {
                DBConnect db = new DBConnect(host, dbname, username, password);
                if (db.CheckMySQLConnection())
                {
                    MessageBox.Show(Constant.STATUS_CONNECTION_ESTABLISH, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_LOCAL_DATABASE, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            TestDatabaseConnection();
        }
    }
}
