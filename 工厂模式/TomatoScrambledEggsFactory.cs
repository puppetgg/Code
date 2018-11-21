using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式
{
    class TomatoScrambledEggsFactory : Creator
    {
        public override Foods CreateFoddFactory()
        {
            return new TomatoScrambledEggs();
        }
    }
}
