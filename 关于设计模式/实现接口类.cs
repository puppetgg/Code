using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于设计模式
{
    internal class 实现接口类 : IDoSomeOthers
    {
        public int Add(int a)
        {
            return a + 100;

        }
    }
}
