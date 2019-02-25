﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNITapCashDLL;
using PCSC;
using BNITapCash.Readers.Contactless.Acr123U;
using System.IO;
using BNITapCash.Helper;
using BNITapCash.Miscellaneous.FileMonitor;
using BNITapCash.DB;
using System.Text.RegularExpressions;

namespace BNITapCash.Bank.BNI
{
    public class BNI
    {
        BNITapCashDLL.TapCashDLL bni = new BNITapCashDLL.TapCashDLL();
        List<string> readerList = new List<string>();
        string selectedReader;

        System.Threading.SynchronizationContext context;
        private static readonly IContextFactory contextFactory = ContextFactory.Instance;
        SCardMonitor monitorAuto = new SCardMonitor(contextFactory, SCardScope.System);

        Acr123U acr123u = new Acr123U();
        byte LEDStatus;
        byte LEDBlue = 0x01;
        byte LEDOrange = 0x02;
        byte LEDGreen = 0x04;
        byte LEDRed = 0x08;
        byte LEDAntRed = 0x10;
        byte LEDAntGreen = 0x20;
        byte LEDAntBlue = 0x40;

        private const string TID = "12001401";
        private const string settlementMID = "000100012000014";

        private Cashier cashier;
        private TKHelper tk = new TKHelper();
        private FileWatcher watcher;
        private DBConnect database;

        public BNI()
        {

        }

        public BNI(Cashier cashier)
        {
            try
            {
                this.LEDStatus = 0x00;
                this.readerList = bni.getListReader();
                this.selectedReader = this.readerList[0]; // PICC selected
                this.cashier = cashier;
                watcher = new FileWatcher();
                database = new DBConnect();
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
                string SAM_message = "SAM has already been initialized.";
                if (this.GetSAMStatus().ToLower() != SAM_message.ToLower())
                {
                    try
                    {
                        Console.WriteLine("Initializing SAM ...");
                        return bni.initSAM(this.readerList[3]);
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                else
                {
                    return SAM_message;
                }

            }
            else
            {
                return "Failed to Initialize SAM : No Reader found or selected.";
            }
        }

        public string GetSAMStatus()
        {
            if (this.readerList != null)
            {
                try
                {
                    return bni.getSAMStatus(this.readerList[3]);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "Failed to Get SAM Status : No Reader found or selected.";
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
                    this.SetLCDDisplayText("Processing ...");
                    this.LEDStatus = LEDOrange;
                    this.LEDStatus |= LEDAntBlue;
                    this.LEDStatus |= LEDAntGreen;
                    this.LEDStatus |= LEDAntRed;
                    this.acr123u.setLEDControl(this.LEDStatus);
                    acr123u.disconnect();

                    this.cashier.UIDCard = this.GetCardNumber();
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
                    Console.WriteLine("Card Ejected.\n");
                    acr123u.connectDirect();
                    acr123u.LCDBacklightControl(0xFF);
                    this.LEDStatus = LEDOrange;
                    this.LEDStatus |= LEDAntBlue;
                    this.acr123u.setLEDControl(this.LEDStatus);
                    this.SetLCDDisplayText("Waiting Card ...");
                    acr123u.disconnect();
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

        private void CreateSettlement(string deductResult)
        {
            FileWatcher.newFile.Clear();
            string tidSettlement = TID;
            List<Trx> listDebitLine = new List<Trx>();

            string[] filelines = new string[] { deductResult };
            for (int a = 0; a < filelines.Length; a++)
            {
                string debitLine = filelines[a];

                Trx transaksi = new Trx();
                transaksi.TrxTID = debitLine.Substring(35, 8);
                transaksi.TrxLine = debitLine;
                listDebitLine.Add(transaksi);
            }

            listDebitLine.Sort(delegate (Trx c1, Trx c2) { return c1.TrxTID.CompareTo(c2.TrxTID); });

            List<string> settlementList = new List<string>();
            foreach (Trx elemen in listDebitLine)
            {
                if (elemen.TrxTID.Equals(tidSettlement))
                {
                    settlementList.Add(elemen.TrxLine);
                }
            }
            string result = bni.createSettlement(settlementList, settlementMID, tidSettlement);
            Console.WriteLine(result);

            // insert to local database
            for (int i = 0; i < FileWatcher.newFile.Count; i++)
            {
                string path_file = tk.GetApplicationExecutableDirectoryName() + "\\bin\\Debug\\settlement\\" + FileWatcher.newFile[i];
                path_file = Regex.Replace(path_file, @"\\", @"\\");
                string created = tk.ConvertDatetimeToDefaultFormat(tk.GetCurrentDatetime());
                string query = "INSERT INTO settlements (path_file, created) VALUES('" + path_file + "', '" + created + "')";
                try
                {
                    database.Insert(query);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public string DeductBalance(int amount = 0)
        {
            try
            {
                // check if deducted amount is sufficient within balance range and the balance must be greater than 0
                int cardBalance = Int32.Parse(this.GetCardBalance());
                if (cardBalance > 0 && (cardBalance - amount) > 0)
                {
                    string result = bni.debitProcess(this.readerList[3].ToString(), this.selectedReader.ToString(), amount, TID);
                    Console.WriteLine("Successfully Deducted for Rp. " + amount + ",-.");
                    Console.WriteLine("Current Balance : " + String.Format("{0:n}", Int32.Parse(this.GetCardBalance())));
                    this.CreateSettlement(result);

                    acr123u.connectDirect();
                    int repeat = 3;
                    int onDuration = 5;
                    int OffDuration = 10;
                    acr123u.setBuzzerControl((byte)repeat, (byte)onDuration, (byte)OffDuration);
                    this.LEDStatus = LEDGreen;
                    this.LEDStatus |= LEDAntGreen;
                    acr123u.LCDBacklightControl(0xFF);
                    this.acr123u.setLEDControl(this.LEDStatus);
                    this.SetLCDDisplayText("Success ...");
                    acr123u.disconnect();

                    return "OK";
                }
                else
                {
                    acr123u.connectDirect();
                    this.SetLCDDisplayText("Insufficient Bal");
                    Console.WriteLine("Can't Deduct : Insufficient Balance.");
                    int repeat = 2;
                    int onDuration = 5;
                    int OffDuration = 10;
                    acr123u.setBuzzerControl((byte)repeat, (byte)onDuration, (byte)OffDuration);
                    this.LEDStatus = LEDRed;
                    this.LEDStatus |= LEDAntRed;
                    acr123u.LCDBacklightControl(0xFF);
                    this.acr123u.setLEDControl(this.LEDStatus);
                    acr123u.disconnect();
                    return "Can't Deduct : Insufficient Balance.";
                }
            }
            catch (Exception ex)
            {
                acr123u.connectDirect();
                this.SetLCDDisplayText("Fail to Process.");
                Console.WriteLine(ex.Message);
                int repeat = 2;
                int onDuration = 5;
                int OffDuration = 10;
                acr123u.setBuzzerControl((byte)repeat, (byte)onDuration, (byte)OffDuration);
                this.LEDStatus = LEDRed;
                this.LEDStatus |= LEDAntRed;
                acr123u.LCDBacklightControl(0xFF);
                this.acr123u.setLEDControl(this.LEDStatus);
                acr123u.disconnect();
                return ex.Message;
            }
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
            this.LEDStatus |= LEDOrange;
            this.LEDStatus |= LEDAntBlue;
            this.acr123u.setLEDControl(this.LEDStatus);

            // set Display Text
            this.SetLCDDisplayText("E-Payment");

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
