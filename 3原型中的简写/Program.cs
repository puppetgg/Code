using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3原型中的简写
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            DoaTest();
            Console.WriteLine("主6====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            Console.Read();
        }

        private async static void DoaTest()
        {
            Console.WriteLine("主2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);


            Task<int> task = Task.Run(() =>
            {
                Console.WriteLine("支0====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
                Console.WriteLine("支1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
                Console.WriteLine("支2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
                return 666;
            });

            Console.WriteLine("主3====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);

            Console.WriteLine("主4====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            int res = await task;

            Console.WriteLine("主5====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("res:" + res);
        }


    }
}
