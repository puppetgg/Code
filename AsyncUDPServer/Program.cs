using System;

namespace AsyncUDPServer
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
