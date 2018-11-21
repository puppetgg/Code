using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectMany的实现
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }




    public static class MySelectMany
    {
        public static IEnumerable<TResult> mySelectMany<TSource, TResult>
            (this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item).First();
            }
        }
    }

}
