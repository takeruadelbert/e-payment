using BNITapCash.API;
using BNITapCash.Bank.BNI;
using BNITapCash.Bank.DataModel;
using BNITapCash.Card.Mifare;
using BNITapCash.Classes.API.request;
using BNITapCash.Classes.API.response;
using BNITapCash.Classes.Forms.DataModel;
using BNITapCash.ConstantVariable;
using BNITapCash.DB;
using BNITapCash.Helper;
using BNITapCash.Interface;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BNITapCash.Classes.Forms
{
    public partial class Pedestrian : Form, EventFormHandler
    {
        private Login home;
        private BNI bni;
        private MifareCard mifareCard;
        private RESTAPI restApi;
        private DBConnect database;

        private Dictionary<string, int> PedestrianTypes = new Dictionary<string, int>();
        private Dictionary<string, int> Cargos = new Dictionary<string, int>();
        private Dictionary<string, string> CargoTypes = new Dictionary<string, string>();
        private List<string> FreePassTypes = new List<string>();
        private int CargoFare = 0, GrandTotal = 0, PedestrianFare = 0;

        public Pedestrian(Login home)
        {
            InitializeComponent();

            this.home = home;
            this.restApi = new RESTAPI();
            this.database = new DBConnect();
            this.bni = new BNI();
            this.mifareCard = new MifareCard(this);
            this.mifareCard.RunMain();

            InitData();
            InitializePedestrianType();
        }

        private void InitData()
        {
            nonCash.Checked = true;
            datetimeIn.Text = TKHelper.GetCurrentDatetime();
            try
            {
                string masterDataFile = TKHelper.GetApplicationExecutableDirectoryName() + Constant.PATH_FILE_MASTER_DATA_PARKING_IN;
                using (StreamReader reader = new StreamReader(masterDataFile))
                {
                    string json = reader.ReadToEnd();
                    dynamic pedestrianData = JsonConvert.DeserializeObject(json);
                    foreach (var data in pedestrianData["pedestrian"])
                    {
                        string pedestrianName = data["name"];
                        int pedestrianFare = data["fare"];
                        PedestrianTypes.Add(pedestrianName, pedestrianFare);
                    }

                    foreach (string data in pedestrianData["notes"])
                    {
                        FreePassTypes.Add(data);
                    }
                    string defaultText = "- Pilih Tipe Muatan -";
                    tarifMuatan.Items.Add(defaultText);
                    tarifMuatan.Items.Add("Tidak Ada Muatan");
                    tarifMuatan.SelectedIndex = 0;
                    foreach (var data in pedestrianData["cargo"])
                    {
                        string cargoName = data["name"];
                        int cargoFare = data["fare"];
                        string CargoNameWithFare = String.Format("{0} - {1}", cargoName, TKHelper.IDRWithCurrency(cargoFare.ToString()));
                        Cargos.Add(CargoNameWithFare, cargoFare);
                        CargoTypes.Add(CargoNameWithFare, cargoName);
                        tarifMuatan.Items.Add(CargoNameWithFare);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_FETCH_PEDESTRIAN_DATA, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializePedestrianType()
        {
            int locationY = 39, locationYLabel = 41;
            int locationXTextBox = 361, locationXButton = 521;
            int incrementPerRow = 50, counter = 1;
            foreach (var pedestrianType in PedestrianTypes)
            {
                string type = pedestrianType.Key;

                Label label = new Label();
                label.AutoSize = true;
                label.ForeColor = Color.Black;
                label.Location = new Point(226, locationYLabel);
                label.Name = "labelPedestrianType" + counter;
                label.Size = new Size(90, 13);
                label.TabIndex = 2;
                label.Text = type;

                TextBox textBox = new TextBox();
                textBox.Location = new Point(locationXTextBox, locationY);
                textBox.Name = type;
                textBox.RightToLeft = RightToLeft.Yes;
                textBox.Size = new Size(163, 20);
                textBox.TabIndex = 1;
                textBox.KeyPress += OnKeyPressAcceptOnlyNumber;
                textBox.TextChanged += OnTextChangedPedestrianType;

                Button button = new Button();
                button.Enabled = false;
                button.ForeColor = Color.Black;
                button.Location = new Point(locationXButton, locationY);
                button.Name = "buttonPedestrianType" + counter;
                button.Size = new Size(72, 21);
                button.TabIndex = 0;
                button.Text = "Orang";
                button.UseVisualStyleBackColor = true;

                if (type.ToLower() == "free pass")
                {
                    ComboBox comboBox = new ComboBox();
                    comboBox.BackColor = Color.White;
                    comboBox.Cursor = Cursors.Hand;
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.FlatStyle = FlatStyle.Flat;
                    comboBox.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    comboBox.ForeColor = Color.DimGray;
                    comboBox.FormattingEnabled = true;
                    comboBox.Location = new Point(361, 86);
                    comboBox.Name = "comboBoxNote";
                    comboBox.Size = new Size(232, 26);
                    comboBox.TabIndex = 96;
                    string defaultText = "- Pilih Keterangan -";
                    comboBox.Items.Add(defaultText);
                    comboBox.SelectedIndex = 0;
                    if (FreePassTypes.Count > 0)
                    {
                        foreach (string note in FreePassTypes)
                        {
                            comboBox.Items.Add(note);
                        }
                    }

                    panelBox.Controls.Add(comboBox);

                    locationY += incrementPerRow;
                    locationYLabel += incrementPerRow;
                }

                panelBox.Controls.Add(label);
                panelBox.Controls.Add(textBox);
                panelBox.Controls.Add(button);

                locationY += incrementPerRow;
                locationYLabel += incrementPerRow;
                counter++;
            }
        }

        private void OnKeyPressAcceptOnlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            nonCash.Checked = true;
            tarifMuatan.SelectedIndex = 0;
            datetimeIn.Text = TKHelper.GetCurrentDatetime();

            int countPedestrianTypeTextBox = PedestrianTypes.Count;
            if (countPedestrianTypeTextBox > 0)
            {
                foreach (var dataPedestrian in PedestrianTypes)
                {
                    string type = dataPedestrian.Key;
                    TextBox textBox = this.Controls.Find(type, true).FirstOrDefault() as TextBox;
                    textBox.Text = "";
                }
            }
            ComboBox comboBox = Controls.Find("comboBoxNote", true).FirstOrDefault() as ComboBox;
            comboBox.SelectedIndex = 0;

            CargoFare = 0;
            GrandTotal = 0;
            PedestrianFare = 0;
            txtGrandTotal.Text = "0";
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

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constant.CONFIRMATION_MESSAGE_BEFORE_EXIT, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.RememberMe = "no";
                Properties.Settings.Default.Save();

                // redirect to sign-in form
                Hide();
                this.home.Clear();
                this.home.Show();
                Dispose();
                UnsubscribeEvents();
                TKHelper.ClearGarbage();
            }
        }

        private void tarifMuatan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tarifMuatan.SelectedIndex != 0)
            {
                CargoFare = tarifMuatan.SelectedIndex == 1 ? 0 : TKHelper.DictionaryGetValueByKey(Cargos, tarifMuatan.Text);
                SetGrandTotal();
            }
        }

        private void OnTextChangedPedestrianType(object sender, EventArgs e)
        {
            PedestrianFare = CalculateFare();
            SetGrandTotal();
        }

        private int CalculateFare()
        {
            int result = 0;
            int countPedestrianTypeTextBox = PedestrianTypes.Count;
            if (countPedestrianTypeTextBox > 0)
            {
                foreach (var dataPedestrian in PedestrianTypes)
                {
                    string type = dataPedestrian.Key;
                    TextBox textBox = Controls.Find(type, true).FirstOrDefault() as TextBox;
                    string pedestrianType = textBox.Name;
                    int quantity = string.IsNullOrEmpty(textBox.Text.ToString()) ? 0 : int.Parse(textBox.Text.ToString());
                    int fare = dataPedestrian.Value;
                    if (quantity > 0)
                    {
                        result += quantity * fare;
                    }
                }
            }
            return result;
        }

        private void SetGrandTotal()
        {
            GrandTotal = PedestrianFare + CargoFare;
            txtGrandTotal.Text = TKHelper.IDR(GrandTotal.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string feedback = ValidateFields();
            if (feedback == Constant.MESSAGE_OK)
            {
                // check the payment method whether it's cash or non-cash
                string paymentMethod = nonCash.Checked ? "NCSH" : "CASH";

                if (paymentMethod == "NCSH")
                {
                    string bankCode = "BNI";
                    string ipv4 = TKHelper.GetLocalIPAddress();
                    string TIDSettlement = Properties.Settings.Default.TID;
                    string operator_name = Properties.Settings.Default.Username;

                    // need to disconnect SCard from WinsCard.dll beforehand in order to execute further actions to avoid 'Outstanding Connection' Exception.
                    mifareCard.disconnect();

                    DataDeduct responseDeduct = bni.DeductBalance(bankCode, ipv4, TIDSettlement, operator_name);
                    if (!responseDeduct.IsError)
                    {
                        List<PedestrianResponse> pedestrianResponse = SendDataToServer(paymentMethod, bankCode);
                        if (pedestrianResponse != null)
                        {
                            StoreDataToDatabase(responseDeduct, pedestrianResponse);
                            MessageBox.Show(Constant.TRANSACTION_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show(responseDeduct.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    List<PedestrianResponse> pedestrianResponse = SendDataToServer(paymentMethod);
                    if (pedestrianResponse != null)
                    {
                        MessageBox.Show(Constant.TRANSACTION_SUCCESS, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show(feedback, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ValidateFields()
        {
            if (tarifMuatan.SelectedIndex == 0)
            {
                return Constant.WARNING_MESSAGE_OUTLOAD_NOT_EMPTY;
            }
            return Constant.MESSAGE_OK;
        }

        private List<PedestrianResponse> SendDataToServer(string paymentMethod, string bankCode = "")
        {
            List<DataPedestrianTypeQuantity> dataPedestrianTypeQuantities = GetDataPedestrianTypeQuantities();
            string IpAddress = TKHelper.GetLocalIPAddress();
            string DatetimeIn = TKHelper.ConvertDatetimeToDefaultFormat(datetimeIn.Text.ToString());
            string Username = Properties.Settings.Default.Username;
            string CargoType = TKHelper.DictionaryGetValueByKey(CargoTypes, tarifMuatan.Text.ToString());

            PedestrianRequest pedestrianRequest = new PedestrianRequest(dataPedestrianTypeQuantities, IpAddress, DatetimeIn, Username, CargoFare, CargoType, paymentMethod, bankCode);
            var sentParam = JsonConvert.SerializeObject(pedestrianRequest);

            DataResponseArray response = (DataResponseArray)restApi.post(Properties.Settings.Default.IPAddressServer, Properties.Resources.SaveDataPedestrianApiUrl, false, sentParam);
            if (response != null)
            {
                switch (response.Status)
                {
                    case 206:
                        return JsonConvert.DeserializeObject<List<PedestrianResponse>>(response.Data.ToString());
                    default:
                        MessageBox.Show(response.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                }
            }
            else
            {
                MessageBox.Show(Constant.ERROR_MESSAGE_INVALID_RESPONSE_FROM_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void StoreDataToDatabase(DataDeduct dataDeduct, List<PedestrianResponse> pedestrianResponse)
        {
            try
            {
                // store deduct result card to server
                string result = dataDeduct.DeductResult;
                int amount = dataDeduct.Amount;
                string created = dataDeduct.CreatedDatetime;
                string bank = dataDeduct.Bank;
                string ipv4 = dataDeduct.IpAddress;
                string operatorName = dataDeduct.OperatorName;
                string idReader = dataDeduct.IdReader;

                string query = "INSERT INTO deduct_card_results (result, amount, transaction_dt, bank, ipv4, operator, ID_reader, created) VALUES('" +
                    result + "', '" + amount + "', '" + created + "', '" + bank + "', '" + ipv4 + "', '" + operatorName + "', '" + idReader + "', '" + created + "')";

                MySqlCommand cmd = database.Insert(query);

                if (cmd != null)
                {
                    if (pedestrianResponse.Count > 0)
                    {
                        int lastInsertId = (int)cmd.LastInsertedId;
                        foreach (PedestrianResponse pedestrian in pedestrianResponse)
                        {
                            int peopleTicketId = pedestrian.PeopleTicketId;
                            int fare = pedestrian.Total;
                            string query2 = "INSERT INTO deduct_card_result_details (deduct_card_result_id, people_ticket_id, amount, created) VALUES('" +
                                            lastInsertId + "', '" + peopleTicketId + "', '" + fare + "', '" + created + "')";
                            database.Insert(query2);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(Constant.ERROR_MESSAGE_FAIL_TO_SAVE_DATA_INTO_LOCAL_SERVER, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private List<DataPedestrianTypeQuantity> GetDataPedestrianTypeQuantities()
        {
            List<DataPedestrianTypeQuantity> dataPedestrianTypeQuantities = new List<DataPedestrianTypeQuantity>();
            int countPedestrianTypeTextBox = PedestrianTypes.Count;
            if (countPedestrianTypeTextBox > 0)
            {
                foreach (var dataPedestrian in PedestrianTypes)
                {
                    string type = dataPedestrian.Key;
                    TextBox textBox = this.Controls.Find(type, true).FirstOrDefault() as TextBox;
                    string pedestrianType = textBox.Name;
                    int quantity = string.IsNullOrEmpty(textBox.Text.ToString()) ? 0 : int.Parse(textBox.Text.ToString());
                    string note = null;
                    if (pedestrianType.ToLower() == "free pass")
                    {
                        ComboBox comboBox = Controls.Find("comboBoxNote", true).FirstOrDefault() as ComboBox;
                        note = comboBox.Text.ToString();
                    }
                    if (quantity > 0)
                    {
                        dataPedestrianTypeQuantities.Add(new DataPedestrianTypeQuantity(pedestrianType, quantity, note));
                    }
                }
            }
            return dataPedestrianTypeQuantities;
        }

        private void txtGrandTotal_Click(object sender, EventArgs e)
        {
            SeePedestrianDetail();
        }

        private void RPTotalTarif_Click(object sender, EventArgs e)
        {
            SeePedestrianDetail();
        }

        private void totalTarif00_Click(object sender, EventArgs e)
        {
            SeePedestrianDetail();
        }

        private void SeePedestrianDetail()
        {
            List<PedestrianDetail> pedestrianDetails = new List<PedestrianDetail>();

            int countPedestrianTypeTextBox = PedestrianTypes.Count;
            if (countPedestrianTypeTextBox > 0)
            {
                foreach (var dataPedestrian in PedestrianTypes)
                {
                    string type = dataPedestrian.Key;
                    int fare = dataPedestrian.Value;
                    TextBox textBox = this.Controls.Find(type, true).FirstOrDefault() as TextBox;
                    int quantity = string.IsNullOrEmpty(textBox.Text.ToString()) ? 0 : int.Parse(textBox.Text.ToString());
                    if (quantity > 0)
                    {
                        pedestrianDetails.Add(new PedestrianDetail(type, quantity, fare));
                    }
                }
            }

            if (pedestrianDetails.Count <= 0 && tarifMuatan.SelectedIndex <= 1)
            {
                MessageBox.Show(Constant.WARNING_MESSAGE_NO_DETAIL_DATA_YET, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tarifMuatan.SelectedIndex > 1)
            {
                string CargoType = TKHelper.DictionaryGetValueByKey(CargoTypes, tarifMuatan.Text.ToString());
                int CargoFare = tarifMuatan.SelectedIndex == 1 ? 0 : TKHelper.DictionaryGetValueByKey(Cargos, tarifMuatan.Text);
                pedestrianDetails.Add(new PedestrianDetail(CargoType, 1, CargoFare));
            }

            if (pedestrianDetails.Count > 0)
            {
                PedestrianFareDetail pedestrianFareDetail = new PedestrianFareDetail(pedestrianDetails);
                pedestrianFareDetail.Show();
            }
        }

        public void UnsubscribeEvents()
        {
            btnClear.Click -= btnClear_Click;
            btnClose.Click -= btnClose_Click;
            btnMinimize.Click -= btnMinimize_Click;
            buttonLogout.Click -= buttonLogout_Click;
            btnSave.Click -= btnSave_Click;
            txtGrandTotal.Click -= txtGrandTotal_Click;

            tarifMuatan.SelectionChangeCommitted -= tarifMuatan_SelectionChangeCommitted;

            // unsubscribe all programmatically-added-textboxes events
            int countPedestrianTypeTextBox = PedestrianTypes.Count;
            if (countPedestrianTypeTextBox > 0)
            {
                foreach (var dataPedestrian in PedestrianTypes)
                {
                    string type = dataPedestrian.Key;
                    TextBox textBox = this.Controls.Find(type, true).FirstOrDefault() as TextBox;
                    textBox.KeyPress -= OnKeyPressAcceptOnlyNumber;
                    textBox.TextChanged -= OnTextChangedPedestrianType;
                }
            }
        }
    }
}
