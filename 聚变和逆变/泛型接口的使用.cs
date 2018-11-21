using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聚变和逆变
{
    public interface INotification
    {
        string Message { get; }
    }

    public abstract class Notification : INotification
    {
        public abstract string Message { get; }
    }
    public class MailNotification : Notification
    {
        public override string Message
        {
            get
            {
                return "你有一封新邮件！";
            }
        }
    }

    //-----------------------发布通知的--------------------------------
    public interface INotifier<in TNotification> where TNotification : INotification
    {
        void Notify(TNotification notification);


    }

    public class Notifier<TNotification> : INotifier<TNotification> where TNotification : INotification
    {
        public void Notify(TNotification notification)
        {
            Console.WriteLine(notification.Message);
        }
    }


    public class 泛型接口的使用
    {

        public static void TT()
        {
            INotifier<INotification> notifier = new Notifier<INotification>();

            //notifier.Notify(new MailNotification());

            INotifier<MailNotification> mailNotifier = notifier;
            mailNotifier.Notify(new MailNotification());
            Console.ReadKey();


        }
    }
}
