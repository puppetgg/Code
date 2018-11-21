using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 相对路径及文件夹的创建
{
    class Program
    {
        static void Main(string[] args)
        {
            var appdomain = AppDomain.MonitoringSurvivedProcessMemorySize;
            var curr = AppDomain.CurrentDomain.BaseDirectory;

            string str = AppDomain.CurrentDomain.RelativeSearchPath;//


            File.WriteAllText(str, str);

            Console.WriteLine(str);

            Console.Read();


        }
    }
}
