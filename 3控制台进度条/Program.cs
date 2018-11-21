using System;
using System.Threading;

namespace _3控制台进度条
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean isBreak = false;
            ConsoleColor colorBack = Console.BackgroundColor;
            ConsoleColor colorFore = Console.ForegroundColor;
            //(0,0)(Left,Top) 第一行
            Console.WriteLine("***********TE Mason*************");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < Console.WindowWidth - 3; i++)
            {
                //(0,1) 第二行
                Console.Write(" ");
            }
            //(0,1) 第二行
            Console.WriteLine(" ");
            Console.BackgroundColor = colorBack;
            //'(0,2) 第三行
            Console.WriteLine("0%");
            // '(0,3) 第四行
            Console.WriteLine("<按【Enter】键停止>");

            for (int i = 0; i <= 100; i++)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    isBreak = true;
                    break;
                }
                Console.BackgroundColor = ConsoleColor.Yellow;
                // '/返回完整的商，包括余数，SetCursorPosition会自动四舍五入
                Console.SetCursorPosition(i * (Console.WindowWidth - 2) / 100, 1);
                // 'MsgBox(i * (Console.WindowWidth - 2) / 100);
                // 'MsgBox(Console.CursorLeft);
                //'MsgBox(Console.CursorSize);
                Console.Write(" ");
                Console.BackgroundColor = colorBack;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, 2);
                Console.Write("{0}%", i);
                Console.ForegroundColor = colorFore;
                Thread.Sleep(500);
            }

            Console.SetCursorPosition(0, 3);
            Console.Write(isBreak ? "停止!!!" : "完成");
            Console.WriteLine("                           ");
            Console.ReadKey();
            Console.ReadKey(true);
        }
    }
}
