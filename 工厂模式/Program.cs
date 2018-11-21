using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("工厂方法模式的实现");
            Console.Write(@"　在简单工厂模式中讲到简单工厂模式的缺点，
            有一点是——简单工厂模式系统难以扩展，一旦添加新产品就不得不修改简单工厂方法，
            这样就会造成简单工厂的实现逻辑过于复杂，然而本专题介绍的工厂方法模式可以解决简单工厂模式中存在的这个问题，
            下面就具体看看工厂模式是如何解决该问题的");

            Console.Write(@"工厂方法模式之所以可以解决简单工厂的模式，
                是因为它的实现把具体产品的创建推迟到子类中，
                此时工厂类不再负责所有产品的创建，而只是给出具体工厂必须实现的接口，
                这样工厂方法模式就可以允许系统不修改工厂类逻辑的情况下来添加新产品，
                这样也就克服了简单工厂模式中缺点。下面看下工厂模式的具体实现代码
                （这里还是以简单工厂模式中点菜的例子来实现）");
            Console.Read();


        }
    }
}
