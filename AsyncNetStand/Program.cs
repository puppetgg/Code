using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncNetStand
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
