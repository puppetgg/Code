using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7NetDownLoad
{
    public class Program
    {
        public static string url = "";
        static void Main(string[] args)
        {
            //  var url = "http://down.360safe.com/cse/360cse_9.5.0.132.exe";
            //var frm = new ManFrm();
            //  frm.Show();
            //Task.Run(() => frm.Disposed += (o, e) => bgWorkerFileDownload_DoWork(url));
            // frm.Disposed += (o, e) => bgWorkerFileDownload_DoWork(url);
            //frm.Show();
            //if (!frm.IsDisposed)
            //{
            //    Console.WriteLine();
            //}

            string url = args[0];
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("开始下载：" + url);

            bgWorkerFileDownload_DoWork(url);

        }

        //  static string url2 = "http://down.360safe.com/cse/360cse_9.5.0.132.exe";
        // static long totalSize = 0;
        static int DownloadSize = 0;
        private static void bgWorkerFileDownload_DoWork(string url)
        {
            // Console.WriteLine("开始下载：" + url);
            // Get the source of event
            //   BackgroundWorker bgworker = sender as BackgroundWorker;
            try
            {
                DateTime start = DateTime.Now;
                // Do the DownLoad operation
                // Initialize an HttpWebRequest object
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                // If the part of the file have been downloaded, 
                // The server should start sending data from the DownloadSize to the end of the data in the HTTP entity.
                if (DownloadSize != 0)
                    myHttpWebRequest.AddRange(DownloadSize);
                Uri uri = new Uri(url);

                string filename = uri.AbsolutePath.Substring(uri.AbsolutePath.LastIndexOf("/") + 1);
                var filestream = new FileStream(@"C:\Users\spadmintest\Desktop\Load\" + filename, FileMode.OpenOrCreate);
                // assign HttpWebRequest instance to its request field.
                //   request = myHttpWebRequest;
                HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
                var totalSize = response.ContentLength;
                Console.WriteLine("文件总大小：" + totalSize / 1024 / 1024 + "M-----");
                Stream streamResponse = response.GetResponseStream();
                int readSize = 0;
                var BufferRead = new byte[1024 * 1024];
                while (true)
                {
                    readSize = streamResponse.Read(BufferRead, 0, BufferRead.Length);
                    if (readSize > 0)
                    {
                        filestream.Write(BufferRead, 0, readSize);
                        filestream.Flush();
                        DownloadSize += readSize;
                        int percentComplete = (int)(DownloadSize / (float)totalSize * 100);
                        Console.WriteLine("文件下载完成：" + percentComplete + "%-----");
                    }
                    else
                    {
                        Console.WriteLine("下载文件成功,用时：" + (DateTime.Now - start).TotalSeconds + "秒");
                        filestream.Close();
                        filestream.Dispose();
                        response.Close();
                        response.Dispose();
                        streamResponse.Close();
                        streamResponse.Dispose();
                        Console.WriteLine("下载文件成功");
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

