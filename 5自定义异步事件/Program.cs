using System;
using 自定义异步事件;

namespace _5自定义异步事件
{
    class Program
    {
        static void Main(string[] args)
        {
            new DoenLaodHandle().DownloadAsync("123", "3421");
            Console.WriteLine("");
            Console.WriteLine("Hello World!");
        }
    }
}
