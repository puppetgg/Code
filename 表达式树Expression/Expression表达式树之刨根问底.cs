using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace 表达式树Expression
{
    public class Expression表达式树之刨根问底
    {
        //expression是一种数据结构，我们可以将平常编写的C#语句块（或者叫表达式）的各部分进行分解并存入这个树结构当中，
        //保存在expression树结构中的语句块是不能直接执行的。
        //当我们需要将expression结构中的数据抽取并还原时就需要调用expression.Compile()方法,这里我称之为编译。
        //编译后得到的结果就是我们之前存入的语句块，这是数据结构还原成语句块的过程（这是一个比喻）。
        //当然将数据还原成语句块时依据解析引擎的不同会产生不同的输出结果，
        //如果引擎是linq to sql那么解析后输出的就是可供数据库执行的sql，如果引擎是linq to xml则解析后输出的是Xpath之类的表达式


        public static void ExpressionsTT()
        {


            //创建表示数的参数
            ParameterExpression paraA = Expression.Parameter(typeof(object), "a");
            ParameterExpression paraB = Expression.Parameter(typeof(object), "b");

            //申明文本块常量表达式
            ConstantExpression constantExp = Expression.Constant("{0} and {1}", typeof(string));
            //声明String.Format()方法调用表达式
            MethodCallExpression bodyExp = Expression.Call(
                 typeof(string).GetMethod("Format",
                 new Type[] { typeof(string), typeof(object), typeof(object) }),
                 new Expression[] { constantExp, paraA, paraB }
                 );



            //1.构造类型为LambdaExpression的lambda表达式树，编译后得到委托的基元类型（弱类型）。
            LambdaExpression func3 = Expression.Lambda(bodyExp, paraA, paraB);//将以上各个表达式部分组合为Lambda表达式
            Delegate dg = func3.Compile();//编译表达式树得到委托
            //(dg.DynamicInvoke("hello", "world"));//调用委托并将结果输出到控制台
            Console.WriteLine(func3.Compile().DynamicInvoke("hello", "world")); //上面两步可以简化为这句代码


            //5.动态构造Math.Sin(100)语句块
            ParameterExpression expA = Expression.Parameter(typeof(double), "a"); //参数a
            MethodCallExpression expCall = Expression.Call(
                   typeof(Math).GetMethod("Sin", new Type[] { typeof(double) }),
                   expA
                   );


            //typeof(Math).GetMethod(,)
            LambdaExpression exp = Expression.Lambda(expCall, expA); // a => Math.Sin(a)
            Console.WriteLine(exp.Compile().DynamicInvoke(100));
        }

    }
}
