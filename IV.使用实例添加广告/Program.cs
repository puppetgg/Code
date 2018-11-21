using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IV.使用实例添加广告
{
    class Program
    {
        static Action<string> Rendering = Console.WriteLine;
        static void Main(string[] args)
        {

            PagePaint();
            Console.WriteLine("当前线程5：@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());

            Console.Read();
        }

        static void PagePaint()
        {

            Console.WriteLine("当前线程1：@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString() + "--" + DateTime.Now.ToString());
            Console.WriteLine("Paint Start");
            Paint();
            Console.WriteLine("Paint End");
            Console.WriteLine("当前线程4：@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
        }

        static async void Paint()
        {
            Console.WriteLine("当前线程2：@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            Rendering(await PaintAds() + "当前线程6：@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            Console.WriteLine("当前线程③：@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            Rendering("Header");
            Console.WriteLine("当前线程④：@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            Rendering(await RequestBody() + "当前线程⑥：@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            Console.WriteLine("当前线程：贰@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            Rendering("Footer");
            Console.WriteLine("当前线程：叁@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
        }


        static async Task<string> PaintAds()
        {
            Console.WriteLine("当前线程3：@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            var res = "执行该等待的线程res:" + Thread.CurrentThread.ManagedThreadId + "==" + await Task.Run(() =>
                     {
                         Console.WriteLine("当前线程①@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());

                         Thread.Sleep(2000);
                         return "Ads";
                     }) + "------" + Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("当前线程②@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            return res;
        }

        static async Task<string> RequestBody()
        {
            Console.WriteLine("当前线程⑤：@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
            return await Task.Run(() =>
            {
                Console.WriteLine("当前线程壹：@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString());
                Thread.Sleep(2000);
                return "Body";
            });

        }
    }
}
