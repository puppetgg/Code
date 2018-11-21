using System;
using System.Net;

namespace _6WebClient中的事件异步
{
    class Program
    {
        static void Main(string[] args)
        {
            EAPMDemo.AsyncRun();
            Console.Read();
        }
    }

    public class EAPMDemo
    {
        public static class Utility
        {
            public static void Log(string msg)

                => Console.WriteLine(msg);


            public static string GetStrLen(string res)

             => res.Length.ToString();

        }

        public static void AsyncRun()
        {
            Utility.Log("AsyncRun:start");
            //测试网址 
            string url = "http://www.cnblogs.com/zhili/archive/2013/05/11/EAP.html";//"http://sports.163.com/nba/";
            using (WebClient webClient = new WebClient())
            {
                //监控下载进度 
                webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
                //监控完成情况 
                webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
                webClient.DownloadStringAsync(new Uri(url));
                Utility.Log("AsyncRun:download_start");
            }
        }
        static void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string log = "AsyncRun:download_completed";
            log += "|cancel=" + e.Cancelled.ToString();
            if (e.Error != null)
            {
                //出现异常，就记录异常 
                log += "|error=" + e.Error.Message;
            }
            else
            {
                //没有出现异常，则记录结果 
                log += "|result_size=" + Utility.GetStrLen(e.Result);
            }
            Utility.Log(log);
        }
        static void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Utility.Log("AsyncRun:download_progress|percent=" + e.ProgressPercentage.ToString());
        }
    }
}