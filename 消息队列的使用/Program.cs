using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 消息队列的使用
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisMQHelper redis = new RedisMQHelper(2);

            redis.ListRightPush("pop1", "head1__data");
            redis.ListRightPush("pop1", "head2__data");
            redis.ListRightPush("pop1", "head3__data");



            Console.WriteLine(redis.ListLeftPop("pop1"));

            Console.Read();
        }
    }
}
