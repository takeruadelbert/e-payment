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
    public partial class ManualPayment : Form
    {
        private Cashier cashier;
        private string UIDCard
        {
            set; get;
        }
        private string Nominal
        {
            set; get;
        }
        public ManualPayment(Cashier cashier, string uid_card, string nominal)
        {
            InitializeComponent();
            this.cashier = cashier;
            this.UIDCard = uid_card;
            this.Nominal = nominal;

            txtNominal.Text = nominal;
        }

        private void ManualPayment_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.cashier.Clear(true);
            this.cashier.Show();
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
    }
}
