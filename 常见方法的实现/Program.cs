using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 常见方法的实现
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试MyAggregate的方法
            string[] arrStr = new string[] { "i", "am", "you" };

            var v = arrStr.MyAggregate((x, y) => x + "__" + y);




            Console.Write(v);
            Console.Read();

        }
    }



    //累加器的实现
    public static class Aggregate
    {

        public static TSource MyAggregate<TSource>(this IEnumerable<TSource> sorce,
            Func<TSource, TSource, TSource> sorcefun)
        {

            using (var sro = sorce.GetEnumerator())
            {
                //获取当前第一元素
                sro.MoveNext();
                var current = sro.Current;
                while (sro.MoveNext())
                {
                    current = sorcefun(current, sro.Current);
                }
                return current;
            }



        }


    }
}
