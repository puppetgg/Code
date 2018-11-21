using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class UdpServre
{
    public static readonly UdpServre udpServre = new UdpServre();
    private UdpServre()
    {
        //初始化连接字
        iPEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
        //创建udp客户端对象
        udpClient = new UdpClient(iPEndPoint);
    }

    //监听端口
    private int listenPort = 8780;
    private UdpClient udpClient = null;
    private IPEndPoint iPEndPoint = null;

    public void StartServer()
    {
        Console.WriteLine($"lising on port:{listenPort}...");
        new Task(ReceiveMsg).Start();

    }



    private static int count = 1;
    //接收消息
    private void ReceiveMsg()
    {
        while (true)
        {
            IPEndPoint sendiPEndPoint = new IPEndPoint(IPAddress.Any, 8080);
            var receiveBytes = udpClient.Receive(ref sendiPEndPoint);

            Console.WriteLine($"Received from {iPEndPoint.Address.ToString()},{iPEndPoint.Port}:" + Encoding.Default.GetString(receiveBytes));
            var id = Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString().ToString();
            string msg = id.Length == 1 ? id + "^^" : id + "^";

            long oo = 0;
            for (int i = 0; i < 50000000; i++)
            {
                oo = oo + i;
                oo = oo - i;
            }
            byte[] byteDatas = Encoding.Default.GetBytes(msg);
            udpClient.Send(byteDatas, byteDatas.Length, sendiPEndPoint);

        }
    }
}

