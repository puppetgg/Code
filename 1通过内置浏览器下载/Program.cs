using System;
using System.Net;

namespace _1通过内置浏览器下载
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Test1();
        }
        public static void Test1()
        {
            //string url = "http://www.imooc.com/video/11555";  
            //string url = "http://v2.mukewang.com/98672526-02b5-454c-b31e-d8526755b40b/L.mp4?auth_key=1474171330-0-0-8ff3fe3a33cfd257577dfa999e41530d";
            string url = "http://down.360safe.com/cse/360cse_9.5.0.132.exe";
            DateTime start = DateTime.Now;
            Uri uri = new Uri(url);
            string filename = uri.AbsolutePath.Substring(uri.AbsolutePath.LastIndexOf("/") + 1);

            //指定url 下载文件  
            WebClient client = new WebClient();
            client.DownloadFile(url, filename);
            Console.WriteLine("下载文件成功,用时：" + (DateTime.Now - start).TotalSeconds + "秒");
        }
    }
}
