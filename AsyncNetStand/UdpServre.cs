using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncNetStand
{
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
            //new Task(ReceiveMsg).Start();

        }



        private static int count = 1;
        //接收消息
        private void ReceiveMsg()
        {

            //单线程，异步，无阻塞
            while (true)
            {

                var iar = udpClient.BeginReceive(ReceiveCallback, null);
                // iar.AsyncWaitHandle.WaitOne();
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
            //Thread.Sleep(20);
            Console.WriteLine("--com--" + count);
            IPEndPoint sendiPEndPoint = new IPEndPoint(IPAddress.Any, 8080);
            var receiveBytes = udpClient.EndReceive(ar, ref sendiPEndPoint);
            Console.WriteLine($"Received from {iPEndPoint.Address.ToString()},{iPEndPoint.Port}:" + Encoding.Default.GetString(receiveBytes));
            SendMsg(sendiPEndPoint);

        }

        private void SendMsg(IPEndPoint sendiPEndPoint)
        {
            var id = Thread.CurrentThread.ManagedThreadId.ToString();
            string msg = id.Length == 1 ? id + "^^" : id + "^";
            byte[] byteDatas = Encoding.Default.GetBytes(msg);

            Console.WriteLine("检测发送套签字：" + sendiPEndPoint.Port + sendiPEndPoint.Address.ToString());

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
