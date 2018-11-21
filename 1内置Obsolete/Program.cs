using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1内置Obsolete
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMethod();
            Console.Read();
        }


        [Obsolete("ddd", false)]
        static void GetMethod()
        {
            Console.WriteLine("GM");
        }
    }
}
