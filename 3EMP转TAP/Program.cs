using System;
using System.Net;
using System.Threading.Tasks;

namespace _3EMP转TAP
{
    class Program
    {
        static void Main(string[] args)
        {
            DDD();
            Console.WriteLine("Hello World!");
            Console.Read();
        }

        private static void DDD()
        {

            // webClient类支持基于事件的异步模式(EAP)
            WebClient webClient = new WebClient();

            // 创建TaskCompletionSource和它底层的Task对象
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();

            // 一个string下载好之后，WebClient对象会应发DownloadStringCompleted事件
            webClient.DownloadStringCompleted += (sender, e) =>
            {
                // 下面的代码是在GUI线程上执行的
                // 设置Task状态
                if (e.Error != null)
                {
                    // 试图将基础Tasks.Task<TResult>转换为Tasks.TaskStatus.Faulted状态
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    // 试图将基础Tasks.Task<TResult>转换为Tasks.TaskStatus.Canceled状态
                    tcs.TrySetCanceled();
                }
                else
                {
                    // 试图将基础Tasks.Task<TResult>转换为TaskStatus.RanToCompletion状态。
                    tcs.TrySetResult(e.Result);
                }
            };

            // 当Task完成时继续下面的Task,显示Task的状态
            // 为了让下面的任务在GUI线程上执行，必须标记为TaskContinuationOptions.ExecuteSynchronously
            // 如果没有这个标记，任务代码会在一个线程池线程上运行
            tcs.Task.ContinueWith(t =>
            {
                if (t.IsCanceled)
                {
                    Console.WriteLine("操作已被取消");
                }
                else if (t.IsFaulted)
                {
                    Console.WriteLine("异常发生，异常信息为：" + t.Exception.GetBaseException().Message);
                }
                else
                {
                    Console.WriteLine(String.Format("操作已完成，结果为：{0}", t.Result));
                }
            }, TaskContinuationOptions.ExecuteSynchronously);

            // 开始异步操作
            webClient.DownloadStringAsync(new Uri("http://msdn.microsoft.com/zh-CN/"));

        }
    }
}
