using BNITapCash.Classes.Forms.DataModel;
using BNITapCash.Helper;
using BNITapCash.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BNITapCash.Classes.Forms
{
    public partial class PedestrianFareDetail : Form, EventFormHandler
    {
        private List<PedestrianDetail> PedestrianDetails = new List<PedestrianDetail>();

        public PedestrianFareDetail(List<PedestrianDetail> details)
        {
            InitializeComponent();
            PedestrianDetails = details;
            InitializeData();
        }

        private void InitializeData()
        {
            int locationY = 20;

            if (PedestrianDetails.Count > 0)
            {
                int counter = 1;
                foreach (PedestrianDetail pedestrianDetail in PedestrianDetails)
                {
                    Label labelPedestrianType = new Label();
                    labelPedestrianType.AutoSize = true;
                    labelPedestrianType.BackColor = Color.WhiteSmoke;
                    labelPedestrianType.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    labelPedestrianType.ForeColor = Color.Black;
                    labelPedestrianType.Location = new Point(35, locationY);
                    labelPedestrianType.Name = "labelPedestrianType" + counter;
                    labelPedestrianType.Size = new Size(114, 16);
                    labelPedestrianType.TabIndex = 54;
                    labelPedestrianType.Text = pedestrianDetail.PedestrianType;

                    Label labelPedestrianFareDetail = new Label();
                    labelPedestrianFareDetail.AutoSize = true;
                    labelPedestrianFareDetail.BackColor = Color.WhiteSmoke;
                    labelPedestrianFareDetail.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    labelPedestrianFareDetail.ForeColor = Color.Black;
                    labelPedestrianFareDetail.Location = new Point(245, locationY);
                    labelPedestrianFareDetail.Name = "labelPedestrianFareDetail" + counter;
                    labelPedestrianFareDetail.Size = new Size(96, 16);
                    labelPedestrianFareDetail.TabIndex = 55;
                    labelPedestrianFareDetail.Text = String.Format("{0} x {1}", pedestrianDetail.NumberOfPeople, TKHelper.IDRWithCurrency(pedestrianDetail.PedestrianFare.ToString()));

                    int totalFare = pedestrianDetail.NumberOfPeople * pedestrianDetail.PedestrianFare;
                    Label labelPedestrianTotalFare = new Label();
                    labelPedestrianTotalFare.AutoSize = true;
                    labelPedestrianTotalFare.BackColor = Color.WhiteSmoke;
                    labelPedestrianTotalFare.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    labelPedestrianTotalFare.ForeColor = Color.Black;
                    labelPedestrianTotalFare.Location = new Point(452, locationY);
                    labelPedestrianTotalFare.Name = "labelPedestrianTotalFare" + counter;
                    labelPedestrianTotalFare.Size = new Size(77, 16);
                    labelPedestrianTotalFare.TabIndex = 56;
                    labelPedestrianTotalFare.Text = TKHelper.IDRWithCurrency(totalFare.ToString());

                    panelPedestrianDetail.Controls.Add(labelPedestrianType);
                    panelPedestrianDetail.Controls.Add(labelPedestrianFareDetail);
                    panelPedestrianDetail.Controls.Add(labelPedestrianTotalFare);

                    locationY += 30;
                    counter++;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
            UnsubscribeEvents();
            TKHelper.ClearGarbage();
        }

        public void UnsubscribeEvents()
        {
            btnClose.Click -= btnClose_Click;
        }
    }
}
