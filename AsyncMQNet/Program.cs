using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncMQNet
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpServre.udpServre.StartServer();
            Console.Read();
        }
    }
}
