using System;
using System.Threading;

namespace _3Abort和Interrupt
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(TestMethod);
            thread1.Start();
            Thread.Sleep(100);

            thread1.Interrupt();
            Thread.Sleep(3000);
            Console.WriteLine("after finnally block, the Thread1 status is:{0}", thread1.ThreadState);
            Console.Read();
        }
        private static void TestMethod()
        {

            for (int i = 0; i < 4; i++)
            {
                try
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Thread is Running");
                }
                catch (Exception e)
                {
                    if (e != null)
                    {
                        Console.WriteLine("Exception {0} throw ", e.GetType().Name);
                    }
                }
                finally
                {
                    Console.WriteLine("Current Thread status is:{0} ", Thread.CurrentThread.ThreadState);
                }
            }
        }
    }
}
