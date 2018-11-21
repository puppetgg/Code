using System;

namespace 事件异步的模型
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"不支持对异步操作的取消和没有提供对进度报告的功能，对于有界面的应用程序来说，
                                                进度报告和取消操作的支持也是必不可少的，既然存在这样的问题，
                                                微软当然也应该提供给我们解决问题的方案了，所以微软在.NET 2.0的时候就为我们提供了一个新的异步编程模型，
                                                也就是我这个专题中介绍的基于事件的异步编程模型——EAP。");





            Console.Read();
        }
    }
}
