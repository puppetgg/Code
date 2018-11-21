using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 表达式树Expression
{
    public class 由浅入深表达式树_一_创建表达式树
    {
        static Action<string> con = Console.WriteLine;

        public static void TT()
        {
            Expression<Func<int, int>> expFun = a => a + 1;
            Console.WriteLine(expFun.ToString());  // x=> (x + 1)


            Expression<Func<int, int, int>> expFun2 = (a, b) => a + b;

            //复杂的表达式无法转换
            //Expression<Func<int, int, int>> expr2 = (x, y) => { return x + y; };
            //Expression<Action<int>> expr3 = x => { };


            // 右边是一个Lambda表达式，而左边是一个表达式树。为什么可以直接赋值呢？
            // 这个就要多亏我们的Expression<TDelegate> 泛型类了。
            // 而Expression<TDelegate> 是直接继承自LambdaExpression的，我们来看一下Expression的构造函数：
            // internal Expression(Expression body, string name, bool tailCall, ReadOnlyCollection<ParameterExpression> parameters)
            //: base(typeof(TDelegate), name, body, tailCall, parameters)

            //lambdaExpression
            Console.WriteLine("===========lambdaExpression================================================");

            var lambdaExpression = expFun2 as LambdaExpression;
            Console.WriteLine($"the result of lambdaExpression  :  {lambdaExpression.Body}");
            con($"the result of lambdaExpression CanReduce:  {lambdaExpression.CanReduce}");
            con($"the result of lambdaExpression Name:  {lambdaExpression.Name}");
            con($"the result of lambdaExpression NodeType:  {lambdaExpression.NodeType}");
            con($"the result of lambdaExpression Parameters:  {lambdaExpression.Parameters}");

            foreach (var item in lambdaExpression.Parameters)
            {
                con($"the result of lambdaExpression Parameter:  { item}");
                con($"the result of lambdaExpression Parameter:  { item.Name}");
                con($"the result of lambdaExpression Parameter:  { item.NodeType}");
                con($"the result of lambdaExpression Parameter:  { item.Type}");

            }

            //简单的来说，Expression<TDelegate> 泛型类做了一层封装，方便我们根据Lambda表达式来创建Lambda表达式树。
            //它们中间有一个转换过程，而这个转换的过程就发生在我们编译的时候。还记得我们Lambda表达式中讲的么？
            //Lambda表达式在编译之后是普通的方法，而Lambda式树是以一种树的结构被加载到我们的运行时的，只有这样我们才可以在运行时去遍历这个树。
            //但是为什么我们不能根据Expression<TDelegate> 来创建比较复杂的表达式树呢？



            //创建一个复杂的Lambda表达式树

            LoopExpression loopExp = Expression.Loop(

                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                    Expression.Constant("Hello"))
                    );
            // 创建一个代码块表达式包含我们上面创建的loop表达式
            BlockExpression block = Expression.Block(loopExp);

            Expression<Action> lambdaExpression1 = Expression.Lambda<Action>(block);
            lambdaExpression1.Compile().Invoke();

        }


        public static void 输出PI()
        {

            BlockExpression block = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(double) }),
                    Expression.Constant(Math.PI)
                    ));
            Expression<Action> ss = Expression.Lambda<Action>(block);
            ss.Compile()();
        }

        public static void 带参数的表达式树()
        {
            //创建表达树的参数
            ParameterExpression paraExp = Expression.Parameter(typeof(int), "number");

            BlockExpression block = Expression.Block(
                new[] { paraExp },
                //Expression.Call(typeof(Console).GetMethod("WriteLine"),paraExp)
                Expression.Assign(paraExp, Expression.Constant(2)),
                Expression.AddAssignChecked(paraExp, Expression.Constant(8)),

                Expression.Add(paraExp, Expression.Constant(2))


                );

            var exp = Expression.Lambda<Func<int>>(block);
            var ss = exp.Compile()();
            Console.WriteLine("初始化参数：" + ss);
        }


        public static void 输出十个Console(int num = 10)
        {

            ParameterExpression paraIndex = Expression.Parameter(typeof(int));
            ParameterExpression paraEnd = Expression.Parameter(typeof(int));

            Expression.Assign(paraIndex, Expression.Constant(0));
            var end = Expression.Assign(paraEnd, Expression.Constant(num));
            var endd = Expression.Constant(num);
            LabelTarget labelBreak = Expression.Label();

            BlockExpression block = Expression.Block(
                      new[] { paraIndex, paraEnd },

                      Expression.Loop(
                          Expression.IfThenElse(
                              // if 的判断逻辑
                              Expression.LessThan(paraIndex, endd),
                                    //符合条件的 
                                    Expression.Block(
                                        Expression.Call(
                                            null,
                                            typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                                            Expression.Constant("ConsoleMethod")),
                                        Expression.PostIncrementAssign(paraIndex)),
                                    //不符合条件的
                                    Expression.Break(labelBreak)),
                          labelBreak));
            Expression<Action> ss = Expression.Lambda<Action>(block);
            ss.Compile()();
        }




        public static void IndexExpression()
        {
            ParameterExpression arr = Expression.Parameter(typeof(int[]), "arr");
            ParameterExpression index = Expression.Parameter(typeof(int), "index");
            ParameterExpression val = Expression.Parameter(typeof(int), "val");

            Expression arrExpr = Expression.ArrayAccess(arr, index);


            Expression<Func<int[], int, int, int>> lambdaExpr = Expression.Lambda<Func<int[], int, int, int>>(
                Expression.Assign(arrExpr, Expression.Add(arrExpr, val)),
                arr,
                index,
                val);

            Console.WriteLine(arrExpr.ToString());
            // Array[Index]

            Console.WriteLine(lambdaExpr.ToString());
            // (Array, Index, Value) => (Array[Index] = (Array[Index] + Value))

            Console.WriteLine(lambdaExpr.Compile().Invoke(new int[] { 10, 20, 50 }, 2, 5));
            // 15

        }




        public static void InvocationExpression()
        {
            Expression<Func<int, int, bool>> largeNum = (a, b) => a + b > 1000;
            InvocationExpression ininvocationExpressionvo = Expression.Invoke(largeNum, Expression.Constant(500), Expression.Constant(500));

            Console.WriteLine(ininvocationExpressionvo.ToString());

            Console.WriteLine(largeNum.Compile()(512, 512));




        }








    }



}

