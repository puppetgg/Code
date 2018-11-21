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

    public async void StartServer()
    {
        Console.WriteLine($"lising on port:{listenPort}...");
        //new Task(ReceiveMsg).Start();
        await ReceiveMsg();
    }




    //接收消息
    private async void ReceiveMsg()
    {

        IPEndPoint sendiPEndPoint = new IPEndPoint(IPAddress.Any, 8080);
        var receiveBytes = await udpClient.ReceiveAsync();

        Console.WriteLine($"Received from {iPEndPoint.Address.ToString()},{iPEndPoint.Port}:" + Encoding.Default.GetString(receiveBytes));
        var id = Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString().ToString();
        string msg = id.Length == 1 ? id + "^^" : id + "^";

        byte[] byteDatas = Encoding.Default.GetBytes(msg);
        udpClient.Send(byteDatas, byteDatas.Length, sendiPEndPoint);



    }
}

