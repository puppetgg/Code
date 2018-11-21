using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 单利模式实例
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.为什么要使用单例模式？
            //线程安全及资源开销



            Console.WriteLine("静态构造函数中不会有修饰符");

            Parallel.For(0, 1000000, _ =>
            {
                //SingleThree.GetSingleThree.Test(Task.CurrentId.Value.ToString());
                //SingleTwo.GetSingle.ToString();

                //线程进入死循环
                //Task.Delay(100).Wait();

                //sleep线程暂时释放资源  为获取并发此处用sleep更合适
                Thread.Sleep(1000);
                Single4.GetSingle().count++;
                Single4.GetSingle().Test();


                //SingleTwo.GetSingle.count++;
                //SingleTwo.GetSingle.ToString();

            });

            Console.Read();
        }
    }




    public class Single4
    {
        static Single4 _single4;
        private Single4()
        {
            Console.WriteLine($"检测单利模式 -##{Task.CurrentId}这是构造函数 4 ");
        }

        public static Single4 GetSingle()
        {

            if (_single4 == null)
            {
                _single4 = new Single4();
            }
            return _single4;
        }

        public int count = 0;

        public void Test()
        {
            Console.Write($"--##{Task.CurrentId}---" + count);
        }
    }




    public sealed class SingleThree
    {
        //延迟初始化的
        private SingleThree()
        {
            Console.WriteLine("检测单利模式 这是构造函数 therr ");
        }

        public static SingleThree GetSingleThree

            => Nested.Instance;
        private class Nested
        {
            internal static readonly SingleThree Instance = null;
            static Nested()
            {
                Instance = new SingleThree();
            }

        }


        public void Test(string id)
        {

            Console.WriteLine("当前线程id----" + id);
        }

    }


    public class SingleOne
    {
        private static SingleOne _singleOne;
        private SingleOne()
        {
            Console.WriteLine("检测单利模式 这是构造函数one ");
            _singleOne = new SingleOne();
        }

        public static SingleOne GetSingle()
        {
            return _singleOne;
        }
    }

    public class SingleTwo
    {
        private SingleTwo()
        {
            Console.WriteLine("检测单利模式 这是构造函数two ");
        }

        public int count = 0;
        public override string ToString()
        {

            Console.Write("--" + count);
            return "2";
        }
        public static readonly SingleTwo GetSingle = new SingleTwo();

    }


}
