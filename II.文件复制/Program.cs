using III.占用问题;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II.文件复制
{
    class Program
    {
      
        static void Main(string[] args)
        {
            string paths = @"Z:\CodeDemo\";
            Directors(paths);


            Console.Read();
        }

        static int count = 1;
        static void Copy(string s, string oldPath, string newPath)
        {
            try
            {
             //   Killer.Kill(s);

                string newfp = s.Replace(oldPath, newPath);
                FileInfo fi = new FileInfo(s);
                if (!Directory.Exists(Path.GetDirectoryName(newfp)))
                    Directory.CreateDirectory(Path.GetDirectoryName(newfp));
                fi.CopyTo(newfp, true);

                Console.WriteLine("已经复制" + count);
                count++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        static List<string> fnsLst = new List<string>();
        private static async void Directors(string dirPath)
        {
            try
            {
                var fs = Directory.GetFiles(dirPath);
                if (fs.Length != 0)
                {
                    string paths = $@"C:\work\CodeDemo\{DateTime.Now.ToString("yyyyMMdd")}\";
                    string pathd = @"Z:\CodeDemo\";
                    foreach (var item in fs)
                        await Task.Run(() => Copy(item, paths, pathd));
                }
                var dirs = Directory.GetDirectories(dirPath);
                if (dirs.Length != 0)
                    foreach (var item in dirs)
                        await Task.Run(() => Directors(item));

            }
            catch (Exception e)
            {
                Console.WriteLine("=====扫描文件====" + e.Message);
            }

        }



    }
}
