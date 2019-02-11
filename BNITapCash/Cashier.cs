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
using AForge.Video;
using BNITapCash.Bank.BNI;
using BNITapCash.Helper;

namespace BNITapCash
{
    public partial class Cashier : Form
    {
        private Login home;
        private BNI bni;
        private TKHelper helper;
        private string liveCameraURL = "http://" + Properties.Settings.Default.IPAddressLiveCamera + "/snapshot";
        JPEGStream stream;

        public string UIDCard
        {
            get {
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
            this.helper = new TKHelper();
            textBox4.Text = this.helper.GetCurrentDatetime();
            this.home = home;
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
            this.StartTimer();
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
                System.Environment.Exit(1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string feedback = this.ValidateFields();
            if(feedback == "ok")
            {
                MessageBox.Show("OK", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show(feedback, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            textBox1.Text = "UID Card";
            textBox2.Text = "Nomor Plat Kendaraan";
            textBox3.Text = "Waktu Masuk";
            textBox4.Text = this.helper.GetCurrentDatetime();
            txtHour.Text = "";
            txtMinute.Text = "";
            txtSecond.Text = "";
            txtGrandTotal.Text = "0";            
            comboBox1.SelectedIndex = -1;
            comboBox1.ResetText();
            comboBox1.SelectedText = "- Pilih Tipe Kendaraan -";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void TextListener(string field, bool is_textchanged = false)
        {
            if(!is_textchanged)
            {
                if (textBox2.Text == "Nomor Plat Kendaraan")
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
            if (textBox2.Text == "Nomor Plat Kendaraan")
                this.TextListener("Nomor Plat Kendaraan");
        }

        private string ValidateFields()
        {
            if(textBox2.Text.ToLower() == "nomor plat kendaraan" || textBox2.Text == "")
            {
                return "Field 'Nomor Plat Kendaraan' Harus Diisi.";
            }

            if(textBox4.Text.ToLower() == "waktu keluar" || textBox4.Text == "")
            {
                return "Field 'Waktu Keluar' Kosong.";
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
    }
}
