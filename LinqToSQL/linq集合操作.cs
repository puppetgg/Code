using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    public class linq集合操作
    {


        public static void fun()
        {
            string[] names = { "郭靖", "李莫愁", "欧阳晓晓", "黄蓉", "黄药师" };
            string[] names2 = { "郭靖", "杨过", "欧阳晓晓" };

            Console.WriteLine("相交的元素");
            foreach (var name in names.Intersect(names2))
            {
                Console.Write(name + " ");
            }
        }
    }
}
