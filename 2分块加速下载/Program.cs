using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace _2分块加速下载
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Test3();
            Task.Run(() => Test3());
            Task.Run(() => Test4());
            Console.ReadKey();
        }

        public static void Test3()
        {
            string url = "http://down.360safe.com/cse/360cse_9.5.0.132.exe";
            DateTime start = DateTime.Now;
            Uri uri = new Uri(url);
            string filename = uri.AbsolutePath.Substring(uri.AbsolutePath.LastIndexOf("/") + 1);

            //指定url 下载文件  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            Stream stream = request.GetResponse().GetResponseStream();
            //创建写入流  
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            byte[] bytes = new byte[1024 * 1024 * 2];
            int readCount = 0;
            while (true)
            {
                readCount = stream.Read(bytes, 0, bytes.Length);
                if (readCount <= 0)
                    break;
                fs.Write(bytes, 0, readCount);
                fs.Flush();
            }
            fs.Close();
            stream.Close();
            Console.WriteLine("下载文件成功,用时：" + (DateTime.Now - start).TotalSeconds + "秒");
        }

        public static void Test4()
        {
            string url = "http://down.360safe.com/cse/360cse_9.5.0.132.exe";
            DateTime start = DateTime.Now;
            Uri uri = new Uri(url);
            string filename = uri.AbsolutePath.Substring(uri.AbsolutePath.LastIndexOf("/") + 1) + "a";

            //指定url 下载文件  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            Stream stream = request.GetResponse().GetResponseStream();
            //创建写入流  
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            byte[] bytes = new byte[1024 * 512];
            int readCount = 0;
            while (true)
            {
                readCount = stream.Read(bytes, 0, bytes.Length);
                if (readCount <= 0)
                    break;
                fs.Write(bytes, 0, readCount);
                fs.Flush();
            }
            fs.Close();
            stream.Close();
            Console.WriteLine("2下载文件成功,用时：" + (DateTime.Now - start).TotalSeconds + "秒");
        }

      
    }
}
