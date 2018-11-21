using System;
using System.IO;
using System.Net;

namespace _7CoreDownLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString());

            bgWorkerFileDownload_DoWork();
            Console.Read();
        }

        static string url = "http://down.360safe.com/cse/360cse_9.5.0.132.exe";
       // static long totalSize = 0;
        static int DownloadSize = 0;
        private static void bgWorkerFileDownload_DoWork()
        {
            // Get the source of event
            //   BackgroundWorker bgworker = sender as BackgroundWorker;
            try
            {
                // Do the DownLoad operation
                // Initialize an HttpWebRequest object
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                // If the part of the file have been downloaded, 
                // The server should start sending data from the DownloadSize to the end of the data in the HTTP entity.
                if (DownloadSize != 0)
                    myHttpWebRequest.AddRange(DownloadSize);

                var filestream = new FileStream("a.exe", FileMode.OpenOrCreate);
                // assign HttpWebRequest instance to its request field.
                //   request = myHttpWebRequest;
                HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
                var totalSize = response.ContentLength;
                Console.WriteLine("文件总大小：" + totalSize / 1024 / 1024 + "M-----");
                Stream streamResponse = response.GetResponseStream();
                int readSize = 0;
                var BufferRead = new byte[1024 * 2];
                while (true)
                {
                    readSize = streamResponse.Read(BufferRead, 0, BufferRead.Length);
                    if (readSize > 0)
                    {
                        filestream.Write(BufferRead, 0, readSize);
                        DownloadSize += readSize;
                        int percentComplete = (int)(DownloadSize / (float)totalSize * 100);
                        Console.WriteLine("文件下载完成：" + percentComplete + "%-----");
                    }
                    else
                    {
                        Console.WriteLine("下载文件成功,用时：" + (DateTime.Now - start).TotalSeconds + "秒");
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
