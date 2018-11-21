using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncUDPServer
{
    public class UdpServre
    {
        public static readonly UdpServre udpServre = new UdpServre();
        private UdpServre()
        {

            iPEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
            udpClient = new UdpClient();
        }

        //监听端口
        private UdpClient udpClient = null;
        private IPEndPoint iPEndPoint = null;
        private int listenPort = 8781;
        public void StartServer()
        {
            Console.WriteLine($"lising on port:{listenPort}...");
            new Task(ReceiveMsg).Start();

        }
        //接收消息
        private void ReceiveMsg()
        {

            //单线程，异步，无阻塞
            while (true)
            {

                udpClient.BeginReceive(ReceiveCallback, null);

            }
        }
        //接收回调函数
        private void ReceiveCallback(IAsyncResult ar)
        {

            IPEndPoint sendiPEndPoint = new IPEndPoint(IPAddress.Any, 8080);
            var receiveBytes = udpClient.EndReceive(ar, ref sendiPEndPoint);
            //File.WriteAllText("1.txt", Encoding.Default.GetString(receiveBytes));
            //Console.WriteLine($"Received from {iPEndPoint.Address.ToString()}:{iPEndPoint.Port}");
            //Console.WriteLine("    msg:" + Encoding.Default.GetString(receiveBytes));
        }

        public void SendMsg(string msg)
        {

            IPEndPoint sendiPEndPoint = new IPEndPoint(IPAddress.Parse("10.18.105.188"), 8780);
            byte[] byteDatas = Encoding.Default.GetBytes(msg);
            //发送消息
            udpClient.BeginSend(byteDatas, byteDatas.Length, sendiPEndPoint, SendCallBack, null);

        }

        private void SendCallBack(IAsyncResult ar)
        {
            int a = udpClient.EndSend(ar);
            Console.WriteLine("发送结果：" + a);
        }
    }
}
