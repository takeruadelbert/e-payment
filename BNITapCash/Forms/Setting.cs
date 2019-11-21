﻿using BNITapCash.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;
using BNITapCash.ConstantVariable;

namespace BNITapCash
{
    public partial class Setting : Form
    {
        private Form home;

        public Setting(Form home)
        {
            InitializeComponent();
            this.home = home;
            IPAddressServer = "";
            IPAddressLiveCamera = "";
            InitData();
        }

        public string IPAddressServer { get; set; }

        public string IPAddressLiveCamera { get; set; }

        public int WebcamWidth { get; set; }

        public int WebcamHeight { get; set; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener("ip server", true);
        }

        private void Setting_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.TextChangeListener("ip server");
        }

        private void TextChangeListener(string text, bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (text == "ip server" && textBox1.Text.ToLower() == "ip server")
                    textBox1.Clear();
                else if (text == "ip live camera" && textBox2.Text.ToLower() == "ip live camera")
                    textBox2.Clear();
                else if (text == "width" && txtWidth.Text.ToLower() == "width")
                    txtWidth.Clear();
                else if (text == "height" && txtHeight.Text.ToLower() == "height")
                    txtHeight.Clear();
                else if (text == "username" && liveCameraUsername.Text.ToLower() == "username")
                    liveCameraUsername.Clear();
                else if (text == "password" && liveCameraPassword.Text.ToLower() == "password")
                    liveCameraPassword.Clear();
            }
            pictureBox2.BackgroundImage = Properties.Resources.Icon_pc;
            panel1.ForeColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.FromArgb(78, 184, 206);
            textBox2.ForeColor = Color.FromArgb(78, 184, 206);
            txtWidth.ForeColor = Color.FromArgb(78, 184, 206);
            txtHeight.ForeColor = Color.FromArgb(78, 184, 206);
            liveCameraUsername.ForeColor = Color.FromArgb(78, 184, 206);
            if (liveCameraPassword.Text.ToLower() != "password")
                liveCameraPassword.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void back_Click(object sender, EventArgs e)
        {
            home.Show();
            Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void save_Click(object sender, EventArgs e)
        {
            string ipv4 = textBox1.Text.ToString();
            string ipv4_live_cam = textBox2.Text.ToString();
            int width = Convert.ToInt32(txtWidth.Text);
            int height = Convert.ToInt32(txtHeight.Text);
            string liveCamUsername = liveCameraUsername.Text;
            string liveCamPassword = liveCameraPassword.Text;
            if (ipv4 != "" && ipv4 != "IP Server" && ipv4 != null)
            {
                if (ipv4_live_cam != "" && ipv4_live_cam != "IP Live Camera" && ipv4_live_cam != null)
                {
                    if (TKHelper.ValidateIPv4(ipv4))
                    {
                        if (TKHelper.ValidateIPv4(ipv4_live_cam))
                        {
                            Properties.Settings.Default.IPAddressServer = ipv4;
                            Properties.Settings.Default.IPAddressLiveCamera = ipv4_live_cam;
                            Properties.Settings.Default.WebcamWidth = width;
                            Properties.Settings.Default.WebcamHeight = height;
                            Properties.Settings.Default.LiveCameraUsername = liveCamUsername;
                            Properties.Settings.Default.LiveCameraPassword = liveCamPassword;
                            Properties.Settings.Default.Save();
                            IPAddressServer = ipv4;
                            IPAddressLiveCamera = ipv4_live_cam;
                            MessageBox.Show(Constant.SETTING_UPDATE_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_IP_ADDRESS_LIVE_CAMERA, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_IP_ADDRESS_SERVER, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(Constant.WARNING_MESSAGE_IP_ADDRESS_LIVE_CAMERA_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_IP_ADDRESS_SERVER_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void InitData()
        {
            if (Properties.Settings.Default.IPAddressServer != string.Empty)
            {
                textBox1.Text = Properties.Settings.Default.IPAddressServer;
                this.IPAddressServer = Properties.Settings.Default.IPAddressServer;
            }

            if (Properties.Settings.Default.IPAddressLiveCamera != string.Empty)
            {
                textBox2.Text = Properties.Settings.Default.IPAddressLiveCamera;
                IPAddressLiveCamera = Properties.Settings.Default.IPAddressLiveCamera;
            }

            // give default value of resolution : (480 x 360)
            if (Properties.Settings.Default.WebcamWidth != 0)
            {
                txtWidth.Text = Properties.Settings.Default.WebcamWidth.ToString();
                WebcamWidth = Properties.Settings.Default.WebcamWidth;
            }
            else
            {
                txtWidth.Text = "480";
                WebcamWidth = 480;
            }

            if (Properties.Settings.Default.WebcamHeight != 0)
            {
                txtHeight.Text = Properties.Settings.Default.WebcamHeight.ToString();
                WebcamHeight = Properties.Settings.Default.WebcamHeight;
            }
            else
            {
                txtHeight.Text = "360";
                WebcamHeight = 360;
            }

            if (Properties.Settings.Default.LiveCameraUsername != string.Empty)
            {
                liveCameraUsername.Text = Properties.Settings.Default.LiveCameraUsername;

            }

            if (Properties.Settings.Default.LiveCameraPassword != string.Empty)
            {
                liveCameraPassword.Text = Properties.Settings.Default.LiveCameraPassword;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener("ip live camera", true);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.TextChangeListener("ip live camera");
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener("width", true);
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener("height", true);
        }

        private void txtWidth_Click(object sender, EventArgs e)
        {
            this.TextChangeListener("width");
        }

        private void txtHeight_Click(object sender, EventArgs e)
        {
            this.TextChangeListener("height");
        }

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void liveCameraPassword_TextChanged_1(object sender, EventArgs e)
        {
            liveCameraPassword.PasswordChar = '●';
            this.TextChangeListener("password", true);
        }
        private void liveCameraUsername_TextChanged_1(object sender, EventArgs e)
        {
            this.TextChangeListener("username", true);
        }

        private void liveCameraUsername_Click(object sender, EventArgs e)
        {
            this.TextChangeListener("username");
        }

        private void liveCameraPassword_Click(object sender, EventArgs e)
        {
            this.TextChangeListener("password");
        }
    }
}
