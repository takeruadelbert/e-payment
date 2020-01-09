namespace BNITapCash.Forms
{
    partial class FreePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreePass));
            this.panel1 = new System.Windows.Forms.Panel();
            this.liveCamera = new Vlc.DotNet.Forms.VlcControl();
            this.webcam = new System.Windows.Forms.PictureBox();
            this.labelBackToLogin = new System.Windows.Forms.Label();
            this.buttonBackToCashier = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.supervisorCard = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vehicleType = new System.Windows.Forms.ComboBox();
            this.plateNumber = new System.Windows.Forms.TextBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.barcode = new System.Windows.Forms.TextBox();
            this.timeOut = new System.Windows.Forms.TextBox();
            this.timeIn = new System.Windows.Forms.TextBox();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.listBarcodeSuggestion = new System.Windows.Forms.ComboBox();
            this.PictFace = new System.Windows.Forms.PictureBox();
            this.PictVehicle = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lineTopInnerbox = new System.Windows.Forms.Panel();
            this.logoPelindo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.liveCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBackToCashier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPelindo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::BNITapCash.Properties.Resources.BG_PUTIH2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.liveCamera);
            this.panel1.Controls.Add(this.webcam);
            this.panel1.Controls.Add(this.labelBackToLogin);
            this.panel1.Controls.Add(this.buttonBackToCashier);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.supervisorCard);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.vehicleType);
            this.panel1.Controls.Add(this.plateNumber);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.barcode);
            this.panel1.Controls.Add(this.timeOut);
            this.panel1.Controls.Add(this.timeIn);
            this.panel1.Controls.Add(this.txtGrandTotal);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.listBarcodeSuggestion);
            this.panel1.Controls.Add(this.PictFace);
            this.panel1.Controls.Add(this.PictVehicle);
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.lineTopInnerbox);
            this.panel1.Controls.Add(this.logoPelindo);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(83, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 600);
            this.panel1.TabIndex = 0;
            // 
            // liveCamera
            // 
            this.liveCamera.BackColor = System.Drawing.Color.Black;
            this.liveCamera.BackgroundImage = global::BNITapCash.Properties.Resources.there_is_no_connected_camera;
            this.liveCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.liveCamera.Location = new System.Drawing.Point(35, 435);
            this.liveCamera.Name = "liveCamera";
            this.liveCamera.Size = new System.Drawing.Size(250, 150);
            this.liveCamera.Spu = -1;
            this.liveCamera.TabIndex = 138;
            this.liveCamera.Text = "Live Camera";
            this.liveCamera.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("liveCamera.VlcLibDirectory")));
            this.liveCamera.VlcMediaplayerOptions = null;
            // 
            // webcam
            // 
            this.webcam.BackColor = System.Drawing.Color.White;
            this.webcam.BackgroundImage = global::BNITapCash.Properties.Resources.no_image;
            this.webcam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.webcam.ImageLocation = "";
            this.webcam.Location = new System.Drawing.Point(660, 9);
            this.webcam.Name = "webcam";
            this.webcam.Size = new System.Drawing.Size(73, 71);
            this.webcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.webcam.TabIndex = 137;
            this.webcam.TabStop = false;
            this.webcam.Visible = false;
            // 
            // labelBackToLogin
            // 
            this.labelBackToLogin.AutoSize = true;
            this.labelBackToLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelBackToLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBackToLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelBackToLogin.Location = new System.Drawing.Point(661, 532);
            this.labelBackToLogin.Name = "labelBackToLogin";
            this.labelBackToLogin.Size = new System.Drawing.Size(72, 20);
            this.labelBackToLogin.TabIndex = 136;
            this.labelBackToLogin.Text = "Kembali";
            // 
            // buttonBackToCashier
            // 
            this.buttonBackToCashier.BackColor = System.Drawing.Color.Transparent;
            this.buttonBackToCashier.BackgroundImage = global::BNITapCash.Properties.Resources.back_button;
            this.buttonBackToCashier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBackToCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBackToCashier.Location = new System.Drawing.Point(618, 524);
            this.buttonBackToCashier.Name = "buttonBackToCashier";
            this.buttonBackToCashier.Size = new System.Drawing.Size(40, 40);
            this.buttonBackToCashier.TabIndex = 135;
            this.buttonBackToCashier.TabStop = false;
            this.buttonBackToCashier.Click += new System.EventHandler(this.buttonBackToCashier_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.label6.Location = new System.Drawing.Point(797, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 16);
            this.label6.TabIndex = 133;
            this.label6.Text = "Kartu Supervisor";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightGray;
            this.panel6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel6.Location = new System.Drawing.Point(801, 175);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(352, 1);
            this.panel6.TabIndex = 132;
            // 
            // supervisorCard
            // 
            this.supervisorCard.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.supervisorCard.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.supervisorCard.BackColor = System.Drawing.Color.White;
            this.supervisorCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.supervisorCard.CausesValidation = false;
            this.supervisorCard.Cursor = System.Windows.Forms.Cursors.No;
            this.supervisorCard.Enabled = false;
            this.supervisorCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supervisorCard.ForeColor = System.Drawing.Color.DimGray;
            this.supervisorCard.Location = new System.Drawing.Point(800, 143);
            this.supervisorCard.MaximumSize = new System.Drawing.Size(352, 25);
            this.supervisorCard.MinimumSize = new System.Drawing.Size(352, 25);
            this.supervisorCard.Name = "supervisorCard";
            this.supervisorCard.Size = new System.Drawing.Size(352, 17);
            this.supervisorCard.TabIndex = 131;
            this.supervisorCard.Text = "Tempel Kartu Supervisor";
            this.supervisorCard.TextChanged += new System.EventHandler(this.supervisorCard_TextChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.AllowDrop = true;
            this.comboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(801, 145);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(261, 21);
            this.comboBox2.TabIndex = 134;
            this.comboBox2.Visible = false;
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
            this.btnClear.Location = new System.Drawing.Point(797, 524);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(180, 45);
            this.btnClear.TabIndex = 130;
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
            this.btnSave.Location = new System.Drawing.Point(989, 524);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 45);
            this.btnSave.TabIndex = 129;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(792, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 16);
            this.label7.TabIndex = 124;
            this.label7.Text = "TOTAL TARIF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(792, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 16);
            this.label5.TabIndex = 122;
            this.label5.Text = "Waktu Keluar Kendaraan";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.textBox9.Location = new System.Drawing.Point(1089, 422);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(57, 33);
            this.textBox9.TabIndex = 114;
            this.textBox9.Text = ",00.";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.label4.Location = new System.Drawing.Point(795, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 121;
            this.label4.Text = "Nomor Plat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.label3.Location = new System.Drawing.Point(340, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 120;
            this.label3.Text = "Tipe Kendaraan";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.textBox7.Location = new System.Drawing.Point(810, 422);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(40, 33);
            this.textBox7.TabIndex = 101;
            this.textBox7.Text = "Rp.";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.label2.Location = new System.Drawing.Point(340, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 119;
            this.label2.Text = "Barcode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(342, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 16);
            this.label1.TabIndex = 118;
            this.label1.Text = "Waktu Masuk Kendaraan";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point(800, 252);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 1);
            this.panel2.TabIndex = 95;
            // 
            // vehicleType
            // 
            this.vehicleType.BackColor = System.Drawing.Color.White;
            this.vehicleType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vehicleType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vehicleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleType.ForeColor = System.Drawing.Color.DimGray;
            this.vehicleType.FormattingEnabled = true;
            this.vehicleType.Location = new System.Drawing.Point(346, 219);
            this.vehicleType.Name = "vehicleType";
            this.vehicleType.Size = new System.Drawing.Size(352, 26);
            this.vehicleType.TabIndex = 102;
            this.vehicleType.SelectionChangeCommitted += new System.EventHandler(this.vehicleType_SelectionChangeCommitted);
            // 
            // plateNumber
            // 
            this.plateNumber.BackColor = System.Drawing.Color.White;
            this.plateNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.plateNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.plateNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plateNumber.ForeColor = System.Drawing.Color.DimGray;
            this.plateNumber.Location = new System.Drawing.Point(800, 226);
            this.plateNumber.Name = "plateNumber";
            this.plateNumber.Size = new System.Drawing.Size(352, 17);
            this.plateNumber.TabIndex = 97;
            this.plateNumber.Text = "Nomor Plat Kendaraan";
            this.plateNumber.Click += new System.EventHandler(this.plateNumber_Click);
            this.plateNumber.TextChanged += new System.EventHandler(this.plateNumber_TextChanged);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.LightGray;
            this.panel13.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel13.Location = new System.Drawing.Point(343, 252);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(352, 1);
            this.panel13.TabIndex = 98;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Location = new System.Drawing.Point(344, 175);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(352, 1);
            this.panel3.TabIndex = 94;
            // 
            // barcode
            // 
            this.barcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.barcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.barcode.BackColor = System.Drawing.Color.White;
            this.barcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.barcode.CausesValidation = false;
            this.barcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcode.ForeColor = System.Drawing.Color.DimGray;
            this.barcode.Location = new System.Drawing.Point(345, 143);
            this.barcode.MaximumSize = new System.Drawing.Size(352, 25);
            this.barcode.MinimumSize = new System.Drawing.Size(352, 25);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(352, 17);
            this.barcode.TabIndex = 93;
            this.barcode.Text = "Scan Barcode";
            this.barcode.Click += new System.EventHandler(this.barcode_Click);
            this.barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.barcode_KeyDown);
            // 
            // timeOut
            // 
            this.timeOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.timeOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeOut.Cursor = System.Windows.Forms.Cursors.No;
            this.timeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.timeOut.Location = new System.Drawing.Point(800, 312);
            this.timeOut.MaximumSize = new System.Drawing.Size(350, 40);
            this.timeOut.MinimumSize = new System.Drawing.Size(350, 40);
            this.timeOut.Name = "timeOut";
            this.timeOut.ReadOnly = true;
            this.timeOut.Size = new System.Drawing.Size(350, 28);
            this.timeOut.TabIndex = 103;
            this.timeOut.Text = "- - -  00:00:00";
            this.timeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeIn
            // 
            this.timeIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.timeIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeIn.Cursor = System.Windows.Forms.Cursors.No;
            this.timeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(135)))));
            this.timeIn.Location = new System.Drawing.Point(353, 312);
            this.timeIn.MaximumSize = new System.Drawing.Size(350, 40);
            this.timeIn.MinimumSize = new System.Drawing.Size(350, 40);
            this.timeIn.Name = "timeIn";
            this.timeIn.ReadOnly = true;
            this.timeIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeIn.Size = new System.Drawing.Size(350, 28);
            this.timeIn.TabIndex = 100;
            this.timeIn.Text = "- - -  00:00:00";
            this.timeIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.txtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.txtGrandTotal.Location = new System.Drawing.Point(799, 422);
            this.txtGrandTotal.MaximumSize = new System.Drawing.Size(290, 45);
            this.txtGrandTotal.MinimumSize = new System.Drawing.Size(290, 45);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(290, 33);
            this.txtGrandTotal.TabIndex = 115;
            this.txtGrandTotal.Text = "0";
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.panel4.Location = new System.Drawing.Point(795, 413);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel4.Size = new System.Drawing.Size(360, 60);
            this.panel4.TabIndex = 125;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.panel5.Location = new System.Drawing.Point(348, 300);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(360, 60);
            this.panel5.TabIndex = 126;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panel9.Location = new System.Drawing.Point(795, 300);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(360, 60);
            this.panel9.TabIndex = 127;
            // 
            // listBarcodeSuggestion
            // 
            this.listBarcodeSuggestion.AllowDrop = true;
            this.listBarcodeSuggestion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBarcodeSuggestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listBarcodeSuggestion.FormattingEnabled = true;
            this.listBarcodeSuggestion.Location = new System.Drawing.Point(344, 145);
            this.listBarcodeSuggestion.Name = "listBarcodeSuggestion";
            this.listBarcodeSuggestion.Size = new System.Drawing.Size(351, 21);
            this.listBarcodeSuggestion.TabIndex = 128;
            this.listBarcodeSuggestion.Visible = false;
            this.listBarcodeSuggestion.SelectedIndexChanged += new System.EventHandler(this.selectBarcode);
            // 
            // PictFace
            // 
            this.PictFace.BackgroundImage = global::BNITapCash.Properties.Resources.no_image;
            this.PictFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictFace.ImageLocation = "";
            this.PictFace.Location = new System.Drawing.Point(35, 122);
            this.PictFace.Name = "PictFace";
            this.PictFace.Size = new System.Drawing.Size(250, 150);
            this.PictFace.TabIndex = 90;
            this.PictFace.TabStop = false;
            // 
            // PictVehicle
            // 
            this.PictVehicle.BackgroundImage = global::BNITapCash.Properties.Resources.no_image;
            this.PictVehicle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictVehicle.ImageLocation = "";
            this.PictVehicle.Location = new System.Drawing.Point(35, 278);
            this.PictVehicle.Name = "PictVehicle";
            this.PictVehicle.Size = new System.Drawing.Size(250, 150);
            this.PictVehicle.TabIndex = 91;
            this.PictVehicle.TabStop = false;
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
            this.btnMinimize.Location = new System.Drawing.Point(1086, 11);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(40, 30);
            this.btnMinimize.TabIndex = 89;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lineTopInnerbox
            // 
            this.lineTopInnerbox.BackColor = System.Drawing.Color.LightGray;
            this.lineTopInnerbox.ForeColor = System.Drawing.Color.DimGray;
            this.lineTopInnerbox.Location = new System.Drawing.Point(11, 95);
            this.lineTopInnerbox.Name = "lineTopInnerbox";
            this.lineTopInnerbox.Size = new System.Drawing.Size(1132, 1);
            this.lineTopInnerbox.TabIndex = 79;
            // 
            // logoPelindo
            // 
            this.logoPelindo.BackgroundImage = global::BNITapCash.Properties.Resources.pelindo4;
            this.logoPelindo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPelindo.Location = new System.Drawing.Point(77, 12);
            this.logoPelindo.Name = "logoPelindo";
            this.logoPelindo.Size = new System.Drawing.Size(130, 68);
            this.logoPelindo.TabIndex = 78;
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
            this.btnClose.Location = new System.Drawing.Point(1126, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 30);
            this.btnClose.TabIndex = 84;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FreePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::BNITapCash.Properties.Resources.BG_BIRU;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 728);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(83, 64);
            this.Name = "FreePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FreePass";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.liveCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBackToCashier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPelindo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel lineTopInnerbox;
        private System.Windows.Forms.PictureBox logoPelindo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox PictFace;
        private System.Windows.Forms.PictureBox PictVehicle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox vehicleType;
        private System.Windows.Forms.TextBox plateNumber;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox barcode;
        private System.Windows.Forms.TextBox timeOut;
        private System.Windows.Forms.TextBox timeIn;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox listBarcodeSuggestion;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox supervisorCard;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label labelBackToLogin;
        private System.Windows.Forms.PictureBox buttonBackToCashier;
        private System.Windows.Forms.PictureBox webcam;
        private Vlc.DotNet.Forms.VlcControl liveCamera;
    }
}