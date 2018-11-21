using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace III.Lst集合同步
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Directors(@"C:\work\CodeDemo\svnCode\");
            sw.Stop();
            Console.WriteLine("耗时：" + sw.Elapsed);


            Console.Read();
        }
        static List<string> fnsLst = new List<string>();
        private static void Directors(string dirPath)
        {
            try
            {
                if (Directory.GetFiles(dirPath).Length != 0)
                {
                    fnsLst.AddRange(Directory.GetFiles(dirPath));
                    Console.WriteLine("文件数：" + fnsLst.Count);
                }
                var dirs = Directory.GetDirectories(dirPath);
                if (dirs.Length != 0)
                    foreach (var item in dirs)
                        Directors(item);

            }
            catch (Exception e)
            {
                Console.WriteLine("=====扫描文件====" + e.Message);
            }

        }
    }
}
