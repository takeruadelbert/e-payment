using BNITapCash.API;

namespace BNITapCash.Interface
{
    interface RestAPIMethod
    {
        DataResponse post(string ip_address_server, string url, bool resultSingleObject, string param);

        DataResponse get(string ip_address_server, string url, bool resultSingleObject);
    }
}
