using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于distinct拓展方法
{
    public static class Distinct
    {

        public static IEnumerable<TSource> DistinctBy<TSource, Tkey>(this IEnumerable<TSource> source, Func<TSource, Tkey> keySelector)
        {
            HashSet<Tkey> keys = new HashSet<Tkey>();
            foreach (var item in source)
            {
                if (keys.Add(keySelector(item)))
                    yield return item;
            }


        }


    }
}
