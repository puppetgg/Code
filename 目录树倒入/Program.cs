using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 目录树倒入
{
    class Program
    {
        static void Main(string[] args)
        {

            var dt = SQLHelper.ExecuteTable("select * from manage_type");


            Console.WriteLine("11");


            Console.Read();
        }
    }
}
