using BNITapCash.ConstantVariable;
using BNITapCash.Helper;
using BNITapCash.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BNITapCash
{
    public partial class Setting : Form, EventFormHandler
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
            }
            pictureBox2.BackgroundImage = Properties.Resources.Icon_pc;
            panel1.ForeColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void back_Click(object sender, EventArgs e)
        {
            UnsubscribeEvents();
            home.Show();
            Dispose();
            TKHelper.ClearGarbage();
        }

        private void save_Click(object sender, EventArgs e)
        {
            string ipv4 = textBox1.Text.ToString();
            if (ipv4 != "" && ipv4 != "IP Server" && ipv4 != null)
            {
                if (TKHelper.ValidateIPv4(ipv4))
                {
                    Properties.Settings.Default.IPAddressServer = ipv4;
                    Properties.Settings.Default.Save();
                    IPAddressServer = ipv4;
                    MessageBox.Show(Constant.SETTING_UPDATE_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Constant.WARNING_MESSAGE_INVALID_IP_ADDRESS_SERVER, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public void UnsubscribeEvents()
        {
            textBox1.Click -= textBox1_Click;

            textBox1.TextChanged -= textBox1_TextChanged;

            button1.Click -= button1_Click;
            button2.Click -= button2_Click;
            save.Click -= save_Click;
            back.Click -= back_Click;
        }
    }
}
