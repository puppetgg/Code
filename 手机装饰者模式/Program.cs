using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 手机装饰者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new GuaShi(new IPhone());
            phone.Print();


            Console.Read();
        }
    }

    public class GuaShi : Direactor
    {
        public GuaShi(Phone p) : base(p)
        {
            Console.WriteLine("测试分支");
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("增加手机挂饰");

        }


    }

    public class TieMo : Direactor
    {
        public TieMo(Phone p) : base(p)
        {

        }
        public override void Print()
        {
            base.Print();

            Console.WriteLine("手机贴膜了");
        }

    }

    public abstract class Direactor : Phone
    {
        public Direactor(Phone ph)
        {
            _phone = ph;
        }
        private Phone _phone;
        public override void Print()
        {
            _phone.Print();
        }
    }

    public class IPhone : Phone
    {
        public override void Print()
        {
            Console.WriteLine("这是一部苹果手机");
        }
    }
    public abstract class Phone
    {
        public abstract void Print();
    }
}
