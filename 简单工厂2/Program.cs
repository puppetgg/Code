using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂2
{
    class Program
    {
        static void Main(string[] args)
        {



            Food f1 = FoodSimoleFactory.CreateFood("西红柿炒蛋");
            f1.Print();
            Console.Read();



        }
    }


    public class FoodSimoleFactory
    {
        public static Food CreateFood(string type)
        {

            Food food = null;
            if (type.Equals("土豆肉丝"))
            {
                food = new ShreddedPorkWithPotatoes();
            }
            else if (type.Equals("西红柿炒蛋"))
            {
                food = new TomatoScrambledEggs();
            }

            return food;

        }

    }

    public abstract class Food
    {
        public abstract void Print();

    }


    /// <summary>
    /// 西红柿炒鸡蛋这道菜
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("餐馆做的一份西红柿炒蛋！");
        }
    }

    /// <summary>
    /// 土豆肉丝这道菜
    /// </summary>
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("餐馆做的一份土豆肉丝");
        }
    }
}
