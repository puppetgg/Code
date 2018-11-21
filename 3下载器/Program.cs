using System;
using System.ComponentModel;

namespace _3下载器
{
    class Program
    {
        static void Main(string[] args)
        {

            string str = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(str);
            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
