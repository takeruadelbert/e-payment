using BNITapCash.API;
using BNITapCash.Classes.API.request;
using BNITapCash.Classes.API.response;
using BNITapCash.Classes.Helper;
using BNITapCash.ConstantVariable;
using BNITapCash.Helper;
using BNITapCash.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BNITapCash.Classes.Forms
{
    public partial class PassKadeIn : Form, EventFormHandler
    {
        private Login home;
        private RESTAPI restApi;
        private readonly string MasterDataFileParkingIn = TKHelper.GetApplicationExecutableDirectoryName() + Constant.PATH_FILE_MASTER_DATA_PARKING_IN;
        private readonly string MasterDataFileParkingOut = TKHelper.GetApplicationExecutableDirectoryName() + Constant.PATH_FILE_MASTER_DATA_PARKING_OUT;
        private readonly string IpAddressServer = Properties.Settings.Default.IPAddressServer;

        private Dictionary<string, int> outloadDict = new Dictionary<string, int>();
        private int VehicleFare = 0;
        private int PassKadeFare = 0;

        public PassKadeIn(Login home)
        {
            InitializeComponent();
            this.home = home;
            this.restApi = new RESTAPI();
            Initialize();
        }

        private void Initialize()
        {
            InitializeVehicleType();
            InitializeOutload();
            CameraHelper.StartIpCamera(liveCamera);
            nonCash.Checked = true;
        }

        private void InitializeVehicleType()
        {
            try
            {
                tipe_kendaraan.Items.Add("- Pilih Tipe Kendaraan -");
                using (StreamReader reader = new StreamReader(MasterDataFileParkingOut))
                {
                    string json = reader.ReadToEnd();
                    dynamic vehicleTypes = JsonConvert.DeserializeObject(json);
                    foreach (var types in vehicleTypes["VehicleTypes"])
                    {
                        tipe_kendaraan.Items.Add(types);
                    }
                    tipe_kendaraan.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_FETCH_VEHICLE_TYPE_DATA, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeOutload()
        {
            try
            {
                tarifMuatan.Items.Add("- Pilih Tipe Muatan -");
                using (StreamReader reader = new StreamReader(MasterDataFileParkingIn))
                {
                    string json = reader.ReadToEnd();
                    dynamic outloads = JsonConvert.DeserializeObject(json);
                    foreach (var outload in outloads["cargo"])
                    {
                        int outloadFare = outload["fare"];
                        string outloadType = outload["name"];
                        string outloadTypeWithFare = outload["name"] + " - " + TKHelper.IDRWithCurrency(outloadFare.ToString());
                        tarifMuatan.Items.Add(outloadTypeWithFare);
                        outloadDict.Add(outloadTypeWithFare, outloadFare);
                    }
                    tarifMuatan.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_FETCH_OUTLOAD, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tipe_kendaraan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tipe_kendaraan.SelectedIndex != 0)
            {
                var ApiUrl = Properties.Resources.RequestVehicleFarePassKadeAPIURL;
                string vehicleType = tipe_kendaraan.Text;
                PassKadeInVehicleFareRequest passKadeInVehicleFareRequest = new PassKadeInVehicleFareRequest(vehicleType);
                var sentParam = JsonConvert.SerializeObject(passKadeInVehicleFareRequest);

                DataResponseObject response = (DataResponseObject)restApi.post(IpAddressServer, ApiUrl, true, sentParam);
                if (response != null)
                {
                    if (response.Status == 206)
                    {
                        PassKadeInVehicleFare passKadeInVehicleFare = JsonConvert.DeserializeObject<PassKadeInVehicleFare>(response.Data.ToString());

                        txtPassKadeFare.Text = TKHelper.IDR(passKadeInVehicleFare.Fare.ToString());
                        VehicleFare = passKadeInVehicleFare.Fare;
                        int grandTotal = VehicleFare + PassKadeFare;
                        txtGrandTotal.Text = TKHelper.IDR(grandTotal.ToString());
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_CONNECT_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tarifMuatan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tarifMuatan.SelectedIndex != 0)
            {
                string outloadType = tarifMuatan.Text;
                PassKadeFare = TKHelper.DictionaryGetValueByKey(outloadDict, outloadType);
                int grandTotal = PassKadeFare + VehicleFare;
                txtGrandTotal.Text = TKHelper.IDR(grandTotal.ToString());
            }
        }

        private void TextListener(string field, bool is_textchanged = false)
        {
            if (!is_textchanged)
            {
                if (field == "nomor plat kendaraan")
                {
                    nomor_plat.Clear();
                }
                if (field == "scan tiket/kartu")
                {
                    ticket.Clear();
                }
            }
            nomor_plat.ForeColor = Color.FromArgb(78, 184, 206);
            ticket.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void ticket_Click(object sender, EventArgs e)
        {
            if (ticket.Text.ToLower() == "scan tiket/kartu")
                this.TextListener("scan tiket/kartu");
        }

        private void nomor_plat_TextChanged(object sender, EventArgs e)
        {
            this.TextListener("nomor plat kendaraan", true);
            nomor_plat.CharacterCasing = CharacterCasing.Upper;
        }

        private void nomor_plat_Click(object sender, EventArgs e)
        {
            if (nomor_plat.Text.ToLower() == "nomor plat kendaraan")
                this.TextListener("nomor plat kendaraan");
        }

        public void UnsubscribeEvents()
        {
            tipe_kendaraan.SelectionChangeCommitted -= tipe_kendaraan_SelectionChangeCommitted;
            tarifMuatan.SelectionChangeCommitted -= tarifMuatan_SelectionChangeCommitted;

            buttonLogout.Click -= buttonLogout_Click;
            btnClose.Click -= btnClose_Click;
            btnMinimize.Click -= btnMinimize_Click;
            btnClear.Click -= btnClear_Click;

            ticket.Click -= ticket_Click;
            nomor_plat.Click -= nomor_plat_Click;
            nomor_plat.TextChanged -= nomor_plat_TextChanged;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constant.CONFIRMATION_MESSAGE_BEFORE_EXIT, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.RememberMe = "no";
                Properties.Settings.Default.Save();

                CameraHelper.StopIpCamera(liveCamera);

                // redirect to sign-in form
                Hide();
                this.home.Clear();
                this.home.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constant.CONFIRMATION_MESSAGE_BEFORE_EXIT, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Dispose();
                System.Environment.Exit(1);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tarifMuatan.SelectedIndex = 0;
            tipe_kendaraan.SelectedIndex = 0;
            txtGrandTotal.Text = "0";
            datetimeIn.Text = "- - -  00:00:00";
            txtPassKadeFare.Text = "0";
            nonCash.Checked = true;
            nomor_plat.Text = "Nomor Plat Kendaraan";
            nomor_plat.CharacterCasing = CharacterCasing.Lower;
            ticket.Text = "Scan Tiket/Kartu";
        }
    }
}
