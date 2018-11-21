using System;

namespace 双udp版本
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
