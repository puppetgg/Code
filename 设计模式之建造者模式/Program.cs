using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式之建造者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示");


            Director director = new Director();
            Builder xiaowang = new ConcreteBuilderXiaoWang();
            Builder xiaozhang = new ConcreteBuilderXiaoWang();

            director.Construct(xiaowang);

            Computer computer1 = xiaowang.ComplantComputer();
            computer1.Show();


            Console.Read();

        }
    }

    public class Director
    {

        public void Construct(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }
    }


    public class Computer
    {

        private IList<string> computerParts = new List<string>();

        // 把单个组件添加到电脑组件集合中
        public void Add(string part)
        {
            computerParts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("电脑开始在组装.......");
            foreach (string part in computerParts)
            {
                Console.WriteLine("组件" + part + "已装好");
            }

            Console.WriteLine("电脑组装好了");
        }
    }

    public abstract class Builder
    {
        public abstract void BuildPartCPU();
        public abstract void BuildPartMainBoard();
        public abstract Computer ComplantComputer();
    }


    public class ConcreteBuilderXiaoWang : Builder
    {
        Computer computer = new Computer();

        public override void BuildPartCPU()
        {
            computer.Add("CPU1");
        }

        public override void BuildPartMainBoard()
        {
            computer.Add("Main board1");
        }

        public override Computer ComplantComputer()
        {
            return computer;
        }
    }

    public class ConcreteBuilderXiaoZhang : Builder
    {

        Computer computer = new Computer();

        public override void BuildPartCPU()
        {
            computer.Add("CPU1");
        }

        public override void BuildPartMainBoard()
        {
            computer.Add("Main board1");
        }

        public override Computer ComplantComputer()

            => computer;

    }



}
