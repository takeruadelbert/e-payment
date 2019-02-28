﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BNITapCash.Helper;

namespace BNITapCash
{
    public partial class Setting : Form
    {
        private Form home;
        private string ip_address_server;
        private string ip_address_live_camera;

        public Setting(Form home)
        {
            InitializeComponent();
            this.home = home;
            IPAddressServer = "";
            IPAddressLiveCamera = "";
            InitData();
        }

        public string IPAddressServer
        {
            get
            {
                return this.ip_address_server;
            }

            set
            {
                this.ip_address_server = value;
            }
        }

        public string IPAddressLiveCamera
        {
            get
            {
                return this.ip_address_live_camera;
            }

            set
            {
                this.ip_address_live_camera = value;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener(true);
        }

        private void Setting_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.TextChangeListener();
        }

        private void TextChangeListener(bool is_textchanged = false)
        {
            if(!is_textchanged)
            {
                if (textBox1.Text == "IP Address Server")
                    textBox1.Clear();
                else if (textBox2.Text == "IP Address Live Camera")
                    textBox2.Clear();
            }            
            pictureBox2.BackgroundImage = Properties.Resources.Icon_pc;
            panel1.ForeColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.FromArgb(78, 184, 206);
            textBox2.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void back_Click(object sender, EventArgs e)
        {
            home.Show();
            Hide();
        }

        private void save_Click(object sender, EventArgs e)
        {
            string ipv4 = textBox1.Text.ToString();
            string ipv4_live_cam = textBox2.Text.ToString();
            TKHelper tk = new TKHelper();
            if (ipv4 != "" && ipv4 != "IP Address Server" && ipv4 != null)
            {
                if (ipv4_live_cam != "" && ipv4_live_cam != "IP Address Live Camera" && ipv4_live_cam != null)
                {
                    if (tk.ValidateIPv4(ipv4))
                    {
                        if (tk.ValidateIPv4(ipv4_live_cam))
                        {
                            Properties.Settings.Default.IPAddressServer = ipv4;
                            Properties.Settings.Default.IPAddressLiveCamera = ipv4_live_cam;
                            Properties.Settings.Default.Save();
                            IPAddressServer = ipv4;
                            IPAddressLiveCamera = ipv4_live_cam;
                            MessageBox.Show("Setting Berhasil Diupdate.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Invalid IP Address Live Camera.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid IP Address Server.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("IP Address Live Camera Harus Diisi.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("IP Address Server Harus Diisi.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Dispose();
                System.Environment.Exit(1);
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
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener(true);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.TextChangeListener();
        }
    }
}
