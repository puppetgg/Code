using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace I使用实例
{
    class Program
    {
        static Action<string> Rendering = Console.WriteLine;
        static void Main(string[] args)
        {

            PagePaint();
            Console.Read();
        }
        //复制代码
        static void PagePaint()
        {
            Console.WriteLine("Paint Start");
            Paint();
            Console.WriteLine("Paint End");
        }

        static void Paint()
        {
            Rendering("Header");
            Rendering(RequestBody());
            Rendering("Footer");
        }

        static string RequestBody()
        {
            Thread.Sleep(1000);
            return "Body";
        }


    }
}
