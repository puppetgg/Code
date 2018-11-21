using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聚变和逆变
{
    internal class Anmial
    {

        public virtual void DoSth()
        {
            Console.WriteLine("i am the base class ");
        }
    }

    internal class Dogs : Anmial
    {

        public override void DoSth()
        {
            Console.WriteLine("i am the dog class ");
        }


    }

    internal interface IFactory<out T>
    {
        T Create();

    }

    internal class EnClass<T> : IFactory<T>
    {
        public T Create()
        {
            return Activator.CreateInstance<T>();
        }
    }

    public class 泛型类型的转换协变和逆变
    {


        public static void TTT()
        {
            IFactory<Dogs> dogFactory = new EnClass<Dogs>();
            IFactory<Anmial> animalFactory = dogFactory; //协变
            Anmial animal = animalFactory.Create();
            animal.DoSth();
            Console.ReadKey();


        }

    }
}
