using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 疑惑检测
{

    public class MyClass
    {
        public int MyProperty { get; set; }
        public string MyProperty2 { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<MyClass> lst = new List<MyClass>() {

                new MyClass() { MyProperty=1,MyProperty2="a"},
                new MyClass() { MyProperty=2,MyProperty2="b"}
            };


            var ss = DateTime.Parse("2000/1/1 0:00");

            //  File.WriteAllText(@"D:\\1.txt", JsonConvert.SerializeObject(lst));

            //lst = null;
            var res = lst.Where(x => x.MyProperty2 == "").Count();//.ToList();


            AAA a = new AAA();
            a.T1();
            Thread.Sleep(300);
            new AAA().T2();
            Thread.Sleep(300);

            new AAA().T3();
            Console.ReadKey();
        }
    }



    public class AAA
    {
        //static AAA()
        //{
        //    Task.Factory.StartNew(ddd);
        //}

        static void ddd()
        {
            while (true)
            {
                Console.WriteLine($"ssss{DateTime.Now.ToString()}ssssssssssssssssss");
                Thread.Sleep(1000);
            }
        }

        static readonly Action a = ddd;

        public void T1()
        {

            Task.Factory.StartNew(() => a());
            Console.WriteLine("---------T1----");
        }

        public void T2()
        {

            Task.Factory.StartNew(() => a());
            Console.WriteLine("---------T2----");
        }


        public void T3()
        {

            Task.Factory.StartNew(() => a());
            Console.WriteLine("---------T3----");
        }
    }
}
