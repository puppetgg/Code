using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3测试简写2中的异步委托测试
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Func<string> func = () =>
            {
                Console.WriteLine("支1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("DoTestFun()...");
                }
                return MethodBase.GetCurrentMethod().Name + "方法返结果，执行该方法的线程id:" + Thread.CurrentThread.ManagedThreadId;
            };

            Console.WriteLine("func.Method---" + func.Method);
            var ar = func.BeginInvoke(null, null);
            Console.WriteLine("主2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            var result = func.EndInvoke(ar);

            Console.WriteLine("主3====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("result:" + result);
            Console.ReadKey();

        }
    }
}
