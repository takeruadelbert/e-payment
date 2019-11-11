using BNITapCash.ConstantVariable;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace BNITapCash.Helper
{
    class TKHelper
    {
        public static bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }
            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }
            byte tempForParsing;
            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }

        public static string GetCurrentDatetime()
        {
            return DateTime.Now.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID")) + " " + DateTime.Now.ToString("HH:mm:ss");
        }

        public static string GetCurrentDatetimeInDefaultFormat()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ConvertDatetime(string param_date, string param_time)
        {
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("id-ID");
            DateTime dt = DateTime.Parse(param_date, cultureinfo);
            return dt.ToString("dd MMMM yyyy", cultureinfo) + " " + param_time;
        }

        // Default Format : yyyy-MM-dd HH:mm:ss
        public static string ConvertDatetimeToDefaultFormat(string dt)
        {
            string[] temp = dt.Split(' ');
            string date = temp[0];
            string month = GetMonthInNumber(temp[1]);
            string year = temp[2];
            string time = temp[3];
            return year + "-" + month + "-" + date + " " + time;
        }

        public static string IDR(string nominal)
        {
            return String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(nominal));
        }

        public static int IDRToNominal(string strNominal)
        {
            return int.Parse(Regex.Replace(strNominal, @",.*|\D", ""));
        }

        public static string GetApplicationExecutableDirectoryName()
        {
            string workingDirectory = Environment.CurrentDirectory;
            return Directory.GetParent(workingDirectory).Parent.FullName;
        }

        public static string GetDirectoryName()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private static string GetMonthInNumber(string month, int digit = 2)
        {
            int month_in_number = -1;
            switch (month)
            {
                case "Januari":
                    month_in_number = 1;
                    break;
                case "Februari":
                    month_in_number = 2;
                    break;
                case "Maret":
                    month_in_number = 3;
                    break;
                case "April":
                    month_in_number = 4;
                    break;
                case "Mei":
                    month_in_number = 5;
                    break;
                case "Juni":
                    month_in_number = 6;
                    break;
                case "Juli":
                    month_in_number = 7;
                    break;
                case "Agustus":
                    month_in_number = 8;
                    break;
                case "September":
                    month_in_number = 9;
                    break;
                case "Oktober":
                    month_in_number = 10;
                    break;
                case "November":
                    month_in_number = 11;
                    break;
                case "Desember":
                    month_in_number = 12;
                    break;
                default:
                    month_in_number = -1;
                    break;
            }
            return month_in_number != -1 ? month_in_number.ToString("00") : "";
        }

        public static string GetUidType(string uid)
        {
            return uid.Length == Constant.BARCODE_LENGTH ? "barcode" : "nfc";
        }
    }
}
