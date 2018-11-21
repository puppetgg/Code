using System;
using System.Net.Sockets;

namespace asyncmq
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
