using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LogClient
{
    class Program
    {
        static void Main(string[] args)
        {


            MessageQueue MSMQ = null;
            if (!MessageQueue.Exists(@".\private$\log"))
                MSMQ = MessageQueue.Create(@".\private$\log", true);
            MSMQ = new MessageQueue(@".\private$\log");

            MessageQueueTransaction transaction = new MessageQueueTransaction();
            while (true)
            {
                Console.WriteLine("输入测试日志消息");
                var txt = Console.ReadLine();
                // 如果消息队列采用了事务，则开始事务  
                if (MSMQ.Transactional)
                    transaction.Begin();
                MSMQ.Send(txt);
                // 如果消息队列采用了事务，则开始事务  
                if (MSMQ.Transactional)
                    transaction.Commit();
                Console.WriteLine("发送完毕");

                 

            }

        }
    }
}
