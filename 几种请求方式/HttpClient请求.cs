using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace 几种请求方式
{
    class HttpClient请求
    {



        public static async void HttpPost()
        {
            HttpClient httpClient = new HttpClient();

            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("Account", "System"));


            data.Add(new KeyValuePair<string, string>("Password", "4a7d1ed414474e4033ac29ccb8653d9b"));

            var content = new FormUrlEncodedContent(data);

            string url = "http://10.18.105.190:9098/api/DMSDataModule/InfomationTip/ProxyLogin";// "http://10.18.105.190:9090/Login/CheckLogin";
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var cookies = response.Headers.GetValues("Set-Cookie");

            string resultStr = await response.Content.ReadAsStringAsync();
           // var cookies = response.Headers;
            Console.WriteLine(resultStr);
        }



        //public static string CreateMD5(string str)
        //{
        //    b = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(a, "MD5")



        //}

        public static string CreateMD5Hash(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));

            }
            return sb.ToString();
        }
    }
}