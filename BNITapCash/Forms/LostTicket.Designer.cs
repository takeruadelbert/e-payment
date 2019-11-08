namespace BNITapCash.Forms
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.logout = new System.Windows.Forms.PictureBox();
            this.btnLsTicketClear = new System.Windows.Forms.Button();
            this.btnLsTicketSave = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cash = new System.Windows.Forms.RadioButton();
            this.nonCash = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelWaktuKeluar = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.labelNoPlat = new System.Windows.Forms.Label();
            this.labelTipeKendaraan = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tipe_kendaraan = new System.Windows.Forms.ComboBox();
            this.nomor_plat = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.webcam = new System.Windows.Forms.PictureBox();
            this.waktu_keluar = new System.Windows.Forms.TextBox();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1286, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 30);
            this.button2.TabIndex = 40;
            this.button2.Text = "_";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1326, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 30);
            this.button1.TabIndex = 39;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(18, 119);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(250, 150);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::BNITapCash.Properties.Resources.BG_PUTIH2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.logout);
            this.panel1.Controls.Add(this.btnLsTicketClear);
            this.panel1.Controls.Add(this.btnLsTicketSave);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.cash);
            this.panel1.Controls.Add(this.nonCash);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.labelWaktuKeluar);
            this.panel1.Controls.Add(this.textBox9);
            this.panel1.Controls.Add(this.labelNoPlat);
            this.panel1.Controls.Add(this.labelTipeKendaraan);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tipe_kendaraan);
            this.panel1.Controls.Add(this.nomor_plat);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.pictureBox11);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.webcam);
            this.panel1.Controls.Add(this.waktu_keluar);
            this.panel1.Controls.Add(this.txtGrandTotal);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(83, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 600);
            this.panel1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(629, 533);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 20);
            this.label8.TabIndex = 76;
            this.label8.Text = "Back To Kasir";
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.Transparent;
            this.logout.BackgroundImage = global::BNITapCash.Properties.Resources.back_button;
            this.logout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout.Location = new System.Drawing.Point(586, 525);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(40, 40);
            this.logout.TabIndex = 75;
            this.logout.TabStop = false;
            this.logout.Click += new System.EventHandler(this.back_to_cashier_Click);
            // 
            // btnLsTicketClear
            // 
            this.btnLsTicketClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLsTicketClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLsTicketClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLsTicketClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnLsTicketClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnLsTicketClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLsTicketClear.Font = new System.Drawing.Font("Poppins ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLsTicketClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLsTicketClear.Location = new System.Drawing.Point(797, 524);
            this.btnLsTicketClear.Name = "btnLsTicketClear";
            this.btnLsTicketClear.Size = new System.Drawing.Size(180, 45);
            this.btnLsTicketClear.TabIndex = 74;
            this.btnLsTicketClear.Text = "CLEAR";
            this.btnLsTicketClear.UseVisualStyleBackColor = false;
            this.btnLsTicketClear.Click += new System.EventHandler(this.btnLsTicketClear_Click);
            // 
            // btnLsTicketSave
            // 
            this.btnLsTicketSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(193)))), ((int)(((byte)(30)))));
            this.btnLsTicketSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLsTicketSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLsTicketSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(165)))), ((int)(((byte)(44)))));
            this.btnLsTicketSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(165)))), ((int)(((byte)(44)))));
            this.btnLsTicketSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLsTicketSave.Font = new System.Drawing.Font("Poppins ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLsTicketSave.ForeColor = System.Drawing.Color.White;
            this.btnLsTicketSave.Location = new System.Drawing.Point(989, 524);
            this.btnLsTicketSave.Name = "btnLsTicketSave";
            this.btnLsTicketSave.Size = new System.Drawing.Size(180, 45);
            this.btnLsTicketSave.TabIndex = 73;
            this.btnLsTicketSave.Text = "SAVE";
            this.btnLsTicketSave.UseVisualStyleBackColor = false;
            this.btnLsTicketSave.Click += new System.EventHandler(this.btnLsTicketSave_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.LightGray;
            this.panel9.ForeColor = System.Drawing.Color.DimGray;
            this.panel9.Location = new System.Drawing.Point(33, 95);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1132, 1);
            this.panel9.TabIndex = 52;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(792, 379);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 16);
            this.label7.TabIndex = 70;
            this.label7.Text = "TOTAL TARIF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(345, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 16);
            this.label6.TabIndex = 69;
            this.label6.Text = "Metode Pembayaran";
            // 
            // labelWaktuKeluar
            // 
            this.labelWaktuKeluar.AutoSize = true;
            this.labelWaktuKeluar.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWaktuKeluar.ForeColor = System.Drawing.Color.DimGray;
            this.labelWaktuKeluar.Location = new System.Drawing.Point(323, 216);
            this.labelWaktuKeluar.Name = "labelWaktuKeluar";
            this.labelWaktuKeluar.Size = new System.Drawing.Size(194, 23);
            this.labelWaktuKeluar.TabIndex = 68;
            this.labelWaktuKeluar.Text = "Waktu Keluar Kendaraan";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.textBox9.Location = new System.Drawing.Point(1089, 420);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(57, 33);
            this.textBox9.TabIndex = 59;
            this.textBox9.Text = ",00.";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelNoPlat
            // 
            this.labelNoPlat.AutoSize = true;
            this.labelNoPlat.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoPlat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.labelNoPlat.Location = new System.Drawing.Point(610, 119);
            this.labelNoPlat.Name = "labelNoPlat";
            this.labelNoPlat.Size = new System.Drawing.Size(91, 23);
            this.labelNoPlat.TabIndex = 67;
            this.labelNoPlat.Text = "Nomor Plat";
            // 
            // labelTipeKendaraan
            // 
            this.labelTipeKendaraan.AutoSize = true;
            this.labelTipeKendaraan.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipeKendaraan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(134)))));
            this.labelTipeKendaraan.Location = new System.Drawing.Point(325, 119);
            this.labelTipeKendaraan.Name = "labelTipeKendaraan";
            this.labelTipeKendaraan.Size = new System.Drawing.Size(127, 23);
            this.labelTipeKendaraan.TabIndex = 66;
            this.labelTipeKendaraan.Text = "Tipe Kendaraan";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(138)))), ((int)(((byte)(9)))));
            this.textBox7.Location = new System.Drawing.Point(810, 420);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(40, 33);
            this.textBox7.TabIndex = 56;
            this.textBox7.Text = "Rp.";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point(615, 179);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 1);
            this.panel2.TabIndex = 53;
            // 
            // tipe_kendaraan
            // 
            this.tipe_kendaraan.BackColor = System.Drawing.Color.White;
            this.tipe_kendaraan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tipe_kendaraan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipe_kendaraan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tipe_kendaraan.Font = new System.Drawing.Font("Poppins Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipe_kendaraan.ForeColor = System.Drawing.Color.DimGray;
            this.tipe_kendaraan.FormattingEnabled = true;
            this.tipe_kendaraan.Location = new System.Drawing.Point(331, 141);
            this.tipe_kendaraan.Name = "tipe_kendaraan";
            this.tipe_kendaraan.Size = new System.Drawing.Size(256, 34);
            this.tipe_kendaraan.TabIndex = 57;
            // 
            // nomor_plat
            // 
            this.nomor_plat.BackColor = System.Drawing.Color.White;
            this.nomor_plat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nomor_plat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nomor_plat.Font = new System.Drawing.Font("Poppins Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomor_plat.ForeColor = System.Drawing.Color.DimGray;
            this.nomor_plat.Location = new System.Drawing.Point(615, 153);
            this.nomor_plat.Name = "nomor_plat";
            this.nomor_plat.Size = new System.Drawing.Size(260, 23);
            this.nomor_plat.TabIndex = 54;
            this.nomor_plat.Text = "Nomor Plat Kendaraan";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.LightGray;
            this.panel13.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel13.Location = new System.Drawing.Point(328, 179);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(260, 1);
            this.panel13.TabIndex = 55;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackgroundImage = global::BNITapCash.Properties.Resources.pelindo4;
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox11.Location = new System.Drawing.Point(99, 12);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(130, 68);
            this.pictureBox11.TabIndex = 51;
            this.pictureBox11.TabStop = false;
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
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
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
            // waktu_keluar
            // 
            this.waktu_keluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.waktu_keluar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.waktu_keluar.Cursor = System.Windows.Forms.Cursors.No;
            this.waktu_keluar.Font = new System.Drawing.Font("Poppins Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waktu_keluar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.waktu_keluar.Location = new System.Drawing.Point(331, 256);
            this.waktu_keluar.MaximumSize = new System.Drawing.Size(350, 40);
            this.waktu_keluar.MinimumSize = new System.Drawing.Size(350, 40);
            this.waktu_keluar.Name = "waktu_keluar";
            this.waktu_keluar.ReadOnly = true;
            this.waktu_keluar.Size = new System.Drawing.Size(350, 36);
            this.waktu_keluar.TabIndex = 58;
            this.waktu_keluar.Text = "- - -  00:00:00";
            this.waktu_keluar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(191)))));
            this.panel3.Location = new System.Drawing.Point(795, 411);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel3.Size = new System.Drawing.Size(360, 60);
            this.panel3.TabIndex = 71;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panel5.Location = new System.Drawing.Point(326, 244);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(360, 60);
            this.panel5.TabIndex = 72;
            // 
            // LostTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::BNITapCash.Properties.Resources.BG_BIRU;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1366, 728);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LostTicket";
            this.Text = "LostTicket";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webcam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.RadioButton cash;
        private System.Windows.Forms.RadioButton nonCash;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelWaktuKeluar;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label labelNoPlat;
        private System.Windows.Forms.Label labelTipeKendaraan;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox tipe_kendaraan;
        private System.Windows.Forms.TextBox nomor_plat;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox webcam;
        private System.Windows.Forms.TextBox waktu_keluar;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnLsTicketClear;
        private System.Windows.Forms.Button btnLsTicketSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox logout;
    }
}