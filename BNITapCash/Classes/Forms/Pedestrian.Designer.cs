namespace BNITapCash.Classes.Forms
{
    partial class Pedestrian
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pedestrian));
            this.panelInnerBoxWhite = new System.Windows.Forms.Panel();
            this.panelBox = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelLine = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tarifMuatan = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.datetimeIn = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.labelBackToLogin = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lineTopInnerbox = new System.Windows.Forms.Panel();
            this.cash = new System.Windows.Forms.RadioButton();
            this.nonCash = new System.Windows.Forms.RadioButton();
            this.labelTotalTarif = new System.Windows.Forms.Label();
            this.labelMetodePembayaran = new System.Windows.Forms.Label();
            this.totalTarif00 = new System.Windows.Forms.TextBox();
            this.RPTotalTarif = new System.Windows.Forms.TextBox();
            this.logoPelindo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.panelTotalTarifGreen = new System.Windows.Forms.Panel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelInnerBoxWhite.SuspendLayout();
            this.panelBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPelindo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInnerBoxWhite
            // 
            this.panelInnerBoxWhite.BackColor = System.Drawing.Color.Transparent;
            this.panelInnerBoxWhite.BackgroundImage = global::BNITapCash.Properties.Resources.BG_PUTIH2;
            this.panelInnerBoxWhite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelInnerBoxWhite.Controls.Add(this.panelBox);
            this.panelInnerBoxWhite.Controls.Add(this.panelLine);
            this.panelInnerBoxWhite.Controls.Add(this.label4);
            this.panelInnerBoxWhite.Controls.Add(this.tarifMuatan);
            this.panelInnerBoxWhite.Controls.Add(this.panel3);
            this.panelInnerBoxWhite.Controls.Add(this.label1);
            this.panelInnerBoxWhite.Controls.Add(this.datetimeIn);
            this.panelInnerBoxWhite.Controls.Add(this.panel4);
            this.panelInnerBoxWhite.Controls.Add(this.btnMinimize);
            this.panelInnerBoxWhite.Controls.Add(this.labelBackToLogin);
            this.panelInnerBoxWhite.Controls.Add(this.buttonLogout);
            this.panelInnerBoxWhite.Controls.Add(this.btnClear);
            this.panelInnerBoxWhite.Controls.Add(this.btnSave);
            this.panelInnerBoxWhite.Controls.Add(this.lineTopInnerbox);
            this.panelInnerBoxWhite.Controls.Add(this.cash);
            this.panelInnerBoxWhite.Controls.Add(this.nonCash);
            this.panelInnerBoxWhite.Controls.Add(this.labelTotalTarif);
            this.panelInnerBoxWhite.Controls.Add(this.labelMetodePembayaran);
            this.panelInnerBoxWhite.Controls.Add(this.totalTarif00);
            this.panelInnerBoxWhite.Controls.Add(this.RPTotalTarif);
            this.panelInnerBoxWhite.Controls.Add(this.logoPelindo);
            this.panelInnerBoxWhite.Controls.Add(this.btnClose);
            this.panelInnerBoxWhite.Controls.Add(this.txtGrandTotal);
            this.panelInnerBoxWhite.Controls.Add(this.panelTotalTarifGreen);
            this.panelInnerBoxWhite.Location = new System.Drawing.Point(83, 64);
            this.panelInnerBoxWhite.Name = "panelInnerBoxWhite";
            this.panelInnerBoxWhite.Size = new System.Drawing.Size(1200, 600);
            this.panelInnerBoxWhite.TabIndex = 5;
            // 
            // panelBox
            // 
            this.panelBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBox.Controls.Add(this.label2);
            this.panelBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panelBox.Location = new System.Drawing.Point(33, 113);
            this.panelBox.Name = "panelBox";
            this.panelBox.Size = new System.Drawing.Size(643, 328);
            this.panelBox.TabIndex = 95;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(44, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jumlah Orang";
            // 
            // panelLine
            // 
            this.panelLine.BackColor = System.Drawing.Color.Red;
            this.panelLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLine.ForeColor = System.Drawing.Color.Red;
            this.panelLine.Location = new System.Drawing.Point(794, 318);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(370, 2);
            this.panelLine.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.label4.Location = new System.Drawing.Point(796, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 93;
            this.label4.Text = "Tarif Muatan";
            // 
            // tarifMuatan
            // 
            this.tarifMuatan.BackColor = System.Drawing.Color.White;
            this.tarifMuatan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tarifMuatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tarifMuatan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tarifMuatan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarifMuatan.ForeColor = System.Drawing.Color.DimGray;
            this.tarifMuatan.FormattingEnabled = true;
            this.tarifMuatan.Location = new System.Drawing.Point(802, 254);
            this.tarifMuatan.Name = "tarifMuatan";
            this.tarifMuatan.Size = new System.Drawing.Size(360, 26);
            this.tarifMuatan.TabIndex = 92;
            this.tarifMuatan.SelectionChangeCommitted += new System.EventHandler(this.tarifMuatan_SelectionChangeCommitted);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Location = new System.Drawing.Point(799, 290);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 1);
            this.panel3.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.label1.Location = new System.Drawing.Point(796, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 80;
            this.label1.Text = "Waktu Masuk";
            // 
            // datetimeIn
            // 
            this.datetimeIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.datetimeIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datetimeIn.Cursor = System.Windows.Forms.Cursors.No;
            this.datetimeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimeIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(135)))));
            this.datetimeIn.Location = new System.Drawing.Point(807, 152);
            this.datetimeIn.MaximumSize = new System.Drawing.Size(350, 40);
            this.datetimeIn.MinimumSize = new System.Drawing.Size(350, 40);
            this.datetimeIn.Name = "datetimeIn";
            this.datetimeIn.ReadOnly = true;
            this.datetimeIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.datetimeIn.Size = new System.Drawing.Size(350, 28);
            this.datetimeIn.TabIndex = 79;
            this.datetimeIn.Text = "- - -  00:00:00";
            this.datetimeIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.panel4.Location = new System.Drawing.Point(802, 140);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(360, 60);
            this.panel4.TabIndex = 81;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Image = global::BNITapCash.Properties.Resources.minimize_button;
            this.btnMinimize.Location = new System.Drawing.Point(1108, 11);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(40, 30);
            this.btnMinimize.TabIndex = 77;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // labelBackToLogin
            // 
            this.labelBackToLogin.AutoSize = true;
            this.labelBackToLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelBackToLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBackToLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelBackToLogin.Location = new System.Drawing.Point(76, 524);
            this.labelBackToLogin.Name = "labelBackToLogin";
            this.labelBackToLogin.Size = new System.Drawing.Size(72, 20);
            this.labelBackToLogin.TabIndex = 76;
            this.labelBackToLogin.Text = "Kembali";
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogout.BackgroundImage = global::BNITapCash.Properties.Resources.back_button;
            this.buttonLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogout.Location = new System.Drawing.Point(33, 516);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(40, 40);
            this.buttonLogout.TabIndex = 75;
            this.buttonLogout.TabStop = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClear.Location = new System.Drawing.Point(793, 507);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(180, 45);
            this.btnClear.TabIndex = 74;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(193)))), ((int)(((byte)(30)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(165)))), ((int)(((byte)(44)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(165)))), ((int)(((byte)(44)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(985, 507);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 45);
            this.btnSave.TabIndex = 73;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lineTopInnerbox
            // 
            this.lineTopInnerbox.BackColor = System.Drawing.Color.LightGray;
            this.lineTopInnerbox.ForeColor = System.Drawing.Color.DimGray;
            this.lineTopInnerbox.Location = new System.Drawing.Point(33, 95);
            this.lineTopInnerbox.Name = "lineTopInnerbox";
            this.lineTopInnerbox.Size = new System.Drawing.Size(1132, 1);
            this.lineTopInnerbox.TabIndex = 52;
            // 
            // cash
            // 
            this.cash.AutoSize = true;
            this.cash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cash.ForeColor = System.Drawing.Color.Gray;
            this.cash.Location = new System.Drawing.Point(281, 507);
            this.cash.MaximumSize = new System.Drawing.Size(186, 45);
            this.cash.MinimumSize = new System.Drawing.Size(186, 45);
            this.cash.Name = "cash";
            this.cash.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.cash.Size = new System.Drawing.Size(186, 45);
            this.cash.TabIndex = 61;
            this.cash.TabStop = true;
            this.cash.Text = "Tunai";
            this.cash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cash.UseVisualStyleBackColor = false;
            // 
            // nonCash
            // 
            this.nonCash.AutoSize = true;
            this.nonCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(197)))), ((int)(((byte)(244)))));
            this.nonCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nonCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nonCash.ForeColor = System.Drawing.Color.White;
            this.nonCash.Location = new System.Drawing.Point(490, 507);
            this.nonCash.Name = "nonCash";
            this.nonCash.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.nonCash.Size = new System.Drawing.Size(186, 45);
            this.nonCash.TabIndex = 62;
            this.nonCash.TabStop = true;
            this.nonCash.Text = "Non Tunai";
            this.nonCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nonCash.UseVisualStyleBackColor = false;
            // 
            // labelTotalTarif
            // 
            this.labelTotalTarif.AutoSize = true;
            this.labelTotalTarif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalTarif.ForeColor = System.Drawing.Color.Red;
            this.labelTotalTarif.Location = new System.Drawing.Point(794, 349);
            this.labelTotalTarif.Name = "labelTotalTarif";
            this.labelTotalTarif.Size = new System.Drawing.Size(241, 16);
            this.labelTotalTarif.TabIndex = 70;
            this.labelTotalTarif.Text = "JUMLAH YANG HARUS DIBAYAR";
            // 
            // labelMetodePembayaran
            // 
            this.labelMetodePembayaran.AutoSize = true;
            this.labelMetodePembayaran.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMetodePembayaran.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.labelMetodePembayaran.Location = new System.Drawing.Point(277, 476);
            this.labelMetodePembayaran.Name = "labelMetodePembayaran";
            this.labelMetodePembayaran.Size = new System.Drawing.Size(152, 16);
            this.labelMetodePembayaran.TabIndex = 69;
            this.labelMetodePembayaran.Text = "Metode Pembayaran";
            // 
            // totalTarif00
            // 
            this.totalTarif00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.totalTarif00.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalTarif00.Cursor = System.Windows.Forms.Cursors.Hand;
            this.totalTarif00.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTarif00.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.totalTarif00.Location = new System.Drawing.Point(1091, 390);
            this.totalTarif00.Name = "totalTarif00";
            this.totalTarif00.ReadOnly = true;
            this.totalTarif00.Size = new System.Drawing.Size(57, 33);
            this.totalTarif00.TabIndex = 59;
            this.totalTarif00.Text = ",00.";
            this.totalTarif00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalTarif00.Click += new System.EventHandler(this.totalTarif00_Click);
            // 
            // RPTotalTarif
            // 
            this.RPTotalTarif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.RPTotalTarif.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RPTotalTarif.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RPTotalTarif.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPTotalTarif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.RPTotalTarif.Location = new System.Drawing.Point(804, 390);
            this.RPTotalTarif.Name = "RPTotalTarif";
            this.RPTotalTarif.ReadOnly = true;
            this.RPTotalTarif.Size = new System.Drawing.Size(58, 33);
            this.RPTotalTarif.TabIndex = 56;
            this.RPTotalTarif.Text = "Rp.";
            this.RPTotalTarif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.RPTotalTarif.Click += new System.EventHandler(this.RPTotalTarif_Click);
            // 
            // logoPelindo
            // 
            this.logoPelindo.BackgroundImage = global::BNITapCash.Properties.Resources.pelindo4;
            this.logoPelindo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPelindo.Location = new System.Drawing.Point(99, 12);
            this.logoPelindo.Name = "logoPelindo";
            this.logoPelindo.Size = new System.Drawing.Size(130, 68);
            this.logoPelindo.TabIndex = 51;
            this.logoPelindo.TabStop = false;
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
            this.btnClose.Location = new System.Drawing.Point(1148, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 30);
            this.btnClose.TabIndex = 64;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.txtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.txtGrandTotal.Location = new System.Drawing.Point(801, 390);
            this.txtGrandTotal.MaximumSize = new System.Drawing.Size(290, 45);
            this.txtGrandTotal.MinimumSize = new System.Drawing.Size(290, 45);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(290, 33);
            this.txtGrandTotal.TabIndex = 60;
            this.txtGrandTotal.Text = "0";
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGrandTotal.Click += new System.EventHandler(this.txtGrandTotal_Click);
            // 
            // panelTotalTarifGreen
            // 
            this.panelTotalTarifGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.panelTotalTarifGreen.Location = new System.Drawing.Point(797, 381);
            this.panelTotalTarifGreen.Name = "panelTotalTarifGreen";
            this.panelTotalTarifGreen.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelTotalTarifGreen.Size = new System.Drawing.Size(360, 60);
            this.panelTotalTarifGreen.TabIndex = 71;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "E-Payment Notification Tray";
            this.notifyIcon.Visible = true;
            // 
            // Pedestrian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BNITapCash.Properties.Resources.BG_BIRU;
            this.ClientSize = new System.Drawing.Size(1366, 728);
            this.Controls.Add(this.panelInnerBoxWhite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pedestrian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedestrian";
            this.panelInnerBoxWhite.ResumeLayout(false);
            this.panelInnerBoxWhite.PerformLayout();
            this.panelBox.ResumeLayout(false);
            this.panelBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPelindo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInnerBoxWhite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tarifMuatan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox datetimeIn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label labelBackToLogin;
        private System.Windows.Forms.PictureBox buttonLogout;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel lineTopInnerbox;
        private System.Windows.Forms.RadioButton cash;
        private System.Windows.Forms.RadioButton nonCash;
        private System.Windows.Forms.Label labelTotalTarif;
        private System.Windows.Forms.Label labelMetodePembayaran;
        private System.Windows.Forms.TextBox totalTarif00;
        private System.Windows.Forms.TextBox RPTotalTarif;
        private System.Windows.Forms.PictureBox logoPelindo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Panel panelTotalTarifGreen;
        private System.Windows.Forms.Panel panelLine;
        private System.Windows.Forms.Panel panelBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}