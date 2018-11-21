using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 电脑外设抽象工厂
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerDevices dev = new DellFactory().ProductKeyBoard();
            dev.Infomation();

            new PHFactory().ComputerDevicesProduct(1).Infomation();


            Console.Read();


        }
    }

    public abstract class ComputerDevices
    {
        public ComputerDevices(string productSource)

           => ProductSource = productSource;

        protected string ProductSource { get; set; }
        protected abstract string DevicesName { get; }
        public abstract void Infomation();
    }

    public class Mouse : ComputerDevices
    {
        public Mouse(string productSource) : base(productSource) { }


        protected override string DevicesName => "鼠标";


        public override void Infomation()

           => Console.WriteLine("这是一个" + ProductSource + DevicesName);

    }

    public class KeyBord : ComputerDevices
    {
        public KeyBord(string productSource) : base(productSource)
        {

        }
        protected override string DevicesName => "键盘";

        public override void Infomation()

            => Console.WriteLine("这是一个" + ProductSource + DevicesName);

    }

    public abstract class ComputerDevicesFactory
    {

        public abstract string Name { get; }
        //---------------@1---------------------------------
        public ComputerDevices ProductMouse()

             => new Mouse(Name);

        public ComputerDevices ProductKeyBoard()

             => new KeyBord(Name);
        //---------------@2---------------------------------
        public ComputerDevices ComputerDevicesProduct(int type)
        {
            if (type == 1)

                return new Mouse(Name);
            else
                return new KeyBord(Name);

        }
    }

    public class PHFactory : ComputerDevicesFactory
    {
        public override string Name => "惠普工厂";

        //public override ComputerDevices ProductKeyBoard()

        //    => new KeyBord(Name);


        //public override ComputerDevices ProductMouse()

        //    => new Mouse(Name);

    }

    public class DellFactory : ComputerDevicesFactory
    {
        public override string Name => "戴尔工厂";

        //public override ComputerDevices ProductKeyBoard()

        //    => new KeyBord(Name);

        //public override ComputerDevices ProductMouse()

        //    => new KeyBord(Name);

    }

    public class LenovoFactory : ComputerDevicesFactory
    {
        public override string Name => "联想工厂";

        //public override ComputerDevices ProductKeyBoard()

        //    => new KeyBord(Name);

        //public override ComputerDevices ProductMouse()

        //  => new Mouse(Name);
    }
}
