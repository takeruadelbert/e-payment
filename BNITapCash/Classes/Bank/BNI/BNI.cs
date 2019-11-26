using BNITapCash.Bank.DataModel;
using BNITapCash.ConstantVariable;
using BNITapCash.Helper;
using BNITapCash.Readers.Contactless.Acr123U;
using PCSC;
using System;
using System.Collections.Generic;

namespace BNITapCash.Bank.BNI
{
    public class BNI
    {
        BNITapCashDLL.TapCashDLL bni = new BNITapCashDLL.TapCashDLL();
        List<string> readerList = new List<string>();
        private IDictionary<string, string> RCList;
        string selectedReader;

        System.Threading.SynchronizationContext context;
        private static readonly IContextFactory contextFactory = ContextFactory.Instance;
        SCardMonitor monitorAuto = new SCardMonitor(contextFactory, SCardScope.System);

        Acr123U acr123u = new Acr123U();
        byte LEDStatus;

        public BNI()
        {
            try
            {
                this.LEDStatus = 0x00;
                this.readerList = bni.getListReader();
                this.selectedReader = this.readerList[0]; // PICC selected
                this.acr123u.readerName = this.readerList[0];
                RCList = TKHelper.ParseRCJsonFileToDictionary(Properties.Resources.BNIListRC);
                InitializeSAM();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void PrintReaderList()
        {
            for (int i = 0; i < this.readerList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + this.readerList[i]);
            }
        }

        public string InitializeSAM()
        {
            if (this.readerList != null)
            {
                string SAM_message = Constant.MESSAGE_SAM_ALREADY_INITIALIZED;
                if (this.GetSAMStatus().ToLower() != SAM_message.ToLower())
                {
                    try
                    {
                        Console.WriteLine(Constant.MESSAGE_INTIALIZING_SAM);
                        return bni.initSAM(this.readerList[2]);
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                else
                {
                    Console.WriteLine(SAM_message);
                    return SAM_message;
                }

            }
            else
            {
                return Constant.ERROR_MESSAGE_FAILED_INITIALIZE_SAM;
            }
        }

        public string GetSAMStatus()
        {
            if (this.readerList != null)
            {
                try
                {
                    return bni.getSAMStatus(this.readerList[2]);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return Constant.ERROR_MESSAGE_FAILED_GET_SAM_STATUS;
            }
        }

        public string GetCardNumber()
        {
            try
            {
                return bni.getPurseCAN(this.selectedReader);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetCardBalance()
        {
            try
            {
                return bni.getPurseBalance(this.selectedReader);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void card_CardInserted(object sender, EventArgs e)
        {
            context.Post(new System.Threading.SendOrPostCallback(o =>
            {
                try
                {
                    Console.WriteLine("==================");
                    Console.WriteLine("Inserted Card Info");
                    Console.WriteLine("==================");
                    this.ShowCardInfo();

                    acr123u.connectDirect();
                    acr123u.LCDBacklightControl(0xFF);
                    this.SetLCDDisplayText(Constant.MESSAGE_PROCESSING);
                    this.LEDStatus = Constant.LED_ORANGE;
                    this.LEDStatus |= Constant.LED_ANT_BLUE;
                    this.LEDStatus |= Constant.LED_ANT_GREEN;
                    this.LEDStatus |= Constant.LED_ANT_RED;
                    this.acr123u.setLEDControl(this.LEDStatus);
                    acr123u.disconnect();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }), null);
        }

        private void card_CardRemoved(object sender, EventArgs e)
        {
            context.Post(new System.Threading.SendOrPostCallback(o =>
            {
                try
                {
                    Console.WriteLine(Constant.CARD_REMOVED + Constant.BREAKLINE);
                    SetToWaitingCard();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }), null);
        }

        private void ShowCardInfo()
        {
            Console.WriteLine("Card Number : " + this.GetCardNumber());
            Console.WriteLine("Balance : Rp. " + String.Format("{0:n}", Int32.Parse(this.GetCardBalance())));
            Console.WriteLine();
        }

        public DataDeduct DeductBalance(string bank, string ipv4, string TIDSettlement, string operator_name, int amount = 1)
        {
            DataDeduct dataDeduct = null;
            try
            {
                // check if deducted amount is sufficient within balance range and the balance must be greater than 0
                int cardBalance = Int32.Parse(this.GetCardBalance());
                if (cardBalance > 0 && (cardBalance - amount) > 0)
                {
                    string result = bni.debitProcess(this.readerList[2].ToString(), this.selectedReader.ToString(), amount, Properties.Settings.Default.TID);
                    string returnMessage = RCList.ContainsKey(result) ? RCList[result] : Constant.MESSAGE_OK;
                    if (returnMessage != Constant.MESSAGE_OK)
                    {
                        dataDeduct = new DataDeduct(true, returnMessage);
                        return dataDeduct;
                    }
                    Console.WriteLine("Successfully Deducted for Rp. " + amount + ",-.");
                    Console.WriteLine("Current Balance : " + String.Format("{0:n}", Int32.Parse(this.GetCardBalance())));

                    acr123u.connectDirect();
                    int repeat = 3;
                    int onDuration = 5;
                    int OffDuration = 10;
                    acr123u.setBuzzerControl((byte)repeat, (byte)onDuration, (byte)OffDuration);
                    this.LEDStatus = Constant.LED_GREEN;
                    this.LEDStatus |= Constant.LED_ANT_GREEN;
                    acr123u.LCDBacklightControl(0xFF);
                    this.acr123u.setLEDControl(this.LEDStatus);
                    this.SetLCDDisplayText(Constant.MESSAGE_SUCCESS_DEDUCT);
                    acr123u.disconnect();

                    dataDeduct = new DataDeduct(result, amount, bank, operator_name, TIDSettlement);
                }
                else
                {
                    acr123u.connectDirect();
                    this.SetLCDDisplayText(Constant.ERROR_MESSAGE_INSUFFICIENT_BALANCE);
                    Console.WriteLine(Constant.ERROR_MESSAGE_CANNOT_DEDUCT_INSUFFICIENT_BALANCE);
                    int repeat = 2;
                    int onDuration = 5;
                    int OffDuration = 10;
                    acr123u.setBuzzerControl((byte)repeat, (byte)onDuration, (byte)OffDuration);
                    this.LEDStatus = Constant.LED_RED;
                    this.LEDStatus |= Constant.LED_ANT_RED;
                    acr123u.LCDBacklightControl(0xFF);
                    this.acr123u.setLEDControl(this.LEDStatus);
                    acr123u.disconnect();
                    dataDeduct = new DataDeduct(true, Constant.ERROR_MESSAGE_CANNOT_DEDUCT_INSUFFICIENT_BALANCE);
                }
            }
            catch (Exception ex)
            {
                acr123u.connectDirect();
                this.SetLCDDisplayText(Constant.ERROR_FAIL_PROCESS);
                Console.WriteLine(ex.Message);
                int repeat = 2;
                int onDuration = 5;
                int OffDuration = 10;
                acr123u.setBuzzerControl((byte)repeat, (byte)onDuration, (byte)OffDuration);
                this.LEDStatus = Constant.LED_RED;
                this.LEDStatus |= Constant.LED_ANT_RED;
                acr123u.LCDBacklightControl(0xFF);
                this.acr123u.setLEDControl(this.LEDStatus);
                acr123u.disconnect();
                dataDeduct = new DataDeduct(true, ex.Message);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return dataDeduct;
        }

        private void SetToWaitingCard()
        {
            acr123u.connectDirect();
            acr123u.LCDBacklightControl(0xFF);
            this.LEDStatus = Constant.LED_ORANGE;
            this.LEDStatus |= Constant.LED_ANT_BLUE;
            this.acr123u.setLEDControl(this.LEDStatus);
            this.SetLCDDisplayText(Constant.MESSAGE_WAITING_CARD);
            acr123u.disconnect();
        }

        public void RunMain()
        {
            Console.WriteLine("===========");
            Console.WriteLine("List Reader");
            Console.WriteLine("===========");
            this.PrintReaderList();

            Console.WriteLine("\n");

            // check SAM status
            Console.WriteLine("==========");
            Console.WriteLine("SAM Status");
            Console.WriteLine("==========");
            Console.WriteLine(this.InitializeSAM());
            Console.WriteLine();

            acr123u.readerName = this.selectedReader;
            acr123u.connectDirect();

            // set background light on
            acr123u.LCDBacklightControl(0xFF);

            // set LED
            this.LEDStatus |= Constant.LED_ORANGE;
            this.LEDStatus |= Constant.LED_ANT_BLUE;
            this.acr123u.setLEDControl(this.LEDStatus);

            // set Display Text
            this.SetLCDDisplayText(Constant.APP_NAME);

            acr123u.disconnect();

            context = System.Threading.SynchronizationContext.Current;
            if (context == null)
            {
                context = new System.Threading.SynchronizationContext();
            }
            monitorAuto.CardInserted += new CardInsertedEvent(card_CardInserted);
            monitorAuto.CardRemoved += new CardRemovedEvent(card_CardRemoved);
            monitorAuto.Start(bni.GetReaderNames());
        }

        private void SetLCDDisplayText(string display_text)
        {
            acr123u.LCDBacklightControl(0xFF);
            acr123u.ClearLCD();
            int XYPosition = 0;
            byte[] Data = new byte[display_text.Length];
            Data = System.Text.Encoding.UTF8.GetBytes(display_text);
            acr123u.LCDCharacterDisplay((byte)XYPosition, Data);
        }

        public bool CheckReaderConn()
        {
            List<string> temp = bni.getListReader();
            return temp.Count == 0 ? false : true;
        }
    }
}
