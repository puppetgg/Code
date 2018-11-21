using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"在软件系统中，当创建一个类的实例的过程很昂贵或很复杂，并且我们需要创建多个这样类的实例时，
            如果我们用new操作符去创建这样的类实例，这未免会增加创建类的复杂度和耗费更多的内存空间，
            因为这样在内存中分配了多个一样的类实例对象，然后如果采用工厂模式来创建这样的系统的话，
            随着产品类的不断增加，导致子类的数量不断增多，反而增加了系统复杂程度，所以在这里使用工厂模式来封装类创建过程并不合适，
            然而原型模式可以很好地解决这个问题，因为每个类实例都是相同的，当我们需要多个相同的类实例时，
            没必要每次都使用new运算符去创建相同的类实例对象，此时我们一般思路就是想——只创建一个类实例对象，
            如果后面需要更多这样的实例，可以通过对原来对象拷贝一份来完成创建，这样在内存中不需要创建多个相同的类实例，
            从而减少内存的消耗和达到类实例的复用。 然而这个思路正是原型模式的实现方式。");
            Console.WriteLine("===========================================================================");


            MonkeyKingPrototype monkey = new MonkeyKing2("美猴王");

            MonkeyKingPrototype monkey1 = monkey.Clone();
            Console.WriteLine("Cloned1:\t" + monkey1.ID);

            MonkeyKingPrototype monkey2 = monkey.Clone();
            Console.WriteLine("Cloned2:\t" + monkey2.ID);


            Console.Read();
        }
    }

    public abstract class MonkeyKingPrototype
    {
        public MonkeyKingPrototype(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
        public abstract MonkeyKingPrototype Clone();
    }



    public class MonkeyKing2 : MonkeyKingPrototype
    {
        public MonkeyKing2(string id) : base(id)
        {

        }
        public override MonkeyKingPrototype Clone()
        {
            return (MonkeyKingPrototype)MemberwiseClone();
        }
    }
}
