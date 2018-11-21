using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebRequest_Post_Get_请求数据
{
    class Program
    {
        static void Main(string[] args)
        {

            Post();


            Console.Read();
        }






        public static void Post()
        {
            string[] aa = { "aa", "aa" };

            var s = new
            {
                a = "a",
                c = new { b = "a" },
                d = new string[1] { "a" },

            };
            var ss = new
            {
                jqgridparam = new
                {
                    page = 1,
                    rows = 10,
                    sidx = "CreateDate",
                    sord = "Desc"
                },

            };


            //data  
            string cookieStr = "Cookie信息";
            string postData = string.Format("OperationModel={0}", ss);
            byte[] data = Encoding.UTF8.GetBytes(postData);

            // Prepare web request...  
            var url = "http://10.18.105.142:9000/api/MeetBookingModule/MeetingReport/GetMeetingBasicUserInfo";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            //request.Referer = "https://www.xxx.com";  
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36";
            //request.Host = "www.xxx.com";  
            request.Headers.Add("Cookie", cookieStr);
            request.ContentLength = data.Length;
            Stream newStream = request.GetRequestStream();

            // Send the data.  
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            // Get response  
            HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            Console.ReadLine();
        }
    }



}
