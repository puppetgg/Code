using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂
{
    class Program
    {
        //static void Main(string[] args)
        //{

        //简单工厂模式我们也可以理解为负责生产对象的一个类, 我们平常编程中，
        //当使用"new"关键字创建一个对象时，此时该类就依赖与这个对象，也就是他们之间的耦合度高
        //}


        /*  简单工厂模式与之前的实现也有它的优点：

            简单工厂模式解决了客户端直接依赖于具体对象的问题，客户端可以消除直接创建对象的责任，而仅仅是消费产品。
            简单工厂模式实现了对责任的分割。
            简单工厂模式也起到了代码复用的作用，因为之前的实现（自己做饭的情况）中，
            换了一个人同样要去在自己的类中实现做菜的方法，然后有了简单工厂之后，
            去餐馆吃饭的所有人都不用那么麻烦了，只需要负责消费就可以了。
            此时简单工厂的烧菜方法就让所有客户共用了。
            （同时这点也是简单工厂方法的缺点——因为工厂类集中了所有产品创建逻辑，
            一旦不能正常工作，整个系统都会受到影响，也没什么不好理解的，就如事物都有两面性一样道理）
            虽然上面已经介绍了简单工厂模式的缺点，下面还是总结下简单工厂模式的缺点：

            工厂类集中了所有产品创建逻辑，一旦不能正常工作，整个系统都会受到影响
            （通俗地意思就是：一旦餐馆没饭或者关门了，很多不愿意做饭的人就没饭吃了）
            系统扩展困难，一旦添加新产品就不得不修改工厂逻辑，这样就会造成工厂逻辑过于复杂。
            了解了简单工厂模式之后的优缺点之后，我们之后就可以知道简单工厂的应用场景了：

            当工厂类负责创建的对象比较少时可以考虑使用简单工厂模式（）
            客户如果只知道传入工厂类的参数，对于如何创建对象的逻辑不关心时可以考虑使用简单工厂模式*/
    }


    public class Customer
    {
        static void Main()
        {

            Food f1 = Cook("西红柿炒蛋");
            f1.Print();
            Console.Read();


        }

        public static Food Cook(string type)
        {
            Food food = null;
            if (type == "西红柿炒蛋")
            {
                food = new TomatoScrambledEggs();


            }
            if (type == "土豆肉丝")
            {
                food = new ShreddedPorkWithPotatoes();
            }
            return food;

        }



    }

    public abstract class Food
    {
        //输出点了什么菜
        public abstract void Print();
    }

    /// <summary>
    /// 西红柿炒鸡蛋这道菜
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("自己做一份西红柿炒蛋！");
        }
    }

    /// <summary>
    /// 土豆肉丝这道菜
    /// </summary>
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("自己做一份土豆肉丝");
        }
    }
}
