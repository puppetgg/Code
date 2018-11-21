using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5Redis消息队列.code
{
    public class MessageQueue
    {
        static System.Timers.Timer timer = new System.Timers.Timer(5000);
        public static ChatModels CurrentChatModels = new ChatModels();
        static MessageQueue()
        {
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
        private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var redisClient = new RedisHelper(2);
            // 消息出列
            CurrentChatModels = redisClient.ListLeftPop<ChatModels>("MessageQuene");
        }
    }
}