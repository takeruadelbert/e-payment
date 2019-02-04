using System;
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

        public Setting(Form home)
        {
            InitializeComponent();
            this.home = home;
            this.ip_address_server = "";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener();
        }

        private void Setting_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.TextChangeListener();
        }

        private void TextChangeListener()
        {
            if (textBox1.Text == "IP Address Server")
                textBox1.Clear();
            pictureBox2.BackgroundImage = Properties.Resources.Icon_pc;
            panel1.ForeColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void back_Click(object sender, EventArgs e)
        {
            home.Show();
            Hide();
        }

        private void save_Click(object sender, EventArgs e)
        {
            string ipv4 = textBox1.Text.ToString();
            TKHelper tk = new TKHelper();
            if (ipv4 != "" && ipv4 != "IP Address Server" && ipv4 != null)
            {
                if (tk.ValidateIPv4(ipv4))
                {
                    this.ip_address_server = ipv4;
                    MessageBox.Show("IP Address Berhasil Diupdate.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid IP Address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("IP Address Harus Diisi.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
