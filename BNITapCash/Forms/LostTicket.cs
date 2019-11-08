using System;
using System.Windows.Forms;
using BNITapCash.ConstantVariable;

namespace BNITapCash.Forms
{
    public partial class LostTicket : Form
    {
        public LostTicket()
        {
            InitializeComponent();
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
       
        public void Clear(bool include_uid = false)
        {
            
        }

        private void btnLsTicketClear_Click(object sender, EventArgs e)
        {
            Clear(true);
        }


        private void btnLsTicketSave_Click(object sender, EventArgs e)
        {

        }

        private void back_to_cashier_Click(object sender, EventArgs e)
        {

        }
    }
}
