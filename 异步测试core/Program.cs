using System;
using System.Threading;
using System.Threading.Tasks;

namespace 异步测试core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            new Action(async () =>
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
                Console.WriteLine("主4====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("res:" + res + "================" + Thread.CurrentThread.ManagedThreadId);
            })();
            Console.WriteLine("主5====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Console.Read();
        }
    }
}
