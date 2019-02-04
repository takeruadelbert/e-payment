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

namespace BNITapCash
{
    public partial class Login : Form
    {
        private Setting setting;
        public Login()
        {
            InitializeComponent();
            this.setting = new Setting(this);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '●';
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            username.BackgroundImage = Properties.Resources.username5;
            panel1.ForeColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.FromArgb(78, 184, 206);

            password.BackgroundImage = Properties.Resources.password3;
            panel2.ForeColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.WhiteSmoke;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            username.BackgroundImage = Properties.Resources.username5;
            panel1.ForeColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.FromArgb(78, 184, 206);

            password.BackgroundImage = Properties.Resources.password3;
            panel2.ForeColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.WhiteSmoke;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Hide();
            setting.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();
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

            // send data API
            var APIUrl = "ws/accounts/login_api";
            var sent_param = "{\"username\":\"" + username + "\", \"password\":\"" + password + "\"}";
            RESTAPI api = new RESTAPI();
            DataResponse response = api.API_Post(APIUrl, sent_param);
            if(response != null)
            {
                switch(response.Status)
                {
                    case 201:
                        MessageBox.Show(response.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            } else
            {
                MessageBox.Show("Error : Can't establish connection to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
