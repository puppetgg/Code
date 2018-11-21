using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II.Awaiter
{
    class Program
    {
        static void Main(string[] args)
        {


            var task = new Task(() => { Console.WriteLine("task"); });

            task.GetAwaiter().GetResult();


            Console.WriteLine("没有启动的task是不会执行的");
            Console.Read();
        }
    }
}
