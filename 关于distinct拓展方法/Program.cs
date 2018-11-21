using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 关于distinct拓展方法
{

    class MyClass
    {
        public string A { get; set; }
        public int B { get; set; }


        public override string ToString()
        {
            return $"{A}----{B}";
        }


    }


    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<MyClass>
            {
                new MyClass() { A="A",B=1},
                new MyClass() { A="AA",B=11},

                new MyClass() { A="A",B=111},
                new MyClass() { A="AA",B=12},

                new MyClass() { A="A",B=12},
                new MyClass() { A="AAA",B=11},

            };




            list = list.DistinctBy(x => x.B).ToList();


            Console.ReadKey();








        }
    }




    #region fdsfs
    public class MyEqualityComparer<T> : IEqualityComparer<T>
    {



        private Func<T, object> exFun;

        public MyEqualityComparer(string pp)
        {
            PropertyInfo prop = typeof(T).GetProperty(pp);
            if (prop == null)
            {
                throw new ArgumentNullException($"{pp} is not a prop of {typeof(T)}");
            }
            ParameterExpression arg = Expression.Parameter(typeof(T), "obj");
            MemberExpression expProp = Expression.Property(arg, prop);
            exFun = Expression.Lambda<Func<T, object>>(expProp, arg).Compile();

        }
        public bool Equals(T x, T y)
        {
            var x_val = exFun(x);
            var y_val = exFun(y);
            if (x_val == null)
            {
                return y_val == null;
            }
            return x_val == y_val;

        }

        public int GetHashCode(T obj)
        {
            var o_val = exFun(obj);
            if (o_val == null)
            {
                return 0;

            }

            return o_val.GetHashCode();

        }
    }

    #endregion






    //通过反射的泛型比较类
    class EnquilityComparer2<T> : IEqualityComparer<T>
    {
        private PropertyInfo prop;

        public EnquilityComparer2(string pp)
        {
            //检查类型T是否含有属性pp
            prop = typeof(T).GetProperty(pp);
            if (prop == null)
            {
                throw new ArgumentNullException($"{pp} is not a prop of {typeof(T)}");
            }
        }
        public bool Equals(T x, T y)
        {
            var x_val = prop.GetValue(x);
            var y_val = prop.GetValue(y);
            if (x_val == null)
            {
                return y_val == null;
            }
            return x_val.Equals(y_val);


        }

        public int GetHashCode(T obj)
        {
            var obj_val = prop.GetValue(obj);
            if (obj_val == null)
            {
                return 0;
            }
            return obj_val.GetHashCode();
        }
    }















    //用表达式取代反射获取对象的值
    public class EnquilityComparer<T> : IEqualityComparer<T>
    {
        private Func<T, object> getPropertyValueFunc;

        public EnquilityComparer(string pp)
        {
            //获取类型属性
            var prop = typeof(T).GetProperty(pp, BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
            if (prop == null)
            {
                throw new ArgumentNullException($"{pp} is not a property of {typeof(T)}");
            }
            //创建表达式参数
            ParameterExpression arg = Expression.Parameter(typeof(T), "obj");
            //为参数赋值(获取T的属性值表达式)
            MemberExpression propVal = Expression.Property(arg, prop);
            getPropertyValueFunc = Expression.Lambda<Func<T, object>>(propVal, arg).Compile();
        }



        public bool Equals(T x, T y)
        {
            var obj_x = getPropertyValueFunc(x);
            var obj_y = getPropertyValueFunc(y);
            if (obj_x == null)
                return obj_y == null;

            return obj_x.Equals(obj_y);

        }

        public int GetHashCode(T obj)
        {
            var hs = getPropertyValueFunc(obj);
            if (hs == null)
            {
                return 0;
            }
            return hs.GetHashCode();
        }
    }
}
