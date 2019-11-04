using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BNITapCash.Forms
{
    public partial class TMID : Form
    {
        private Login login;
        private Form home;
        private string tid;
        private string settlement_mid;

        public TMID(Login login)
        {
            InitializeComponent();
            this.home = home;
            this.login = login;
            InitData();
        }

        public string TID
        {
            get; set;
        }

        public string MID
        {
            get; set;
        }

        private void InitData()
        {
            if (Properties.Settings.Default.TID != string.Empty)
            {
                txtTID.Text = Properties.Settings.Default.TID;
                this.TID = Properties.Settings.Default.TID;
            }

            if (Properties.Settings.Default.MID != string.Empty)
            {
                txtSettlementMID.Text = Properties.Settings.Default.MID;
                this.MID = Properties.Settings.Default.MID;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string tid_value = txtTID.Text.ToString();
            string mid_value = txtSettlementMID.Text.ToString();
            if (string.IsNullOrEmpty(tid_value) || tid_value == "TID")
            {
                MessageBox.Show("TID Harus Diisi.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(string.IsNullOrEmpty(mid_value) || mid_value == "Settlement MID")
            {
                MessageBox.Show("Settlement MID Harus Diisi.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Properties.Settings.Default.TID = tid_value;
            Properties.Settings.Default.MID = mid_value;
            Properties.Settings.Default.Save();
            this.TID = tid_value;
            this.MID = mid_value;
            MessageBox.Show("Setting Berhasil Diupdate.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void back_Click(object sender, EventArgs e)
        {
            Hide();
            login.Show();
        }

        private void txtTID_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener(true);
        }

        private void txtSettlementMID_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener(true);
        }

        private void txtTID_Click(object sender, EventArgs e)
        {
            this.TextChangeListener();
        }

        private void txtSettlementMID_Click(object sender, EventArgs e)
        {
            this.TextChangeListener();
        }

        private void TextChangeListener(bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (txtTID.Text == "TID")
                    txtTID.Clear();
                else if (txtSettlementMID.Text == "Settlement MID")
                    txtSettlementMID.Clear();
            }
            txtTID.ForeColor = Color.FromArgb(78, 184, 206);
            txtSettlementMID.ForeColor = Color.FromArgb(78, 184, 206);
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

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void logout_Click(object sender, EventArgs e)
        {
            home.Show();
            Hide();
        }
    }
}
