using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 构建者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            BossDirector director = new BossDirector();
            director.CommondCoder();
            director.GetSoftWare().ShowSoftWare();

            director.CommondCoderB();
            director.GetSoftWareB().ShowSoftWare();
            Console.Read();
        }
    }

    public class BossDirector
    {
        CoderBuilder coderA = new CoderA();
        public void CommondCoder()
        {
            coderA.CodeProcess("DMS");
        }

        public SoftWare GetSoftWare()
        {
            return coderA.CompeledSoftWare();
        }

        CoderBuilder coderB = new CoderB();
        public void CommondCoderB()
        {
            coderB.CodeProcess("KMS");
        }

        public SoftWare GetSoftWareB()
        {
            return coderB.CompeledSoftWare();
        }

    }
    public class CoderB : CoderBuilder
    {
        protected override SoftWare softWare => new KMSSoftWare();

        public override void CodeProcess(string typeOfSoftWare)
        {
            if (typeOfSoftWare == "KMS")
            {
                softWare.CodeSoftWare("①分析功能需求");
                softWare.CodeSoftWare("②完成代码编写");
                softWare.CodeSoftWare("③测试相关功能");
            }
        }

        public override SoftWare CompeledSoftWare()
        {
            return softWare;
        }
    }


    public class CoderA : CoderBuilder
    {
        protected override SoftWare softWare => new DMSSoftWare();

        public override void CodeProcess(string typeOfSoftWare)
        {
            if (typeOfSoftWare == "DMS")
            {
                softWare.CodeSoftWare("①分析功能需求");
                softWare.CodeSoftWare("②完成代码编写");
                softWare.CodeSoftWare("③测试相关功能");
            }
        }

        public override SoftWare CompeledSoftWare()
        {
            return softWare;
        }
    }
    public abstract class CoderBuilder
    {
        protected abstract SoftWare softWare { get; }
        public abstract void CodeProcess(string typeOfSoftWare);
        public abstract SoftWare CompeledSoftWare();

    }


    public abstract class SoftWare
    {
        protected IList<string> steps = new List<string>();

        public abstract string Name { get; }

        public abstract void CodeSoftWare(string step);

        public abstract void ShowSoftWare();

    }

    public class DMSSoftWare : SoftWare
    {
        public override string Name => "這是一个DMS系统";

        public override void CodeSoftWare(string step)
        {
            Console.WriteLine("已完成" + step + "部分。");
        }

        public override void ShowSoftWare()
        {
            Console.WriteLine(Name + "，系统已做好。");
        }
    }

    public class KMSSoftWare : SoftWare
    {
        public override string Name => "這是一个KMS系统==========";
        public override void CodeSoftWare(string step)
        {
            Console.WriteLine("已完成" + step + "部分。");
        }

        public override void ShowSoftWare()
        {
            Console.WriteLine(Name + "，系统已做好。");
        }
    }
}
