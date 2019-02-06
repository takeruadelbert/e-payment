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

namespace BNITapCash
{
    public partial class Cashier : Form
    {
        private Login home;
        private BNI bni;
        private const string liveCameraURL = "http://192.168.1.121/snapshot";
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
        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            this.TextListener();
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
            textBox4.Text = "Waktu Keluar";
            txtHour.Text = "";
            txtMinute.Text = "";
            txtSecond.Text = "";
            txtGrandTotal.Text = "0";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.TextListener();
        }

        private void TextListener()
        {
            if (textBox1.Text == "UID Card")
                textBox1.Clear();
            textBox1.ForeColor = Color.FromArgb(78, 184, 206);
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
    }
}
