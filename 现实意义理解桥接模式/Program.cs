using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 现实意义理解桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            AreaA areaA = new AreaA4();
            areaA.qiao = new AreaB4();
            areaA.FromArea();
            areaA.qiao.TargetAreaB();
            Console.ReadKey(); 


        }
    }

    public class AreaA4 : AreaA
    {
        public override void FromArea()
        {
            Console.WriteLine("出发地为A4");
        }
    }

    public abstract class AreaA
    {
        public Qiao qiao;
        public abstract void FromArea();
    }

    public class AreaA1 : AreaA
    {
        public override void FromArea()
        {
            Console.WriteLine("出发地为A1");
        }
    }
    public class AreaA2 : AreaA
    {
        public override void FromArea()
        {
            Console.WriteLine("出发地为A2");
        }
    }
    public class AreaA3 : AreaA
    {
        public override void FromArea()
        {
            Console.WriteLine("出发地为A3");
        }
    }

    public class AreaB4 : Qiao
    {
        public void TargetAreaB()
        {
            Console.WriteLine("我要去B4");

        }
    }

    public interface Qiao
    {
        void TargetAreaB();
    }

    public class AreaB1 : Qiao
    {
        public void TargetAreaB()
        {
            Console.WriteLine("我要去B1");

        }
    }
    public class AreaB2 : Qiao
    {
        public void TargetAreaB()
        {
            Console.WriteLine("我要去B2");

        }
    }
    public class AreaB3 : Qiao
    {
        public void TargetAreaB()
        {
            Console.WriteLine("我要去B3");

        }
    }
}
