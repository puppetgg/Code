using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IEnumerator_yield_Example
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine("=====遍历：传统 IEnumerable 迭代方式");
            IEnumerator_Example.CourseCollection col = new IEnumerator_Example.CourseCollection();
            foreach (IEnumerator_Example.Course course in col)
            {
                Console.WriteLine("选修：" + course.Name);
            }
            Console.WriteLine(Environment.NewLine);

            yield_Example.CourseCollection col2 = new yield_Example.CourseCollection();
            Console.WriteLine("=====遍历：yield迭代器方式");
            foreach (String str in col2)
            {
                Console.Write(str);
            }

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("单个集合多种遍历方式（eg：正序与倒序）");
            foreach (String str in col2.GetEnumerable_ASC())
            {
                Console.Write(str);
            }
            Console.WriteLine("=============================================");
            foreach (String str in col2.GetEnumerable_DESC())
            {
                Console.Write(str);
            }

            Console.Read();
        }
    }
}
