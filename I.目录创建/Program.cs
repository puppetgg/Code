using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I.目录创建
{
    class Program
    {
        static void Main(string[] args)
        {
            // string path = @"c:\\3\23\34\fds\as";
            string name = @"c:\\3\23\34\fds\as\123\aaa.txt";
            if (!Directory.Exists(@"c:\\3\23\34\fds\as\123"))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(name));
                File.WriteAllText(name, "as");
            }

            Console.WriteLine("ok");
        }
    }
}
