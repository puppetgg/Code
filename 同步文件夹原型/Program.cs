using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 同步文件夹原型
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFileSystemWatcher();
            Console.Read();
        }
        static FileSystemWatcher watcher = new FileSystemWatcher();

        static void TestFileSystemWatcher()
        {

            try
            {
                watcher.Path = @"Z:\CodeDemo";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            //设置监视文件的哪些修改行为
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.LastAccess | NotifyFilters.LastWrite
                | NotifyFilters.FileName | NotifyFilters.DirectoryName;


            watcher.Filter = "*";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;

            Console.WriteLine(@"Press 'q' to quit app.");

            while (Console.Read() != 'q') ;
        }

        static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File：{0} {1}！", e.FullPath, e.ChangeType);
        }

        static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File：{0} renamed to\n{1}", e.OldFullPath, e.FullPath);
        }
    }
}
