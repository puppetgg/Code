using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于FirstOrDefault的检测
{
    class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<string> sLst = new List<string> { "aaaa", "bbbbb" };


            var s = sLst.First(x => x.Contains("a"));
            var ss = sLst.First(x => x.Contains("c"));

            var v = sLst.FirstOrDefault(x => x.Contains("a"));
            var vv = sLst.FirstOrDefault(x => x.Contains("c"));

            Console.Read();

        }
    }
}
