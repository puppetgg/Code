using System;
using System.Messaging;
using System.Security.Cryptography;

namespace MSMQServer
{
    class Program
    {
        static void Main(string[] args)
        {

            MessageQueue MSMQ = CreateMessageQueue(@".\private$\log");
            MSMQ.Formatter = new XmlMessageFormatter();
            Console.WriteLine("是否继续发送消息:Y/N?");
            string cmd = Console.ReadLine();
            while (cmd.Contains("y"))
            {
                Sender(MSMQ);
                Console.WriteLine("是否继续发送消息:Y/N?");
                cmd = Console.ReadLine();
            }

            Console.WriteLine("按任意键以停止...");
            Console.ReadKey();
        }

        private static void Sender(MessageQueue mSMQ)
        {
            try
            {
                string random = GenerateRandom();
                string obj = string.Format($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} 发送方{random}");
                mSMQ.Send(obj, MessageQueueTransactionType.Single);
                Console.WriteLine(obj);
            }
            catch (Exception ex)
            {

                Console.WriteLine(string.Format("{0} 发送方:{1}",
                  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.Message));
            }
        }

        private static string GenerateRandom()
        {
            int seed = GetRandomSeed();
            return new Random(seed).Next(int.MaxValue).ToString();
        }

        private static int GetRandomSeed()
        {
            // 创建加密随机数生成器 生成强随机种子
            byte[] bytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        private static MessageQueue CreateMessageQueue(string v)
        {
            MessageQueue mq = null;

            if (MessageQueue.Exists(v))
            {
                mq = new MessageQueue(v);
            }
            else
            {
                mq = MessageQueue.Create(v, true);
            }


            return mq;
        }
    }
}
