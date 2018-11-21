using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IIAsyncException
{
    class Program
    {

        static void Main(string[] args)
        {
            new MyClass().SimpleMethod();
            Console.WriteLine("THERE");
            Console.Read();
        }
    }




    class MyClass
    {

        public async void SimpleMethod()
        {
            try
            {
                var b = 0;
                var a = 2 / b;
                Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("HERE");
                });
            }
            catch (Exception ex)
            {
                //在 IIAsyncException.MyClass.<SimpleMethod>d__0.MoveNext() 位置 Z:\CodeDemo\IIAsyncException\Program.cs:行号 43

                Console.WriteLine(ex.StackTrace);
            }


        }


    }
}
