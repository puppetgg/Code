using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.dely的洁厕
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"---------------{DateTime.Now.ToString()}");
            Task.Delay(3000).Wait();
            Console.WriteLine($"---------------{DateTime.Now.ToString()}");
            Console.Read();
        }
    }
}
