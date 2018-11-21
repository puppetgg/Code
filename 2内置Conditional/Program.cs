using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2内置Conditional
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMethod();

            Console.WriteLine("Main");
            Console.Read();
        }


        [Conditional("DEBUG")]
        static void GetMethod()
        {
            Console.WriteLine("gmodsfaf");
            Console.WriteLine("GM");
        }
    }
}
