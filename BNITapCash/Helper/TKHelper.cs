using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNITapCash.Helper
{
    class TKHelper
    {
        public bool ValidateIPv4(string ipString)
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

        public string GetCurrentDatetime()
        {
            return DateTime.Now.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID")) + " " + DateTime.Now.ToString("HH:mm:ss");
        }

        public string ConvertDatetime(string param_date, string param_time)
        {
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("id-ID");
            DateTime dt = DateTime.Parse(param_date, cultureinfo);
            return dt.ToString("dd MMMM yyyy", cultureinfo) + " " + param_time;
        }

        public string IDR(string nominal)
        {
            return String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(nominal));
        }

        public string GetApplicationExecutableDirectoryName()
        {
            string workingDirectory = Environment.CurrentDirectory;
            return Directory.GetParent(workingDirectory).Parent.FullName;
        }
    }
}
