using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 三角插孔和两脚插头之间的适配
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("三角插板需要两脚插头，但是现在只有的电器的插头只有两脚的，因此需要转换适配");

            Console.WriteLine("三孔插板现在需要接通两脚插头通电");
            IThreePinsSocket threePinsSocket = new SocketAdapter();
            threePinsSocket.Request();

            Console.Read();

        }
    }
    public class TwoPinPlug
    {
        public void SpecificRequest()
        {
            Console.WriteLine("这是一个两脚插头");
        }
    }


    //类的适配
    public class SocketAdapter : TwoPinPlug, IThreePinsSocket
    {
        public void Request()
        {
            SpecificRequest();
        }
    }

    //对象的适配
    public class SocketAdapterUseObject : IThreePinsSocket
    {
        TwoPinPlug twoPinPlug = new TwoPinPlug();
        public void Request()
        {
            twoPinPlug.SpecificRequest();
        }
    }
    //类似的还有接口的适配器模式

    public interface IThreePinsSocket
    {
        void Request();
    }
}
