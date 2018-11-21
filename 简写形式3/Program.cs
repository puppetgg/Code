using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 简写形式3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());

            new Action(async () =>
            {
                Console.WriteLine("主2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());

                var task1 = NewMethod();
                Console.WriteLine("主3====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());

                var res = await task1;
                Console.WriteLine("由支线程往下执行");
                Console.WriteLine("主4====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
                Console.WriteLine("res:" + res + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            })();
            Console.WriteLine("主5====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            Console.Read();
        }

        private static Task<int> NewMethod()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("支1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
                Thread.Sleep(2000);
                Console.WriteLine("支2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
                return 666;
            });

        }
    }
}
