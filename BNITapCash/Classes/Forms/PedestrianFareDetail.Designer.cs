namespace BNITapCash.Classes.Forms
{
    partial class PedestrianFareDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedestrianFareDetail));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelPedestrianDetail = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoPelindo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPelindo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::BNITapCash.Properties.Resources.BG_PUTIH2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panelPedestrianDetail);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.logoPelindo);
            this.panel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(83, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 338);
            this.panel1.TabIndex = 0;
            // 
            // panelPedestrianDetail
            // 
            this.panelPedestrianDetail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPedestrianDetail.Location = new System.Drawing.Point(31, 116);
            this.panelPedestrianDetail.Name = "panelPedestrianDetail";
            this.panelPedestrianDetail.Size = new System.Drawing.Size(565, 199);
            this.panelPedestrianDetail.TabIndex = 66;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::BNITapCash.Properties.Resources.close_button;
            this.btnClose.Location = new System.Drawing.Point(588, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 30);
            this.btnClose.TabIndex = 65;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Location = new System.Drawing.Point(31, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 1);
            this.panel2.TabIndex = 53;
            // 
            // logoPelindo
            // 
            this.logoPelindo.BackColor = System.Drawing.Color.White;
            this.logoPelindo.BackgroundImage = global::BNITapCash.Properties.Resources.pelindo4;
            this.logoPelindo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPelindo.Location = new System.Drawing.Point(257, 15);
            this.logoPelindo.Name = "logoPelindo";
            this.logoPelindo.Size = new System.Drawing.Size(130, 68);
            this.logoPelindo.TabIndex = 52;
            this.logoPelindo.TabStop = false;
            // 
            // PedestrianFareDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BNITapCash.Properties.Resources.BG_BIRU;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PedestrianFareDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PedestrianFareDetail";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPelindo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox logoPelindo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelPedestrianDetail;
    }
}