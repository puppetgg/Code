using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式
{
    public class ShreddedPorkWithPotatoes : Foods
    {
        public override void PrintFood()
        {
            Console.WriteLine("土豆肉丝好了");
        }
    }
}
