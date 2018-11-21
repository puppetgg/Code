﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4委托中的异步回掉
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("★主1====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            Func<string> func = new Func<string>(DoTestFun);

            Console.WriteLine("func.Method---" + func.Method);
            var ar = func.BeginInvoke(callback, func);
         
            Console.WriteLine("★主2====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            // var result = func.EndInvoke(ar);
            for (int i = 0; i < 8; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(MethodBase.GetCurrentMethod().Name + "().★主=.." + Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("★主3====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            // Console.WriteLine("result:" + result);
            Console.ReadKey();

        }

        private static void callback(IAsyncResult ar)
        {
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
