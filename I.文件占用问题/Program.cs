using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I.文件占用问题
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Z:\CodeDemo\0\Program.cs";

            var path2 = "abc.txt";
            //FileStream fs = File.Open(@"Z:\CodeDemo\0\Program.cs", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            FileStream fs = new FileStream(path2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            //FileStream fs = new FileStream(@"Z:\CodeDemo\0\Program.cs", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);

            char[] bys = new char[fs.Length];

            sr.Read(bys, 0, bys.Length);
            Directory.CreateDirectory(@"c:\\work\\3\");
            var filestream = new FileStream(@"c:\\work\\3\123.cs", FileMode.OpenOrCreate);

            //  filestream.Write(bys, 0, bys.Length);
            Console.Read();

        }
    }
}
