using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQLogSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("开始监听log队列");


            MessageQueue MSMQ = null;
            if (!MessageQueue.Exists(@".\private$\log"))
                MSMQ = MessageQueue.Create(@".\private$\log");
            MSMQ = new MessageQueue(@".\private$\log");

            MSMQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            while (true)
            {
                var msg = MSMQ.Receive(MessageQueueTransactionType.Single);
                Console.WriteLine("log--" + msg.Body.ToString());

            }

        }
    }
}
