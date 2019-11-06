using BNITapCash.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNITapCash.Interface
{
    interface RestAPIMethod
    {
        DataResponseArray post(string ip_address_server, string url, bool resultSingleObject, string param);

        DataResponseArray get(string ip_address_server, string url, bool resultSingleObject);
    }
}
