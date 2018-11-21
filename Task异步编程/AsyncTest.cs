using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Task异步编程
{
    internal class AsyncTest
    {



        internal static async Task<string> TOT()
        {
            Console.WriteLine(
                "开始执行异步");

            Task<string> intTest = Task2();

            Console.WriteLine("从OperateAsync方法中控制权限返回调用方DoClickAsync");
            string resultValue = await intTest;
            Console.WriteLine("耗时操作结果" + resultValue.ToString());





            return resultValue;

        }

        private async static Task<string> Task2()
        {
            Console.WriteLine("Task2开始执行");

            HttpClient hc = new HttpClient();

            Task<string> rep = hc.GetStringAsync("http://10.18.105.221:9090/Home/UnifyIndex");

            Console.WriteLine("请求中间打印 ");
            var str = await rep;


            return str;

        }
    }
}
