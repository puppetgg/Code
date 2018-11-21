using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态类型dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            //dynamic、Object还是Var？
            //那么，dynamic、Object和var之间的实际区别是什么？何时使用它们？
            //先说说var，经常有人会拿dynamic和var进行比较。实际上，var和dynamic完全是两个概念，根本不应该放在一起做比较。
            //var实际上编译器抛给我们的语法糖，一旦被编译，编译器就会自动匹配var变量的实际类型，
            //并用实际类型来替换该变量的声明，等同于我们在编码时使用了实际类型声明。
            //而dynamic被编译后是一个Object类型，编译器编译时不会对dynamic进行类型检查。
            //再说说Object，上面提到dynamic类型再编译后是一个Object类型，同样是Object类型，那么两者的区别是什么呢？
            //除了在编译时是否进行类型检查之外，另外一个重要的区别就是类型转化，这也是dynamic很有价值的地方，
            //dynamic类型的实例和其他类型的实例间的转换是很简单的，开发人员能够很方便地在dyanmic和非dynamic行为间切换。
            //任何实例都能隐式转换为dynamic类型实例，见下面的例子：


            //所谓用dynamic代替反射，指的是通过反射获取类的实例对象，然后通过动态类型接受这个对象，因为是通过反射得到的，本地并没有
            //实例类，通过

           // dynamic dyn=new Xpando


        }
    }
}
