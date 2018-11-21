using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 聚变和逆变;

namespace 聚变和逆变
{
    class Program
    {
        static void Main(string[] args)
        {
            泛型接口的使用.TT();
            //Anminal dog = new Dog();//

            //List<Anminal> anminals = new List<Anminal>();

            ////dogs = new List<Dog>();//List<dog>没有继承自List<anminal>
            //List<Dog> dogs = new List<Dog>();

            //var transdogs = dogs.Select(x => (Anminal)x).ToList();

            //anminals = transdogs;

            //IEnumerable<Anminal> a = dogs;

            //Anminal<List<object>> aa = new Dog<List<string>>().AAA();

            object[] a1a = new string[] { };

            Anminal<string> ss = null;
            Anminal<object> aa = null;
            ss = aa;

            new List<object>();
            Anminal<object>[] aarr = null;
            Anminal<string>[] ddrr = null;
            ddrr = aarr;

            Anminal<A> ssA = null;
            Anminal<B> ssB = null;
            ssB = ssA;

            //IList<object> objs = new List<string>();


            MyAct<object> aaa = null;
            MyAct<string> bbb = null;
            bbb = aaa;



        }
    }

    public delegate void MyAct<in T>(T t);

    public interface Anminal<in T>
    {




    }

    class A
    {

    }
    class B : A
    {


    }

    class Dog<T> : Anminal<T>
    {
        public T AAA()
        {
            throw new NotImplementedException();
        }
    }

}
