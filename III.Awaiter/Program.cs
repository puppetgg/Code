using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace III.Awaiter
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("start" + Thread.CurrentThread.ManagedThreadId);
            Action action = () => { Console.WriteLine("task" + Thread.CurrentThread.ManagedThreadId); /*return "result" + Thread.CurrentThread.ManagedThreadId;*/ });


            var callback = new WaitCallback(t =>
            {
                var tt = (Action)t;
                tt();
                //var ttAwaiter = tt.GetAwaiter();
                //ttAwaiter.UnsafeOnCompleted(new Action(() => Console.WriteLine("callback===" + Thread.CurrentThread.ManagedThreadId + "---------" + ttAwaiter.GetResult())));
                Console.WriteLine("From ThreadPool" + Thread.CurrentThread.ManagedThreadId);
            });
            ThreadPool.QueueUserWorkItem(callback, action);

            Console.WriteLine("没有启动的task是不会执行的" + Thread.CurrentThread.ManagedThreadId);
            Console.Read();
        }
    }
}
