using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());

            DoaTest();
            Console.WriteLine("主7====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());

            Console.Read();


        }

        private async static void DoaTest()
        {
            Console.WriteLine("主2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());


            Task<int> task = AsyncTest();


            Console.WriteLine("主4====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());


            Thread.Sleep(2000);

            Console.WriteLine("主5====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());

            int res = await task;

            Console.WriteLine("主6====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());

            Console.WriteLine("res:" + res);


        }

        private static async Task<int> AsyncTest()
        {
            Console.WriteLine("主3====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            return await Task.Run(() =>
            {
                Console.WriteLine("支0====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
                Thread.Sleep(2000);
                Console.WriteLine("支1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
                Thread.Sleep(2000);
                Console.WriteLine("支2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
                return 666;


            });
        }
    }
}
