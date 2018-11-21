using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IIIAsync
{
    class Program
    {

        static void Main(string[] args)
        {
            new MyClass().SimpleMethod();

            Console.WriteLine("@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString() + "THERE");
            while (true)
            {
                Thread.Sleep(1000000000);
                Console.Write(".");
            }

        }
    }




    class MyClass
    {

        public async void SimpleMethod()
        {
            Console.WriteLine("SimpleMethod()-s-@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString() + await GetHere());
            Console.WriteLine("SimpleMethod()-e-@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());

        }

        Task<string> GetHere()
        {
            Console.WriteLine("GetHere()-s-@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            var task = Task.Run(() =>
             {
                 Console.WriteLine("GetHere()-news-@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
                 Thread.Sleep(1000);
                 return "HERE返回值线程@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString();
             });
            Console.WriteLine("GetHere()-end-@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            return task;

        }
    }
}
