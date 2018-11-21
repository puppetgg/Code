using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Task异步编程
{
    public class HttpClientAsync
    {


        public static  void TTT()
        {


            Console.WriteLine("---------------------------------------1--");
            string res = GetCookies().Result;
            Console.WriteLine($"----{res}--------------------------");

        }


        public static async Task<string> GetCookies()
        {

            HttpClient httpClient = new HttpClient();
            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("Account", "System"));

            data.Add(new KeyValuePair<string, string>("Password", "4a7d1ed414474e4033ac29ccb8653d9b"));


            var content = new FormUrlEncodedContent(data);

            string url = "http://10.18.105.190:9090/Login/CheckLogin";
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            
            response.EnsureSuccessStatusCode();

            var cookies = response.Headers.GetValues("Set-Cookie");

            //string resultStr = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(resultStr);



            return cookies.First();

        }


    }
}
