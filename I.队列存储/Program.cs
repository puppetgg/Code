using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I.队列存储
{
    class Program
    {
        static void Main(string[] args)
        {
            Director(@"C:\work\CodeDemo\svnCode\");
        }
        static int count = 1;
        static Queue<string> queue = new Queue<string>();
        private static void Director(string dirPath)
        {
            try
            {
                Console.WriteLine("---------" + count); count++;
                Console.WriteLine(queue.Count);
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                
                var fsinfos = dir.GetFileSystemInfos();


                foreach (FileSystemInfo fsinfo in fsinfos)
                {
                    if (fsinfo is FileInfo)
                    {
                        queue.Enqueue(fsinfo.FullName);
                        Console.WriteLine("文名" + queue.Count);
                    }
                    else
                        Director(fsinfo.FullName);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("=====扫描文件====" + e.Message);
            }

        }
    }
}
