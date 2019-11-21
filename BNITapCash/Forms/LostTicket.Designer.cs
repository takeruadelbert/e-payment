﻿namespace BNITapCash.Forms
{
    partial class LostTicket
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
            this.LiveCamera = new System.Windows.Forms.PictureBox();
            this.panelWaktuKendaraanKeluarRed = new System.Windows.Forms.Panel();
            this.panelTotalTarifGreen = new System.Windows.Forms.Panel();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.waktu_keluar = new System.Windows.Forms.TextBox();
            this.webcam = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.logoPelindo = new System.Windows.Forms.PictureBox();
            this.lineTipeKendaraan = new System.Windows.Forms.Panel();
            this.nomor_plat = new System.Windows.Forms.TextBox();
            this.tipe_kendaraan = new System.Windows.Forms.ComboBox();
            this.lineNomorPlat = new System.Windows.Forms.Panel();
            this.RPTotalTarif = new System.Windows.Forms.TextBox();
            this.labelTipeKendaraan = new System.Windows.Forms.Label();
            this.labelNoPlat = new System.Windows.Forms.Label();
            this.totalTarif00 = new System.Windows.Forms.TextBox();
            this.labelWaktuKeluar = new System.Windows.Forms.Label();
            this.labelMetodePembayaran = new System.Windows.Forms.Label();
            this.labelTotalTarif = new System.Windows.Forms.Label();
            this.nonCash = new System.Windows.Forms.RadioButton();
            this.cash = new System.Windows.Forms.RadioButton();
            this.lineTopInnerbox = new System.Windows.Forms.Panel();
            this.btnLsTicketSave = new System.Windows.Forms.Button();
            this.btnLsTicketClear = new System.Windows.Forms.Button();
            this.buttonBackToCashier = new System.Windows.Forms.PictureBox();
            this.labelBackToLogin = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panelInnerBoxWhite = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.LiveCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPelindo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBackToCashier)).BeginInit();
            this.panelInnerBoxWhite.SuspendLayout();
            this.SuspendLayout();
            // 
            // LiveCamera
            // 
            this.LiveCamera.BackgroundImage = global::BNITapCash.Properties.Resources.there_is_no_connected_camera;
            this.LiveCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LiveCamera.Location = new System.Drawing.Point(18, 119);
            this.LiveCamera.Name = "LiveCamera";
            this.LiveCamera.Size = new System.Drawing.Size(250, 150);
            this.LiveCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LiveCamera.TabIndex = 2;
            this.LiveCamera.TabStop = false;
            // 
            // panelWaktuKendaraanKeluarRed
            // 
            this.panelWaktuKendaraanKeluarRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelWaktuKendaraanKeluarRed.Location = new System.Drawing.Point(326, 244);
            this.panelWaktuKendaraanKeluarRed.Name = "panelWaktuKendaraanKeluarRed";
            this.panelWaktuKendaraanKeluarRed.Size = new System.Drawing.Size(360, 60);
            this.panelWaktuKendaraanKeluarRed.TabIndex = 72;
            // 
            // panelTotalTarifGreen
            // 
            this.panelTotalTarifGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.panelTotalTarifGreen.Location = new System.Drawing.Point(795, 411);
            this.panelTotalTarifGreen.Name = "panelTotalTarifGreen";
            this.panelTotalTarifGreen.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelTotalTarifGreen.Size = new System.Drawing.Size(360, 60);
            this.panelTotalTarifGreen.TabIndex = 71;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.txtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.txtGrandTotal.Location = new System.Drawing.Point(799, 420);
            this.txtGrandTotal.MaximumSize = new System.Drawing.Size(290, 45);
            this.txtGrandTotal.MinimumSize = new System.Drawing.Size(290, 45);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(290, 33);
            this.txtGrandTotal.TabIndex = 60;
            this.txtGrandTotal.Text = "0";
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // waktu_keluar
            // 
            this.waktu_keluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.waktu_keluar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.waktu_keluar.Cursor = System.Windows.Forms.Cursors.No;
            this.waktu_keluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waktu_keluar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.waktu_keluar.Location = new System.Drawing.Point(331, 256);
            this.waktu_keluar.MaximumSize = new System.Drawing.Size(350, 40);
            this.waktu_keluar.MinimumSize = new System.Drawing.Size(350, 40);
            this.waktu_keluar.Name = "waktu_keluar";
            this.waktu_keluar.ReadOnly = true;
            this.waktu_keluar.Size = new System.Drawing.Size(350, 28);
            this.waktu_keluar.TabIndex = 58;
            this.waktu_keluar.Text = "- - -  00:00:00";
            this.waktu_keluar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // webcam
            // 
            this.webcam.BackColor = System.Drawing.Color.White;
            this.webcam.BackgroundImage = global::BNITapCash.Properties.Resources.no_image;
            this.webcam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.webcam.ImageLocation = "";
            this.webcam.Location = new System.Drawing.Point(947, 12);
            this.webcam.Name = "webcam";
            this.webcam.Size = new System.Drawing.Size(73, 71);
            this.webcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.webcam.TabIndex = 63;
            this.webcam.TabStop = false;
            this.webcam.Visible = false;
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
            // lineTipeKendaraan
            // 
            this.lineTipeKendaraan.BackColor = System.Drawing.Color.LightGray;
            this.lineTipeKendaraan.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lineTipeKendaraan.Location = new System.Drawing.Point(328, 179);
            this.lineTipeKendaraan.Name = "lineTipeKendaraan";
            this.lineTipeKendaraan.Size = new System.Drawing.Size(260, 1);
            this.lineTipeKendaraan.TabIndex = 55;
            // 
            // nomor_plat
            // 
            this.nomor_plat.BackColor = System.Drawing.Color.White;
            this.nomor_plat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nomor_plat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nomor_plat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomor_plat.ForeColor = System.Drawing.Color.DimGray;
            this.nomor_plat.Location = new System.Drawing.Point(615, 150);
            this.nomor_plat.Name = "nomor_plat";
            this.nomor_plat.Size = new System.Drawing.Size(260, 17);
            this.nomor_plat.TabIndex = 54;
            this.nomor_plat.Text = "Nomor Plat Kendaraan";
            this.nomor_plat.Click += new System.EventHandler(this.nomor_plat_Click);
            this.nomor_plat.TextChanged += new System.EventHandler(this.nomor_plat_TextChanged);
            // 
            // tipe_kendaraan
            // 
            this.tipe_kendaraan.BackColor = System.Drawing.Color.White;
            this.tipe_kendaraan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tipe_kendaraan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipe_kendaraan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tipe_kendaraan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipe_kendaraan.ForeColor = System.Drawing.Color.DimGray;
            this.tipe_kendaraan.FormattingEnabled = true;
            this.tipe_kendaraan.Location = new System.Drawing.Point(331, 143);
            this.tipe_kendaraan.Name = "tipe_kendaraan";
            this.tipe_kendaraan.Size = new System.Drawing.Size(256, 26);
            this.tipe_kendaraan.TabIndex = 57;
            this.tipe_kendaraan.SelectionChangeCommitted += new System.EventHandler(this.tipe_kendaraan_SelectionChangeCommitted);
            // 
            // lineNomorPlat
            // 
            this.lineNomorPlat.BackColor = System.Drawing.Color.LightGray;
            this.lineNomorPlat.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lineNomorPlat.Location = new System.Drawing.Point(615, 179);
            this.lineNomorPlat.Name = "lineNomorPlat";
            this.lineNomorPlat.Size = new System.Drawing.Size(260, 1);
            this.lineNomorPlat.TabIndex = 53;
            // 
            // RPTotalTarif
            // 
            this.RPTotalTarif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.RPTotalTarif.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RPTotalTarif.Cursor = System.Windows.Forms.Cursors.No;
            this.RPTotalTarif.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPTotalTarif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.RPTotalTarif.Location = new System.Drawing.Point(810, 420);
            this.RPTotalTarif.Name = "RPTotalTarif";
            this.RPTotalTarif.ReadOnly = true;
            this.RPTotalTarif.Size = new System.Drawing.Size(40, 33);
            this.RPTotalTarif.TabIndex = 56;
            this.RPTotalTarif.Text = "Rp.";
            this.RPTotalTarif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelTipeKendaraan
            // 
            this.labelTipeKendaraan.AutoSize = true;
            this.labelTipeKendaraan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipeKendaraan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.labelTipeKendaraan.Location = new System.Drawing.Point(325, 119);
            this.labelTipeKendaraan.Name = "labelTipeKendaraan";
            this.labelTipeKendaraan.Size = new System.Drawing.Size(119, 16);
            this.labelTipeKendaraan.TabIndex = 66;
            this.labelTipeKendaraan.Text = "Tipe Kendaraan";
            // 
            // labelNoPlat
            // 
            this.labelNoPlat.AutoSize = true;
            this.labelNoPlat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoPlat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.labelNoPlat.Location = new System.Drawing.Point(610, 119);
            this.labelNoPlat.Name = "labelNoPlat";
            this.labelNoPlat.Size = new System.Drawing.Size(85, 16);
            this.labelNoPlat.TabIndex = 67;
            this.labelNoPlat.Text = "Nomor Plat";
            // 
            // totalTarif00
            // 
            this.totalTarif00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.totalTarif00.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalTarif00.Cursor = System.Windows.Forms.Cursors.No;
            this.totalTarif00.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTarif00.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.totalTarif00.Location = new System.Drawing.Point(1089, 420);
            this.totalTarif00.Name = "totalTarif00";
            this.totalTarif00.ReadOnly = true;
            this.totalTarif00.Size = new System.Drawing.Size(57, 33);
            this.totalTarif00.TabIndex = 59;
            this.totalTarif00.Text = ",00.";
            this.totalTarif00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelWaktuKeluar
            // 
            this.labelWaktuKeluar.AutoSize = true;
            this.labelWaktuKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWaktuKeluar.ForeColor = System.Drawing.Color.DimGray;
            this.labelWaktuKeluar.Location = new System.Drawing.Point(323, 216);
            this.labelWaktuKeluar.Name = "labelWaktuKeluar";
            this.labelWaktuKeluar.Size = new System.Drawing.Size(178, 16);
            this.labelWaktuKeluar.TabIndex = 68;
            this.labelWaktuKeluar.Text = "Waktu Keluar Kendaraan";
            // 
            // labelMetodePembayaran
            // 
            this.labelMetodePembayaran.AutoSize = true;
            this.labelMetodePembayaran.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMetodePembayaran.ForeColor = System.Drawing.Color.DimGray;
            this.labelMetodePembayaran.Location = new System.Drawing.Point(345, 380);
            this.labelMetodePembayaran.Name = "labelMetodePembayaran";
            this.labelMetodePembayaran.Size = new System.Drawing.Size(152, 16);
            this.labelMetodePembayaran.TabIndex = 69;
            this.labelMetodePembayaran.Text = "Metode Pembayaran";
            // 
            // labelTotalTarif
            // 
            this.labelTotalTarif.AutoSize = true;
            this.labelTotalTarif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalTarif.ForeColor = System.Drawing.Color.DimGray;
            this.labelTotalTarif.Location = new System.Drawing.Point(792, 379);
            this.labelTotalTarif.Name = "labelTotalTarif";
            this.labelTotalTarif.Size = new System.Drawing.Size(105, 16);
            this.labelTotalTarif.TabIndex = 70;
            this.labelTotalTarif.Text = "TOTAL TARIF";
            // 
            // nonCash
            // 
            this.nonCash.AutoSize = true;
            this.nonCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(197)))), ((int)(((byte)(244)))));
            this.nonCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nonCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nonCash.ForeColor = System.Drawing.Color.White;
            this.nonCash.Location = new System.Drawing.Point(558, 411);
            this.nonCash.Name = "nonCash";
            this.nonCash.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.nonCash.Size = new System.Drawing.Size(186, 45);
            this.nonCash.TabIndex = 62;
            this.nonCash.TabStop = true;
            this.nonCash.Text = "Non Tunai";
            this.nonCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nonCash.UseVisualStyleBackColor = false;
            // 
            // cash
            // 
            this.cash.AutoSize = true;
            this.cash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cash.ForeColor = System.Drawing.Color.Gray;
            this.cash.Location = new System.Drawing.Point(349, 411);
            this.cash.MaximumSize = new System.Drawing.Size(202, 62);
            this.cash.MinimumSize = new System.Drawing.Size(202, 62);
            this.cash.Name = "cash";
            this.cash.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.cash.Size = new System.Drawing.Size(202, 62);
            this.cash.TabIndex = 61;
            this.cash.TabStop = true;
            this.cash.Text = "Tunai";
            this.cash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cash.UseVisualStyleBackColor = false;
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
            // btnLsTicketSave
            // 
            this.btnLsTicketSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(193)))), ((int)(((byte)(30)))));
            this.btnLsTicketSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLsTicketSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLsTicketSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(165)))), ((int)(((byte)(44)))));
            this.btnLsTicketSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(165)))), ((int)(((byte)(44)))));
            this.btnLsTicketSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLsTicketSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLsTicketSave.ForeColor = System.Drawing.Color.White;
            this.btnLsTicketSave.Location = new System.Drawing.Point(989, 524);
            this.btnLsTicketSave.Name = "btnLsTicketSave";
            this.btnLsTicketSave.Size = new System.Drawing.Size(180, 45);
            this.btnLsTicketSave.TabIndex = 73;
            this.btnLsTicketSave.Text = "SAVE";
            this.btnLsTicketSave.UseVisualStyleBackColor = false;
            this.btnLsTicketSave.Click += new System.EventHandler(this.btnLsTicketSave_Click);
            // 
            // btnLsTicketClear
            // 
            this.btnLsTicketClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLsTicketClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLsTicketClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLsTicketClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnLsTicketClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnLsTicketClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLsTicketClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLsTicketClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLsTicketClear.Location = new System.Drawing.Point(797, 524);
            this.btnLsTicketClear.Name = "btnLsTicketClear";
            this.btnLsTicketClear.Size = new System.Drawing.Size(180, 45);
            this.btnLsTicketClear.TabIndex = 74;
            this.btnLsTicketClear.Text = "CLEAR";
            this.btnLsTicketClear.UseVisualStyleBackColor = false;
            this.btnLsTicketClear.Click += new System.EventHandler(this.btnLsTicketClear_Click);
            // 
            // buttonBackToCashier
            // 
            this.buttonBackToCashier.BackColor = System.Drawing.Color.Transparent;
            this.buttonBackToCashier.BackgroundImage = global::BNITapCash.Properties.Resources.back_button;
            this.buttonBackToCashier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBackToCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBackToCashier.Location = new System.Drawing.Point(586, 525);
            this.buttonBackToCashier.Name = "buttonBackToCashier";
            this.buttonBackToCashier.Size = new System.Drawing.Size(40, 40);
            this.buttonBackToCashier.TabIndex = 75;
            this.buttonBackToCashier.TabStop = false;
            this.buttonBackToCashier.Click += new System.EventHandler(this.back_to_cashier_Click);
            // 
            // labelBackToLogin
            // 
            this.labelBackToLogin.AutoSize = true;
            this.labelBackToLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelBackToLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBackToLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelBackToLogin.Location = new System.Drawing.Point(629, 533);
            this.labelBackToLogin.Name = "labelBackToLogin";
            this.labelBackToLogin.Size = new System.Drawing.Size(119, 20);
            this.labelBackToLogin.TabIndex = 76;
            this.labelBackToLogin.Text = "Back To Kasir";
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
            // panelInnerBoxWhite
            // 
            this.panelInnerBoxWhite.BackColor = System.Drawing.Color.Transparent;
            this.panelInnerBoxWhite.BackgroundImage = global::BNITapCash.Properties.Resources.BG_PUTIH2;
            this.panelInnerBoxWhite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelInnerBoxWhite.Controls.Add(this.btnMinimize);
            this.panelInnerBoxWhite.Controls.Add(this.labelBackToLogin);
            this.panelInnerBoxWhite.Controls.Add(this.buttonBackToCashier);
            this.panelInnerBoxWhite.Controls.Add(this.btnLsTicketClear);
            this.panelInnerBoxWhite.Controls.Add(this.btnLsTicketSave);
            this.panelInnerBoxWhite.Controls.Add(this.lineTopInnerbox);
            this.panelInnerBoxWhite.Controls.Add(this.cash);
            this.panelInnerBoxWhite.Controls.Add(this.nonCash);
            this.panelInnerBoxWhite.Controls.Add(this.labelTotalTarif);
            this.panelInnerBoxWhite.Controls.Add(this.labelMetodePembayaran);
            this.panelInnerBoxWhite.Controls.Add(this.labelWaktuKeluar);
            this.panelInnerBoxWhite.Controls.Add(this.totalTarif00);
            this.panelInnerBoxWhite.Controls.Add(this.labelNoPlat);
            this.panelInnerBoxWhite.Controls.Add(this.labelTipeKendaraan);
            this.panelInnerBoxWhite.Controls.Add(this.RPTotalTarif);
            this.panelInnerBoxWhite.Controls.Add(this.lineNomorPlat);
            this.panelInnerBoxWhite.Controls.Add(this.tipe_kendaraan);
            this.panelInnerBoxWhite.Controls.Add(this.nomor_plat);
            this.panelInnerBoxWhite.Controls.Add(this.lineTipeKendaraan);
            this.panelInnerBoxWhite.Controls.Add(this.logoPelindo);
            this.panelInnerBoxWhite.Controls.Add(this.btnClose);
            this.panelInnerBoxWhite.Controls.Add(this.webcam);
            this.panelInnerBoxWhite.Controls.Add(this.waktu_keluar);
            this.panelInnerBoxWhite.Controls.Add(this.txtGrandTotal);
            this.panelInnerBoxWhite.Controls.Add(this.panelTotalTarifGreen);
            this.panelInnerBoxWhite.Controls.Add(this.panelWaktuKendaraanKeluarRed);
            this.panelInnerBoxWhite.Controls.Add(this.LiveCamera);
            this.panelInnerBoxWhite.Location = new System.Drawing.Point(83, 64);
            this.panelInnerBoxWhite.Name = "panelInnerBoxWhite";
            this.panelInnerBoxWhite.Size = new System.Drawing.Size(1200, 600);
            this.panelInnerBoxWhite.TabIndex = 3;
            // 
            // LostTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::BNITapCash.Properties.Resources.BG_BIRU;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1366, 728);
            this.Controls.Add(this.panelInnerBoxWhite);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LostTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LostTicket";
            ((System.ComponentModel.ISupportInitialize)(this.LiveCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPelindo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBackToCashier)).EndInit();
            this.panelInnerBoxWhite.ResumeLayout(false);
            this.panelInnerBoxWhite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LiveCamera;
        private System.Windows.Forms.Panel panelWaktuKendaraanKeluarRed;
        private System.Windows.Forms.Panel panelTotalTarifGreen;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.TextBox waktu_keluar;
        private System.Windows.Forms.PictureBox webcam;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox logoPelindo;
        private System.Windows.Forms.Panel lineTipeKendaraan;
        private System.Windows.Forms.TextBox nomor_plat;
        private System.Windows.Forms.ComboBox tipe_kendaraan;
        private System.Windows.Forms.Panel lineNomorPlat;
        private System.Windows.Forms.TextBox RPTotalTarif;
        private System.Windows.Forms.Label labelTipeKendaraan;
        private System.Windows.Forms.Label labelNoPlat;
        private System.Windows.Forms.TextBox totalTarif00;
        private System.Windows.Forms.Label labelWaktuKeluar;
        private System.Windows.Forms.Label labelMetodePembayaran;
        private System.Windows.Forms.Label labelTotalTarif;
        private System.Windows.Forms.RadioButton nonCash;
        private System.Windows.Forms.RadioButton cash;
        private System.Windows.Forms.Panel lineTopInnerbox;
        private System.Windows.Forms.Button btnLsTicketSave;
        private System.Windows.Forms.Button btnLsTicketClear;
        private System.Windows.Forms.PictureBox buttonBackToCashier;
        private System.Windows.Forms.Label labelBackToLogin;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panelInnerBoxWhite;
    }
}