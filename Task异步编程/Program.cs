using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task异步编程
{
    class Program
    {
        // Task.Run()方法中的Function是真正异步执行的内容
        static async Task<int> Async()
        {
            Console.WriteLine("Async() 11 await 之前 Thread ID: [{0}]", Thread.CurrentThread.ManagedThreadId);

            int SS = await Task.Run<int>(() =>
              {
                  // 线程ID与Handler()方法不同
                  Console.WriteLine("Async() Thread ID: [{0}]", Thread.CurrentThread.ManagedThreadId);

                  for (int i = 0; i < 5; i++)
                  {
                      Thread.Sleep(100);
                      Console.WriteLine("Async: Run{0}--{1}", i, Thread.CurrentThread.ManagedThreadId);
                  }

                  Console.WriteLine($"Over----{Thread.CurrentThread.ManagedThreadId}");
                  return 666;
              });
            Console.WriteLine("Async() 11 await 之后 Thread ID: [{0}]", Thread.CurrentThread.ManagedThreadId);
            return SS;
        }
        // 返回值为void的async方法AsyncHandler()仅仅是包装器
        static async void AsyncHandler()
        {
            // 方法体中的内容实际为同步执行，与Main()函数线程ID相同
            Console.WriteLine("Handler() Thread ID: [{0}]", Thread.CurrentThread.ManagedThreadId);

            // 调用异步方法Async()不会阻塞，Async()方法开始异步执行
            Task<int> task = Async();
            Console.WriteLine("Handler() 控制权回归调用方  Thread ID: [{0}]", Thread.CurrentThread.ManagedThreadId);
            // 每隔0.1s打印输出，此时异步方法Async()也在另一线程中执行，同步打印输出
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("Handler: Run{0}--{1}", i, Thread.CurrentThread.ManagedThreadId);
            }

            // 在使用await之前的代码都运行在与Main()函数相同的线程
            Console.WriteLine("Handler1()   await  调用之前 Thread ID: [{0}]", Thread.CurrentThread.ManagedThreadId);

            // AsyncHandler()中的循环执行3次，此时异步方法Async()尚未执行完毕，使用await关键字会阻塞函数
            // 在Main()函数中，从调用await开始，AsyncHandler()就已返回了

            int a = await task;
            Console.WriteLine(a);

            // 使用await之后的代码运行在Async()方法所处的线程
            Console.WriteLine("Handler2()     await  调用之后  Thread ID: [{0}]", Thread.CurrentThread.ManagedThreadId);

            // 打印AsyncHandler()函数真正执行完毕信息
            Console.WriteLine("Handler Really Finished!");
        }

        // Main方法不能标记为异步
        static void Main(string[] args)
        {
            Console.WriteLine("Main() Thread ID: [{0}]", Thread.CurrentThread.ManagedThreadId);
            AsyncHandler();


            // 打印AsyncHandler()函数在Main()中已经执行完毕的信息
            Console.WriteLine($"Handler Finished in Main!---{Thread.CurrentThread.ManagedThreadId}");

            // AsyncHandler()在实际执行完成之前就返回了，需要阻塞主线程等待AsyncHandler()真正执行完毕
            Console.ReadLine();
        }










        ////------------------------基于事件的异步----------------------------------------------------
        //string str = string.Empty;
        //BackgroundWorker bw = new BackgroundWorker();
        //bw.DoWork += (s, ev) =>
        //{
        //    Console.WriteLine("Dowork开始执行");
        //    SpinWait.SpinUntil(() => false, (int)ev.Argument);
        //    Console.WriteLine("Dowork执行完成");

        //    str = "这是结果";
        //};

        //bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

        //Console.WriteLine($"检测方法是否执行 {bw.IsBusy}");

        //bw.RunWorkerAsync(5000);
        //Console.WriteLine("检测方法是否执行 末尾");


        //Console.ReadKey();
    }

    //    private static void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    //    {
    //        Console.WriteLine($"完成  {e.Result}");


    //    }
    //}
}
