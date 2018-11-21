using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1特性使用
{
    class ToolKit
    {
        [ConditionalAttribute("LI")]                                           // Attribute名称的长记法
        [ConditionalAttribute("BUGED")]
        public static void Method1() { Console.WriteLine("Created By Li, Buged."); }

        [ConditionalAttribute("LI")]
        [ConditionalAttribute("NOBUG")]
        public static void Method2() { Console.WriteLine("Created By Li, NoBug."); }

        [Conditional("ZHANG")]                                               // Attribute名称的短记法
        [Conditional("BUGED")]
        public static void Method3() { Console.WriteLine("Created By Zhang, Buged."); }

        [Conditional("ZHANG")]
        [Conditional("NOBUG")]
        public static void Method4() { Console.WriteLine("Created By Zhang, NoBug."); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 虽然方法都被调用了，但只有符合条件的才会被执行。
            ToolKit.Method1();
            ToolKit.Method2();
            ToolKit.Method3();
            ToolKit.Method4();

            Console.Read();
        }
    }
}
