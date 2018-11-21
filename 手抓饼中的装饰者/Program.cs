using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 手抓饼中的装饰者
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public abstract class PanCake
    {
        public string Desc { get; set; }
        public string GetDesc()
        {
            return Desc;
        }
        public abstract int Price();
    }


}
