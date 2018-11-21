using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskRun的检测
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Task<int> task1 = Task.Run(() =>
              {
                  Console.WriteLine("支0====" + DateTime.Now.ToString() + "taskid---" + Task.CurrentId + "================" + Thread.CurrentThread.ManagedThreadId);

                  Thread.Sleep(2000);
                  Console.WriteLine("支1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
                  Thread.Sleep(2000);
                  Console.WriteLine("支2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
                  return 666;
              });
            Console.WriteLine("主2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2500);
            Console.WriteLine("主2.5====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            task1.Wait();
            var res = task1.Result;
            Console.WriteLine("主3====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("res:" + res);

            Console.Read();
        }
    }
}
