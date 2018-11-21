using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue MSMQ = CreateMessageQueue(@".\private$\tpmsmq");
            MSMQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            Receiver(MSMQ);
        }

        private static void Receiver(MessageQueue mSMQ)
        {
            while (true)
            {
                try
                {
                    Message m = mSMQ.Receive(MessageQueueTransactionType.Single);
                    Console.WriteLine($"{DateTime.Now.ToString()}接收方{m.Body.ToString()}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("{0} 接收方:{1}",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.Message));
                }

            }
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
