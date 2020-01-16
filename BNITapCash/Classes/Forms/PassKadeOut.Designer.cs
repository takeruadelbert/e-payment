namespace BNITapCash.Classes.Forms
{
    partial class PassKadeOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassKadeOut));
            this.panelInnerBoxWhite = new System.Windows.Forms.Panel();
            this.cash = new System.Windows.Forms.RadioButton();
            this.nonCash = new System.Windows.Forms.RadioButton();
            this.labelMetodePembayaran = new System.Windows.Forms.Label();
            this.labelNote = new System.Windows.Forms.Label();
            this.note = new System.Windows.Forms.RichTextBox();
            this.liveCamera = new Vlc.DotNet.Forms.VlcControl();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.labelBackToLogin = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lineTopInnerbox = new System.Windows.Forms.Panel();
            this.labelTotalTarif = new System.Windows.Forms.Label();
            this.totalTarif00 = new System.Windows.Forms.TextBox();
            this.labelNoPlat = new System.Windows.Forms.Label();
            this.labelTipeKendaraan = new System.Windows.Forms.Label();
            this.RPTotalTarif = new System.Windows.Forms.TextBox();
            this.lineNomorPlat = new System.Windows.Forms.Panel();
            this.tipe_kendaraan = new System.Windows.Forms.ComboBox();
            this.nomor_plat = new System.Windows.Forms.TextBox();
            this.lineTipeKendaraan = new System.Windows.Forms.Panel();
            this.logoPelindo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.webcam = new System.Windows.Forms.PictureBox();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.panelTotalTarifGreen = new System.Windows.Forms.Panel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelInnerBoxWhite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.liveCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPelindo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInnerBoxWhite
            // 
            this.panelInnerBoxWhite.BackColor = System.Drawing.Color.Transparent;
            this.panelInnerBoxWhite.BackgroundImage = global::BNITapCash.Properties.Resources.BG_PUTIH2;
            this.panelInnerBoxWhite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelInnerBoxWhite.Controls.Add(this.cash);
            this.panelInnerBoxWhite.Controls.Add(this.nonCash);
            this.panelInnerBoxWhite.Controls.Add(this.labelMetodePembayaran);
            this.panelInnerBoxWhite.Controls.Add(this.labelNote);
            this.panelInnerBoxWhite.Controls.Add(this.note);
            this.panelInnerBoxWhite.Controls.Add(this.liveCamera);
            this.panelInnerBoxWhite.Controls.Add(this.btnMinimize);
            this.panelInnerBoxWhite.Controls.Add(this.labelBackToLogin);
            this.panelInnerBoxWhite.Controls.Add(this.buttonBack);
            this.panelInnerBoxWhite.Controls.Add(this.btnClear);
            this.panelInnerBoxWhite.Controls.Add(this.btnSave);
            this.panelInnerBoxWhite.Controls.Add(this.lineTopInnerbox);
            this.panelInnerBoxWhite.Controls.Add(this.labelTotalTarif);
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
            this.panelInnerBoxWhite.Controls.Add(this.txtGrandTotal);
            this.panelInnerBoxWhite.Controls.Add(this.panelTotalTarifGreen);
            this.panelInnerBoxWhite.Location = new System.Drawing.Point(83, 64);
            this.panelInnerBoxWhite.Name = "panelInnerBoxWhite";
            this.panelInnerBoxWhite.Size = new System.Drawing.Size(1200, 600);
            this.panelInnerBoxWhite.TabIndex = 5;
            // 
            // cash
            // 
            this.cash.AutoSize = true;
            this.cash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cash.ForeColor = System.Drawing.Color.Gray;
            this.cash.Location = new System.Drawing.Point(337, 396);
            this.cash.MaximumSize = new System.Drawing.Size(186, 45);
            this.cash.MinimumSize = new System.Drawing.Size(186, 45);
            this.cash.Name = "cash";
            this.cash.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.cash.Size = new System.Drawing.Size(186, 45);
            this.cash.TabIndex = 81;
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
            this.nonCash.Location = new System.Drawing.Point(546, 396);
            this.nonCash.Name = "nonCash";
            this.nonCash.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.nonCash.Size = new System.Drawing.Size(186, 45);
            this.nonCash.TabIndex = 82;
            this.nonCash.TabStop = true;
            this.nonCash.Text = "Non Tunai";
            this.nonCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nonCash.UseVisualStyleBackColor = false;
            // 
            // labelMetodePembayaran
            // 
            this.labelMetodePembayaran.AutoSize = true;
            this.labelMetodePembayaran.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMetodePembayaran.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.labelMetodePembayaran.Location = new System.Drawing.Point(333, 365);
            this.labelMetodePembayaran.Name = "labelMetodePembayaran";
            this.labelMetodePembayaran.Size = new System.Drawing.Size(152, 16);
            this.labelMetodePembayaran.TabIndex = 83;
            this.labelMetodePembayaran.Text = "Metode Pembayaran";
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.labelNote.Location = new System.Drawing.Point(332, 200);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(87, 16);
            this.labelNote.TabIndex = 80;
            this.labelNote.Text = "Keterangan";
            // 
            // note
            // 
            this.note.Location = new System.Drawing.Point(334, 232);
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(360, 81);
            this.note.TabIndex = 79;
            this.note.Text = "";
            // 
            // liveCamera
            // 
            this.liveCamera.BackColor = System.Drawing.Color.Black;
            this.liveCamera.BackgroundImage = global::BNITapCash.Properties.Resources.there_is_no_connected_camera;
            this.liveCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.liveCamera.Location = new System.Drawing.Point(32, 121);
            this.liveCamera.Name = "liveCamera";
            this.liveCamera.Size = new System.Drawing.Size(250, 150);
            this.liveCamera.Spu = -1;
            this.liveCamera.TabIndex = 78;
            this.liveCamera.Text = "Live Camera";
            this.liveCamera.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("liveCamera.VlcLibDirectory")));
            this.liveCamera.VlcMediaplayerOptions = null;
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
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Transparent;
            this.buttonBack.BackgroundImage = global::BNITapCash.Properties.Resources.back_button;
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.Location = new System.Drawing.Point(33, 516);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(40, 40);
            this.buttonBack.TabIndex = 75;
            this.buttonBack.TabStop = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
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
            this.btnClear.Location = new System.Drawing.Point(776, 524);
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
            this.btnSave.Location = new System.Drawing.Point(968, 524);
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
            // labelTotalTarif
            // 
            this.labelTotalTarif.AutoSize = true;
            this.labelTotalTarif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalTarif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.labelTotalTarif.Location = new System.Drawing.Point(773, 349);
            this.labelTotalTarif.Name = "labelTotalTarif";
            this.labelTotalTarif.Size = new System.Drawing.Size(105, 16);
            this.labelTotalTarif.TabIndex = 70;
            this.labelTotalTarif.Text = "TOTAL TARIF";
            // 
            // totalTarif00
            // 
            this.totalTarif00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.totalTarif00.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalTarif00.Cursor = System.Windows.Forms.Cursors.No;
            this.totalTarif00.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTarif00.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.totalTarif00.Location = new System.Drawing.Point(1070, 390);
            this.totalTarif00.Name = "totalTarif00";
            this.totalTarif00.ReadOnly = true;
            this.totalTarif00.Size = new System.Drawing.Size(57, 33);
            this.totalTarif00.TabIndex = 59;
            this.totalTarif00.Text = ",00.";
            this.totalTarif00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelNoPlat
            // 
            this.labelNoPlat.AutoSize = true;
            this.labelNoPlat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoPlat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.labelNoPlat.Location = new System.Drawing.Point(770, 120);
            this.labelNoPlat.Name = "labelNoPlat";
            this.labelNoPlat.Size = new System.Drawing.Size(85, 16);
            this.labelNoPlat.TabIndex = 67;
            this.labelNoPlat.Text = "Nomor Plat";
            // 
            // labelTipeKendaraan
            // 
            this.labelTipeKendaraan.AutoSize = true;
            this.labelTipeKendaraan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipeKendaraan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.labelTipeKendaraan.Location = new System.Drawing.Point(331, 120);
            this.labelTipeKendaraan.Name = "labelTipeKendaraan";
            this.labelTipeKendaraan.Size = new System.Drawing.Size(119, 16);
            this.labelTipeKendaraan.TabIndex = 66;
            this.labelTipeKendaraan.Text = "Tipe Kendaraan";
            // 
            // RPTotalTarif
            // 
            this.RPTotalTarif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.RPTotalTarif.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RPTotalTarif.Cursor = System.Windows.Forms.Cursors.No;
            this.RPTotalTarif.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPTotalTarif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.RPTotalTarif.Location = new System.Drawing.Point(791, 390);
            this.RPTotalTarif.Name = "RPTotalTarif";
            this.RPTotalTarif.ReadOnly = true;
            this.RPTotalTarif.Size = new System.Drawing.Size(40, 33);
            this.RPTotalTarif.TabIndex = 56;
            this.RPTotalTarif.Text = "Rp.";
            this.RPTotalTarif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lineNomorPlat
            // 
            this.lineNomorPlat.BackColor = System.Drawing.Color.LightGray;
            this.lineNomorPlat.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lineNomorPlat.Location = new System.Drawing.Point(775, 180);
            this.lineNomorPlat.Name = "lineNomorPlat";
            this.lineNomorPlat.Size = new System.Drawing.Size(360, 1);
            this.lineNomorPlat.TabIndex = 53;
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
            this.tipe_kendaraan.Location = new System.Drawing.Point(337, 144);
            this.tipe_kendaraan.Name = "tipe_kendaraan";
            this.tipe_kendaraan.Size = new System.Drawing.Size(360, 26);
            this.tipe_kendaraan.TabIndex = 57;
            this.tipe_kendaraan.SelectionChangeCommitted += new System.EventHandler(this.tipe_kendaraan_SelectionChangeCommitted);
            // 
            // nomor_plat
            // 
            this.nomor_plat.BackColor = System.Drawing.Color.White;
            this.nomor_plat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nomor_plat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nomor_plat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomor_plat.ForeColor = System.Drawing.Color.DimGray;
            this.nomor_plat.Location = new System.Drawing.Point(775, 151);
            this.nomor_plat.Name = "nomor_plat";
            this.nomor_plat.Size = new System.Drawing.Size(360, 17);
            this.nomor_plat.TabIndex = 54;
            this.nomor_plat.Text = "Nomor Plat Kendaraan";
            this.nomor_plat.Click += new System.EventHandler(this.nomor_plat_Click);
            this.nomor_plat.TextChanged += new System.EventHandler(this.nomor_plat_TextChanged);
            // 
            // lineTipeKendaraan
            // 
            this.lineTipeKendaraan.BackColor = System.Drawing.Color.LightGray;
            this.lineTipeKendaraan.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lineTipeKendaraan.Location = new System.Drawing.Point(334, 180);
            this.lineTipeKendaraan.Name = "lineTipeKendaraan";
            this.lineTipeKendaraan.Size = new System.Drawing.Size(360, 1);
            this.lineTipeKendaraan.TabIndex = 55;
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
            // txtGrandTotal
            // 
            this.txtGrandTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.txtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.txtGrandTotal.Location = new System.Drawing.Point(780, 390);
            this.txtGrandTotal.MaximumSize = new System.Drawing.Size(290, 45);
            this.txtGrandTotal.MinimumSize = new System.Drawing.Size(290, 45);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(290, 33);
            this.txtGrandTotal.TabIndex = 60;
            this.txtGrandTotal.Text = "0";
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panelTotalTarifGreen
            // 
            this.panelTotalTarifGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.panelTotalTarifGreen.Location = new System.Drawing.Point(776, 381);
            this.panelTotalTarifGreen.Name = "panelTotalTarifGreen";
            this.panelTotalTarifGreen.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelTotalTarifGreen.Size = new System.Drawing.Size(360, 60);
            this.panelTotalTarifGreen.TabIndex = 71;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // PassKadeOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BNITapCash.Properties.Resources.BG_BIRU;
            this.ClientSize = new System.Drawing.Size(1366, 728);
            this.Controls.Add(this.panelInnerBoxWhite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PassKadeOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PassKadeOut";
            this.panelInnerBoxWhite.ResumeLayout(false);
            this.panelInnerBoxWhite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.liveCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPelindo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInnerBoxWhite;
        private Vlc.DotNet.Forms.VlcControl liveCamera;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label labelBackToLogin;
        private System.Windows.Forms.PictureBox buttonBack;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel lineTopInnerbox;
        private System.Windows.Forms.Label labelTotalTarif;
        private System.Windows.Forms.TextBox totalTarif00;
        private System.Windows.Forms.Label labelNoPlat;
        private System.Windows.Forms.Label labelTipeKendaraan;
        private System.Windows.Forms.TextBox RPTotalTarif;
        private System.Windows.Forms.Panel lineNomorPlat;
        private System.Windows.Forms.ComboBox tipe_kendaraan;
        private System.Windows.Forms.TextBox nomor_plat;
        private System.Windows.Forms.Panel lineTipeKendaraan;
        private System.Windows.Forms.PictureBox logoPelindo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox webcam;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Panel panelTotalTarifGreen;
        private System.Windows.Forms.RichTextBox note;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.RadioButton cash;
        private System.Windows.Forms.RadioButton nonCash;
        private System.Windows.Forms.Label labelMetodePembayaran;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}