using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace 过滤器
{
    public class Tnt
    {

        public static void TTT()
        {
            var ss = AppDomain.CurrentDomain.BaseDirectory;

            File.WriteAllText("aaa.txt", "123564879" + ss);

        }

    }
}