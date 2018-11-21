using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 乘法表
{
    class Program
    {
        static void Main(string[] args)
        {


           
            int i = 1;
            for (int j = 1; j < 10; j++)
            {
                if (i == j)
                {
                    Console.WriteLine($"{i}*{j}={i * j,2} ");
                    i++;
                    j = 0;
                    continue;
                }
                if (i < 10)
                {
                    Console.Write($"{i}*{j}={i * j,2} ");
                }

            }
          


            Console.WriteLine("========================================================================");

            //int y, j;
            for (int yi = 1; yi <= 9; yi++)
            {
                for (int j = 1; j <= yi; j++)
                {
                    Console.Write("{0}*{1}={2,2} ", yi, j, yi * j);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
