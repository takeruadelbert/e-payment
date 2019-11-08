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
    public partial class LostTicket : Form
    {
        public LostTicket()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
