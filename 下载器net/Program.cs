using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 下载器net
{
    class Program
    {
        static void Main(string[] args)
        {

            Downloader downloader = new Downloader();
            downloader.DownloadCompleted += downloader_DownloadCompleted;
            downloader.ProgressChanged += downloader_ProgressChanged;
            Debug.WriteLine("调用线程:" + Thread.CurrentThread.ManagedThreadId);




            //异步调用
            downloader.DownloadAsync("http://baidu.com", "乔布斯传.avi");

            //downloader.DownloadTaskAsync("http://baidu.com", "乔布斯传.avi");

            //同步调用,UI线程卡死
            //string r = downloader.DownLoad("http://baidu.com", "乔布斯传.avi");
            //textBox1.AppendText(r);


            Console.Read();
        }

        private static void downloader_ProgressChanged(ProgressChangedEventArgs e)
        {

            Console.WriteLine(("事件回调线程:" + Thread.CurrentThread.ManagedThreadId + "下载了" + e.ProgressPercentage + "%\n"));
        }

        private static void downloader_DownloadCompleted(object sender, EventArgs e)
        {
            var de = e as DownloadCompletedEventArgs;
            Console.WriteLine(("事件回调线程:" + Thread.CurrentThread.ManagedThreadId + "下载完成，文件为" + de.Result + "\n"));
        }


    }
}
