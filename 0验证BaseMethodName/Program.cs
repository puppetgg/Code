using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _0验证BaseMethodName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("验证方法名" + MethodBase.GetCurrentMethod().Name);
            Action aa = () => Console.WriteLine("验证方法名" + MethodBase.GetCurrentMethod().Name);
            aa();
            Console.Read();
        }
    }
}
