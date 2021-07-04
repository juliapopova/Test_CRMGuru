using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Test_CRMGuru
{
    //класс для получения информации по введенной стране через стороннее API.
    class HttpRequestCountry
    {
        //строка для подключения
        string request_str = "https://restcountries.eu/rest/v2/name/";
        public Country GetCountry(string name_country)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(request_str + name_country);
            string sReadData;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);

                sReadData = sr.ReadToEnd();

                response.Close();
            }
            catch
            {                
                return null;
            }
            sReadData = sReadData.Substring(1, sReadData.Length - 2);
            //запись в класс
            Country country = JsonConvert.DeserializeObject<Country>(sReadData);
            return country;
        }
    }
}
