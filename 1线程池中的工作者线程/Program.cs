using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1线程池中的工作者线程
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
                                一、上节补充

                               二、CLR线程池基础
                               
                               三、通过线程池的工作者线程实现异步
                               
                               四、使用委托实现异步
                               
                               五、任务");




            // 创建一个线程来测试
            Thread thread1 = new Thread(TestMethod)
            {
                Name = "Thread1"
            };
            thread1.Start();
            Thread.Sleep(2000);
            Console.WriteLine("Main Thread is running");
            throw new Exception("test");
            thread1.Resume();
            Console.Read();
        }

        private static void TestMethod()
        {
            Console.WriteLine("Thread: {0} has been suspended!", Thread.CurrentThread.Name);

            //将当前线程挂起
            Thread.CurrentThread.Suspend();
            Console.WriteLine("Thread: {0} has been resumed!", Thread.CurrentThread.Name);
        }
    }
}
