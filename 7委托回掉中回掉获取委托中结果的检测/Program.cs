using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _7委托回掉中回掉获取委托中结果的检测
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("★主1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Func<string> func = new Func<string>(DoTestFun);

            func.BeginInvoke(callback, func);

            Console.WriteLine("★主2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);


            for (int i = 0; i < 8; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(MethodBase.GetCurrentMethod().Name + "().★主=.." + Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("★主3====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();

        }

        private static void callback(IAsyncResult ar)
        {
            //此处的ar是委托执行完成的信息
            Console.WriteLine("☆支2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            var fun = ar.AsyncState as Func<string>;
            var result = fun.EndInvoke(ar);
            Console.WriteLine("☆支3====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("result:" + result);

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(MethodBase.GetCurrentMethod().Name + "()...");
            }
            Console.WriteLine(MethodBase.GetCurrentMethod().Name + "方法返结果，执行该方法的线程id:" + Thread.CurrentThread.ManagedThreadId);

        }

        static string DoTestFun()
        {
            Console.WriteLine("☆支1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("DoTestFun()...");
            }
            return MethodBase.GetCurrentMethod().Name + "方法返结果，执行该方法的线程id:" + Thread.CurrentThread.ManagedThreadId;

        }
    }
}
