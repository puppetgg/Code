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
        //new Task(ReceiveMsg).Start();
        new Task(SendMsg).Start();

    }



    private static int count = 1;
    //接收消息
    private void ReceiveMsg()
    {

        //单线程，异步，无阻塞
        while (true)
        {

            var iar = udpClient.BeginReceive(ReceiveCallback, null);
            //iar.AsyncWaitHandle.WaitOne();
            //count++;
            //Console.WriteLine("--Rec--" + count + "-id-" + Thread.CurrentThread.ManagedThreadId);
        }
    }
    //接收回调函数
    private void ReceiveCallback(IAsyncResult ar)
    {
        long oo = 0;
        for (int i = 0; i < 50000000; i++)
        {
            oo = oo + i;
            oo = oo - i;
        }
        IPEndPoint sendiPEndPoint = new IPEndPoint(IPAddress.Any, 8080);
        var receiveBytes = udpClient.EndReceive(ar, ref sendiPEndPoint);
        Console.WriteLine($"Received from {iPEndPoint.Address.ToString()},{iPEndPoint.Port}:" + Encoding.Default.GetString(receiveBytes));
        datas.Enqueue(new Data() { ipend = sendiPEndPoint, data = new byte[] { 0, 1, 0 } });//SendMsg(sendiPEndPoint);

    }

    static Queue<Data> datas = new Queue<Data>();

    public class Data
    {

        public IPEndPoint ipend { get; set; }
        public byte[] data { get; set; }
    }
    private void SendMsg()
    {
        IPEndPoint iP = new IPEndPoint(IPAddress.Any, 8083);
        UdpClient sendClient = new UdpClient();

        while (true)
        {


            Data dat = null;
            if (datas.Count > 0)
            {
                Console.WriteLine("---------------");
                dat = datas.Dequeue();

                byte[] sen = Encoding.UTF8.GetBytes("333");
                //发送消息
                sendClient.BeginSend(sen, sen.Length, dat.ipend, null, null);

            }

        }


    }


}

