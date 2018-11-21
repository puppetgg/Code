using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 汽车构建模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(@"将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示
            四个要素

            产品类：一般是一个较为复杂的对象，也就是说创建对象的过程比较复杂，一般会有比较多的代码量。
            在本类图中，产品类是一个具体的类，而非抽象类。实际编程中，产品类可以是由一个抽象类与它的不同实现组成，
            也可以是由多个抽象类与他们的实现组成。
            
            抽象建造者：引入抽象建造者的目的，是为了将建造的具体过程交与它的子类来实现。这样更容易扩展。
            一般至少会有两个抽象方法，一个用来建造产品，一个是用来返回产品。
            
            建造者：实现抽象类的所有未实现的方法，具体来说一般是两项任务：组建产品；返回组建好的产品。
           
            导演类：负责调用适当的建造者来组建产品，导演类一般不与产品类发生依赖关系，与导演类直接交互的是建造者类。
            一般来说，导演类被用来封装程序中易变的部分。/r");
            Console.WriteLine("--------------------------------------------------------------------------");


            Console.WriteLine("顾客去汽车市场买车");




            Console.Read();





        }
    }


    public class Director
    {
        public Director()
        {
            Console.WriteLine("指挥者或者说是导演者");
        }

    }

    public class CarProduct
    {
        public CarProduct()
        {
            Console.WriteLine("产品类");
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public void setName(String name)
        {
            this.Name = name;
        }
        public void setType(String type)
        {
            this.Type = type;
        }


        public void ShowCar()
        {
            Console.WriteLine($"这是一辆{Name}-{Type}车。");
        }
    }

    public abstract class CarBuilder
    {
        public CarBuilder()
        {
            Console.WriteLine("汽车组装抽象类");
        }

        public abstract void MadeCar();
        public abstract CarProduct ShowMadeCompeled();

    }
    public class CarBuilderXiaoWang : CarBuilder
    {
        public CarBuilderXiaoWang()
        {
            Console.WriteLine("汽车组装员小王");
        }

        public override void MadeCar()
        {
            throw new NotImplementedException();
        }

        public override CarProduct ShowMadeCompeled()
        {
            throw new NotImplementedException();
        }
    }
}
