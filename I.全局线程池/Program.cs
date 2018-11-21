using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace I.全局线程池
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HERE");
            var callback = new WaitCallback(state => Console.WriteLine("From ThreadPool"));
            ThreadPool.QueueUserWorkItem(callback);
            Console.WriteLine("THERE");
            while (true)
            {

            }
        }
    }
}
