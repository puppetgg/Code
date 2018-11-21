using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace asyncmq
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

        private Queue<string> queue = new Queue<string>();
        //监听端口
        private int listenPort = 8780;
        private UdpClient udpClient = null;
        private IPEndPoint iPEndPoint = null;

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

                var iar = udpClient.BeginReceive(ReceiveCallback, null);

            }
        }
        //接收回调函数
        private void ReceiveCallback(IAsyncResult ar)
        {


            IPEndPoint sendiPEndPoint = new IPEndPoint(IPAddress.Any, 8080);
            var receiveBytes = udpClient.EndReceive(ar, ref sendiPEndPoint);
            Console.WriteLine($"Received from {iPEndPoint.Address.ToString()}:{iPEndPoint.Port}");
            string msg = Encoding.Default.GetString(receiveBytes);
            Console.WriteLine("    msg:" + msg);
            if (string.IsNullOrEmpty(msg))

                msg = queue.Dequeue();
            else
                queue.Enqueue(msg);
            Console.WriteLine("queue的数量：" + queue.Count);
            for (int i = 0; i < queue.Count; i++)
            {

                Console.WriteLine("datas:" + "");

            }
            SendMsg(sendiPEndPoint, msg);

        }

        private void SendMsg(IPEndPoint sendiPEndPoint, string msg)
        {
            byte[] byteDatas = Encoding.Default.GetBytes(msg);

            Console.WriteLine("检测发送套签字：" + sendiPEndPoint.Port + ":" + sendiPEndPoint.Address.ToString());

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
