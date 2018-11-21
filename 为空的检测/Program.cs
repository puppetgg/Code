using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 为空的检测
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime de = new DateTime(2000,1,1);


            List<string> data = new List<string>() { "1", "2" };

            var sss = data.Where(x => x == "22").FirstOrDefault();
            Console.Read();
        }
    }
}
