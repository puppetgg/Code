using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II.队列存储异步
{
    class Program
    {

        static void Main(string[] args)
        {
            Director(@"C:\work\CodeDemo\svnCode\");
            Console.Read();
        }
        static int count = 1;
        static Queue<string> queue = new Queue<string>();
        private static async void Director(string dirPath)
        {
            try
            {
                Console.WriteLine("---------" + count); count++;
                Console.WriteLine(queue.Count);
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                var fsinfos = dir.GetFileSystemInfos().ToList();


                foreach (FileSystemInfo fsinfo in fsinfos)
                {
                    if (fsinfo is FileInfo)
                    {
                        queue.Enqueue(fsinfo.FullName);
                        Console.WriteLine("文名" + queue.Count);
                    }
                    else
                        await Task.Run(() => Director(fsinfo.FullName));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("=====扫描文件====" + e.Message);
            }

        }
    }
}
