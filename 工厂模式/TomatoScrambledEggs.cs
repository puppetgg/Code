using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式
{
    public class TomatoScrambledEggs : Foods
    {
        public override void PrintFood()
        {
            Console.WriteLine("西红柿炒蛋好了！");
        }
    }
}
