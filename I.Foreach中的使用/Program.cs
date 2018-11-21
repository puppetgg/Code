using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace I.Foreach中的使用
{
    class Program
    {
        static void Main(string[] args)
        {

            new MyClass().Test();
            Console.WriteLine("Main---end" + Thread.CurrentThread.ManagedThreadId);
            Console.Read();
        }


    }



    class MyClass
    {
        public void Test()
        {

            Enumerable.Range(0, 3).ToList().ForEach(async (i) =>
           await Task.Run(() =>
           {
               Thread.Sleep(3000);
               Console.WriteLine("i的值是" + i + "执行的线程是：" + Thread.CurrentThread.ManagedThreadId);
           }));

        }



    }
}
