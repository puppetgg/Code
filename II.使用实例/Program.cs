using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace II.使用实例
{
    class Program
    {

        static Action<string> Rendering = Console.WriteLine;
        static void Main(string[] args)
        {

            PagePaint();
            Console.WriteLine("当前线程6：@" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());

            Console.Read();
        }

        static void PagePaint()
        {
            Console.WriteLine("当前线程1：@" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            Console.WriteLine("Paint Start");
            Paint();
            Console.WriteLine("Paint End");
            Console.WriteLine("当前线程5：@" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
        }

        static async void Paint()
        {
            Console.WriteLine("当前线程2：@" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            Rendering("Header");
            Console.WriteLine("当前线程3：@" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            Rendering(await RequestBody());
            Console.WriteLine("当前线程：②@" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            Rendering("Footer");
            Console.WriteLine("当前线程：③@" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
        }

        static Task<string> RequestBody()
        {
            Console.WriteLine("当前线程4：@" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
            return Task.Run(() =>
             {
                 Console.WriteLine("当前线程①：@" + Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString());
                 Thread.Sleep(2000);
                 return "Body";
             });

        }


    }
}
