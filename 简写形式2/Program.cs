using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 简写形式2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);


            AsyncFun();



            Console.WriteLine("主5====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Console.Read();
        }

        private static async void AsyncFun()
        {

            Console.WriteLine("主2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);


            var task1 = Task.Run(() =>
            {
                Console.WriteLine("支1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
                Console.WriteLine("支2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
                return 666;
            });
            Console.WriteLine("主3====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            var res = await task1;
            Console.WriteLine("由支线程往下执行");
            Console.WriteLine("主4====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("res:" + res + "================" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
