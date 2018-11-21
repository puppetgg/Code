using System;

namespace UDPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncUDPServer.UdpServre.udpServre.StartServer();

            while (true)
            {
                var msg = Console.ReadLine();
                if (string.IsNullOrEmpty(msg))
                    continue;
                AsyncUDPServer.UdpServre.udpServre.SendMsg(msg);



            }
        }
    }
}
