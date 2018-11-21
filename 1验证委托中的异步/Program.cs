using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 委托中的同步原型
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Func<string> func = new Func<string>(DoTestFun);

            Console.WriteLine("func.Method---" + func.Method);
            var result = func.Invoke();
            Console.WriteLine("主3====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("result:" + result);
            Console.ReadKey();

        }



        static string DoTestFun()
        {
            Console.WriteLine("主2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("DoTestFun()");
            }
            return MethodBase.GetCurrentMethod().Name + "方法返结果，执行该方法的线程id:" + Thread.CurrentThread.ManagedThreadId;

        }
    }
}
