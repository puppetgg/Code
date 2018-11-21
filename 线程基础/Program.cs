﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程基础
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"一、线程的介绍

                                二、线程调度和优先级
                                
                                三、前台线程和后台线程
                                
                                四、简单线程的使用");
            Console.WriteLine("进程是操作系统为我们提供的一种保护应用程序的一种机制。");
            Aaa();

        }
        static void Aaa()
        {
            // 创建一个新线程（默认为前台线程）
            Thread backthread = new Thread(new ParameterizedThreadStart(Worker))
            {
                IsBackground = new Random().Next(100) % 2 == 0 ? true : false
            };

            // 通过Start方法启动线程
            backthread.Start("110");
            backthread.Join();
            // 如果backthread是前台线程，则应用程序大约5秒后才终止
            // 如果backthread是后台线程，则应用程序立即终止
            Console.WriteLine("Return from Main Thread");
        }
        private static void Worker(object data)
        {
            Console.WriteLine(data.ToString());
            Console.WriteLine("调用thread.Join()方法来实现，Join()方法能保证主线程（前台线程）在异步线程thread（后台线程）运行结束后才会运行。");
            // 模拟做10秒
            Thread.Sleep(5000);
            // 下面语句，只有由一个前台线程执行时，才会显示出来
            Console.WriteLine("Return from Worker Thread");
        }
    }
}
