using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模拟鼠标的工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Mouse mouse = new PHMouseFactory().ProductMouse();
            mouse.Infomation();
            mouse = new LenovoFactory().ProductMouse();
            mouse.Infomation();
            Console.Read();
        }
    }


    public class Mouse
    {
        public Mouse(string _name)
        {
            name = _name;
        }
        string name = string.Empty;
        public void Infomation()
        {
            Console.WriteLine("这是一个" + name + "鼠标");
        }
    }

    public abstract class MouseFactory
    {
        public abstract string Name { get; }
        public abstract Mouse ProductMouse();
    }

    public class PHMouseFactory : MouseFactory
    {
        public override string Name => "惠普工厂";

        public override Mouse ProductMouse()

            => new Mouse(Name);

    }

    public class LenovoFactory : MouseFactory
    {
        public override string Name => "联想工厂";

        public override Mouse ProductMouse()

          => new Mouse(Name);
    }
}
