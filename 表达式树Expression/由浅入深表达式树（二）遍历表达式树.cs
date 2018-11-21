using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace 表达式树Expression
{
    public class 由浅入深表达式树_二_遍历表达式树
    {

        public static void 带返回值的表达式树()
        {
            ConstantExpression cons = Expression.Constant(10);

            var ss = Expression.Lambda<Func<int>>(cons);

            Console.WriteLine(ss.Compile()());


        }

        public static void 带参数带返回值的表达式树()
        {
            ParameterExpression para = Expression.Parameter(typeof(int));
            //ParameterExpression parab = Expression.Parameter(typeof(int));
            ParameterExpression parab = Expression.Parameter(typeof(int));
            //创建参数，赋值，返回参数
            BlockExpression block = Expression.Block(
                new[] { para, parab },
                Expression.AddAssign(para, Expression.Constant(parab)),
                para
                );

            var ss = Expression.Lambda<Func<int>>(block);
            Console.WriteLine(ss.Compile()());


        }


        public static void 带参数带返回值的表达式树2()
        {

            LabelTarget returnTarget = Expression.Label(typeof(double));
            LabelExpression returnLable = Expression.Label(returnTarget, Expression.Constant(0.123));

            ParameterExpression para3 = Expression.Parameter(typeof(double));
            BlockExpression block = Expression.Block(
                Expression.AddAssign(para3, Expression.Constant(1.1)),
               // Expression.Return(returnTarget, para3),
                
                //Expression.
                para3
                );

            Expression<Func<double, double>> expr3 = Expression.Lambda<Func<double, double>>(block, para3);
            Console.WriteLine(expr3.Compile().Invoke(20.123));
        }

    }
}
