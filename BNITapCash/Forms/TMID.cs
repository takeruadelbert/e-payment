﻿using System;
using System.Drawing;
using System.Windows.Forms;
using BNITapCash.ConstantVariable;

namespace BNITapCash.Forms
{
    public partial class TMID : Form
    {
        private Login login;

        public TMID(Login login)
        {
            InitializeComponent();
            this.login = login;
            InitData();
        }

        public string TID { get; set; }

        public string MID { get; set; }

        private void InitData()
        {
            if (Properties.Settings.Default.TID != string.Empty)
            {
                txtTID.Text = Properties.Settings.Default.TID;
                TID = Properties.Settings.Default.TID;
            }

            if (Properties.Settings.Default.MID != string.Empty)
            {
                txtSettlementMID.Text = Properties.Settings.Default.MID;
                MID = Properties.Settings.Default.MID;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string tid_value = txtTID.Text.ToString();
            string mid_value = txtSettlementMID.Text.ToString();
            if (string.IsNullOrEmpty(tid_value) || tid_value == "TID")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_TID_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(mid_value) || mid_value == "Settlement MID")
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_MID_NOT_EMPTY, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Properties.Settings.Default.TID = tid_value;
            Properties.Settings.Default.MID = mid_value;
            Properties.Settings.Default.Save();
            TID = tid_value;
            MID = mid_value;
            MessageBox.Show(Constant.SETTING_UPDATE_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void back_Click(object sender, EventArgs e)
        {
            Dispose();
            login.Show();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void txtTID_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener("TID", true);
        }

        private void txtSettlementMID_TextChanged(object sender, EventArgs e)
        {
            this.TextChangeListener("MID", true);
        }

        private void txtTID_Click(object sender, EventArgs e)
        {
            this.TextChangeListener("TID");
        }

        private void txtSettlementMID_Click(object sender, EventArgs e)
        {
            this.TextChangeListener("MID");
        }

        private void TextChangeListener(string text, bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (text == "TID" && txtTID.Text == "TID")
                    txtTID.Clear();
                else if (text == "MID" && txtSettlementMID.Text == "Settlement MID")
                    txtSettlementMID.Clear();
            }
            txtTID.ForeColor = Color.FromArgb(78, 184, 206);
            txtSettlementMID.ForeColor = Color.FromArgb(78, 184, 206);
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

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
