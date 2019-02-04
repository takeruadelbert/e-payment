using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BNITapCash.API
{
    class RESTAPI
    {
        private const string URLRepo = "http://192.168.1.210/epass2018/";

        public RESTAPI()
        {

        }

        public DataResponse API_Post(string APIUrl, string sent_param)
        {
            string full_API_URL = URLRepo + APIUrl;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(full_API_URL);
            request.Method = "POST";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(sent_param);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            long length = 0;
            string result = "";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    result = readStream.ReadToEnd();
                    var json = JsonConvert.DeserializeObject<DataResponse>(result);
                    return json;
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                }
                throw;
            }
        }
    }
}
