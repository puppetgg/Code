using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================不使用桥接模式====================");
            Console.WriteLine("解决了不同品牌电视机的重用问题");
            MoveControl control = new ConcreteRemote(new Samsung());
            control.SwichProject();
            control.PowerOn();
            control.PowerOff();
            Console.WriteLine("增加新功能");
            ((ConcreteRemote)control).NewFunctionSamsung();


            Console.WriteLine("=================使用桥接模式=======================");

            control = new ConcreteRemote(new ChangHong());
            // control.TVimplementor = new ChangHong();
            control.SwichProject();

            (control as ConcreteRemote).NewFunction();
            Console.Read();

        }
    }
    public class Samsung : TV
    {
        public override void PowerOff()
        {
            Console.WriteLine("Samsung牌电视机开机");
        }

        public override void PowerOn()
        {
            Console.WriteLine("Samsung牌电视机关机");
        }

        public override void SwichProject()
        {
            Console.WriteLine("Samsung牌电视机换台");

        }
        public void NewFunction()
        {
            Console.WriteLine("Samsung牌电视机的新功能");

        }
    }
    public class ChangHong : TV
    {
        public override void PowerOff()
        {
            Console.WriteLine("长虹牌电视机开机");
        }

        public override void PowerOn()
        {
            Console.WriteLine("长虹牌电视机关机");
        }

        public override void SwichProject()
        {
            Console.WriteLine("长虹牌电视机换台");

        }
        public void NewFunction()
        {
            Console.WriteLine("长虹牌电视机的新功能");

        }
    }

    public class ConcreteRemote : MoveControl
    {
        public ConcreteRemote(TV tV) : base(tV)
        {

        }

        public override void SwichProject()
        {
            Console.WriteLine("------------------");
            base.SwichProject();
            Console.WriteLine("------------------");
        }

        public void NewFunction()
        {
            (TVimplementor as ChangHong).NewFunction();
        }
        public void NewFunctionSamsung()
        {
            (TVimplementor as Samsung).NewFunction();
        }


    }

    public class MoveControl
    {
        public MoveControl(TV tV)
        {
            TVimplementor = tV;
        }
        protected TV TVimplementor { get; }
        public virtual void PowerOn()
        {
            TVimplementor.PowerOn();
        }
        public virtual void PowerOff()
        {
            TVimplementor.PowerOff();
        }
        public virtual void SwichProject()
        {
            TVimplementor.SwichProject();
        }

    }

    public abstract class TV
    {
        public abstract void PowerOn();
        public abstract void PowerOff();
        public abstract void SwichProject();

    }
}
