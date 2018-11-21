using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0TaskRun的检测2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            Task<int> task1 = NewMethod();
            Console.WriteLine("主2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            Thread.Sleep(2500);
            Console.WriteLine("主2.5====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());

            task1.Wait();
            var res = task1.Result;
            Console.WriteLine("主3====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            Console.WriteLine("res:" + res);

            Console.Read();
        }

        private static async Task<int> NewMethod()
        {
            Console.WriteLine("主1.5====" + DateTime.Now.ToString() + "taskid---" + Task.CurrentId + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            return await Task.Run(() =>
            {

                Console.WriteLine("支0====" + DateTime.Now.ToString() + "================" + Task.CurrentId);
                Thread.Sleep(2000);
                Console.WriteLine("支1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
                Thread.Sleep(2000);
                Console.WriteLine("支2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
                return 666;
            });
        }
    }
}
