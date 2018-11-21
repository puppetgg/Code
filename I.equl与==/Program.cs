using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I.equl与__
{
    class Program
    {
        static void Main(string[] args)
        {
            object m1 = 1;
            object m2 = 1;

            Console.WriteLine(m1 == m2);

            Console.WriteLine(m1.Equals(m2));
            Console.Read();
            //首先m1,m2都是引用类型，当执行m1 == m2操作时，比较的是m1与m2在栈内地址的值是否相等，即比较的是引用，因为m1和m2指向的是托管堆中1是不同的地址（这点大家可以通过在debug状态下内存窗口中查看），所以得到的结果就自然是false
            //对于m1.Equals(m2)比较的是m1与m2引用的值是否相等，因为它们都是引用托管堆中1，它们地址不等，但是值是相等的，都是1，所以返回为true。
        }
    }
}
