using System;

namespace Math类
{
    class Program
    {
        static readonly Action<string> con = Console.WriteLine;

        static void Main(string[] args)
        {
            //四舍五入函数
            var m1 = Math.Round(1.35, 1);
            con("四舍六入五取偶" + m1);

            //天花板函数
            var mm = Math.Ceiling(1.35);
            con("天花板函数" + mm);

            //地板函数
            var mmm = Math.Floor(1.35);
            con("地板函数" + mmm);


            con("pi常量值" + Math.PI);

            con("--------------------------------------");

            double x, y, p, t, m, n;

            Console.WriteLine("请输入实验次数：");
            string str = Console.ReadLine();
            n = Convert.ToDouble(str);
            Random rand = new Random();
            m = 0;
            for (int i = 0; i <= n; i++)
            {
                x = rand.NextDouble() * 2 - 1;
                y = rand.NextDouble() * 2 - 1;
                if (x * x + y * y <= 1)
                {
                    m++;
                }
                Console.WriteLine("x={0},y={1}", x, y);
            }
            p = m / n;
            t = 4 * p;
            Console.WriteLine("落在圆区域的次数：" + m);
            Console.WriteLine("随机点落在圆区域的概率：" + p);
            Console.WriteLine("π的值为：" + t);
            Console.ReadLine();
            Console.Read();


        }
    }
}
