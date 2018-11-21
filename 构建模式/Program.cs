using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 构建模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            ComputerBuilderOne xiaoWang = new ComputerBuilderOne();

            director.Construct(xiaoWang);
            xiaoWang.GetComputer().ShowCompeledComputer();


            Console.Read();

        }
    }


    public class Director
    {

        //
        public void Construct(Builder builder)
        {
            builder.BuildMainboard();
            builder.BuildCPU();
            builder.BuildHD();

        }

    }

    public abstract class Builder
    {
        public Builder()
        {
            Console.WriteLine("由老板直接和采购人员打交道所以要提供产品");
        }
        //第一步：装CPU
        //声明为抽象方法，具体由子类实现 
        public abstract void BuildCPU();

        //第二步：装主板
        //声明为抽象方法，具体由子类实现 
        public abstract void BuildMainboard();

        //第三步：装硬盘
        //声明为抽象方法，具体由子类实现 
        public abstract void BuildHD();

        //返回产品的方法：获得组装好的电脑
        public abstract Computer GetComputer();
    }

    public class ComputerBuilderOne : Builder
    {
        Computer computer = new Computer();
        public override void BuildCPU()
        {
            computer.Add("组装CPU");
        }

        public override void BuildHD()
        {
            computer.Add("组装硬盘");
        }

        public override void BuildMainboard()
        {
            computer.Add("组装主板");
        }



        public override Computer GetComputer()
        {
            return computer;
        }
    }
    public class ComputerBuilderTwo : Builder
    {
        public override void BuildCPU()
        {
            throw new NotImplementedException();
        }

        public override void BuildHD()
        {
            throw new NotImplementedException();
        }

        public override void BuildMainboard()
        {
            throw new NotImplementedException();
        }


        public override Computer GetComputer()
        {
            throw new NotImplementedException();
        }
    }



    public class Computer
    {
        public Computer()
        {
            Console.WriteLine("构建者模式将复杂对象的构建和表现分离开来，使得相同的构建流程产生不同的对象");
            Console.WriteLine("eg:同样的组装电脑流程，使用不同级别的配件会组装成不同的电脑");
        }


        private IList<string> computerParts = new List<string>();

        public void Add(string part)
        {
            computerParts.Add(part);

        }


        public void ShowCompeledComputer()
        {
            foreach (var item in computerParts)
            {
                Console.WriteLine($"电脑的{item}部分已安装完毕；");
            }

            Console.WriteLine("电脑组装完毕！");
        }
    }



}
