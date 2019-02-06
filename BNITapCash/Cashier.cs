using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BNITapCash
{
    public partial class Cashier : Form
    {
        private Form home;

        public Cashier()
        {

        }

        public Cashier(Form home)
        {
            InitializeComponent();
            this.home = home;
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
                Application.Exit();
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
    }
}
