using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    public static class MySelectMany
    {


        public static IEnumerable<TResult> FackSelectMany<T, TResult>(
            this IEnumerable<T> sorce, Func<T, IEnumerable<TResult>> selector)
        {

            foreach (var item in sorce)
            {
                foreach (var i in selector(item))
                {
                    yield return i;
                }
            }
        }
        public static IEnumerable<TResult> FackSelectMany<T, TResult>(
            this IEnumerable<T> sorce, Func<T, int, IEnumerable<TResult>> selector)
        {
            int index = 0;
            foreach (var item in sorce)
            {
                foreach (var i in selector(item, index++))
                {
                    yield return i;
                }

            }
        }
        public static IEnumerable<TResult> FackSelectMany<TSource, TCollection, TResult>(
           this IEnumerable<TSource> s,
           Func<TSource,IEnumerable<TCollection>> firstSelector,
           Func<TSource,TCollection,TResult> selector)
        {
            foreach (var item in s)
            {
                foreach (var i in firstSelector(item))
                {
                    yield return selector(item,i);
                }

            }

        }
    }



    static class FakeLinq
    {
        public static IEnumerable<TResult> FakeSelectMany<TSource, TResult>(
            this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var s in source)
            {
                foreach (var r in selector(s))
                {
                    yield return r;
                }
            }
        }

        public static IEnumerable<TResult> FakeSelectMany<TSource, TResult>(
            this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
        {
            int index = 0;
            foreach (var s in source)
            {
                foreach (var r in selector(s, index++))
                {
                    yield return r;
                }
            }
        }

        public static IEnumerable<TResult> FakeSelectMany<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            foreach (var s in source)
            {
                foreach (var c in collectionSelector(s))
                {
                    yield return resultSelector(s, c);
                }
            }
        }

        public static IEnumerable<TResult> FakeSelectMany<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            int index = 0;
            foreach (var s in source)
            {
                foreach (var c in collectionSelector(s, index++))
                {
                    yield return resultSelector(s, c);
                }
            }
        }
    }
}
