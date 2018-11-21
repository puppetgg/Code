using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于设计模式
{
    internal class 有关aop的接口模式
    {
        protected int DoSTs(int a = 10)
        {
            Console.WriteLine($"开始做事{a}");



            Console.WriteLine($"做事完成{a}");

            return a;
        }


    }
}
