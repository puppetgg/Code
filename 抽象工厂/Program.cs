using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(@"在上一专题中介绍了工厂方法模式，工厂方法模式是为了克服简单工厂模式的缺点而设计出来的,简单工厂模式的工厂类随着产品类的增加需要增加额外的代码），而工厂方法模式每个具体工厂类只完成单个实例的创建,所以它具有很好的可扩展性。但是在现实生活中，一个工厂只创建单个产品这样的例子很少，因为现在的工厂都多元化了，一个工厂创建一系列的产品，如果我们要设计这样的系统时，工厂方法模式显然在这里不适用，然后抽象工厂模式却可以很好地解决一系列产品创建的问题,这是本专题所要介绍的内容。

二、抽象工厂详细介绍
这里首先以一个生活中抽象工厂的例子来实现一个抽象工厂，然后再给出抽象工厂的定义和UML图来帮助大家更好地掌握抽象工厂模式，同时大家在理解的时候，可以对照抽象工厂生活中例子的实现和它的定义来加深抽象工厂的UML图理解。

2.1 抽象工厂的具体实现
下面就以生活中 “绝味” 连锁店的例子来实现一个抽象工厂模式。例如，绝味鸭脖想在江西南昌和上海开分店，但是由于当地人的口味不一样，在南昌的所有绝味的东西会做的辣一点，而上海不喜欢吃辣的，所以上海的所有绝味的东西都不会做的像南昌的那样辣，然而这点不同导致南昌绝味工厂和上海的绝味工厂生成所有绝味的产品都不同，也就是某个具体工厂需要负责一系列产品(指的是绝味所有食物)的创建工作，下面就具体看看如何使用抽象工厂模式来实现这种情况。");


            Console.WriteLine("顾客走进武汉的一家小胡鸭店想吃鸭架");
            AbstructXiaoHuYaFactory fac = new WHXiaoHuYaFac();
            XiaoHuYa dd = fac.absXiaoHuYaFac();
            dd.YaJia();

            Console.Read();


        }
    }

    //创建产品类
    public abstract class XiaoHuYa
    {
        public abstract void YaJia();
        public abstract void YaTui();
    }

    //武汉
    public class WHXiaoHuYa : XiaoHuYa
    {
        public override void YaJia()
        {
            Console.WriteLine("这是武汉的鸭架");
        }

        public override void YaTui()
        {
            Console.WriteLine("这是武汉的压腿");

        }
    }
    //上海
    public class SHXiaoHuYa : XiaoHuYa
    {
        public override void YaJia()
        {
            Console.WriteLine("这是上海的鸭架");
        }

        public override void YaTui()
        {
            Console.WriteLine("这是上海的鸭架");
        }
    }


    //抽象工厂
    public abstract class AbstructXiaoHuYaFactory
    {
        public abstract XiaoHuYa absXiaoHuYaFac();

    }
    //具体实现工厂类
    public class WHXiaoHuYaFac : AbstructXiaoHuYaFactory
    {
        //武汉工厂
        public override XiaoHuYa absXiaoHuYaFac()
        {
            return new WHXiaoHuYa();
        }
    }

    //上海工厂
    public class SHXiaoHuYaFac : AbstructXiaoHuYaFactory
    {
        public override XiaoHuYa absXiaoHuYaFac()
        {
            return new SHXiaoHuYa();
        }
    }

}
