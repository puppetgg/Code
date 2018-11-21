using System;
using System.IO;
using System.IO.Compression;

namespace _2进度条
{


    /// <summary>
    /// 进度条类型
    /// </summary>
    public enum ProgressBarType
    {
        /// <summary>
        /// 字符
        /// </summary>
        Character,
        /// <summary>
        /// 彩色
        /// </summary>
        Multicolor
    }

    public class ProgressBar
    {

        /// <summary>
        /// 光标的列位置。将从 0 开始从左到右对列进行编号。
        /// </summary>
        public int Left { get; set; }
        /// <summary>
        /// 光标的行位置。从上到下，从 0 开始为行编号。
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// 进度条宽度。
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 进度条当前值。
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// 进度条类型
        /// </summary>
        public ProgressBarType ProgressBarType { get; set; }


        private ConsoleColor colorBack;
        private ConsoleColor colorFore;


        public ProgressBar() : this(Console.CursorLeft, Console.CursorTop)
        {

        }

        public ProgressBar(int left, int top, int width = 50, ProgressBarType ProgressBarType = ProgressBarType.Multicolor)
        {
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.ProgressBarType = ProgressBarType;

            // 清空显示区域；
            Console.SetCursorPosition(Left, Top);
            for (int i = left; ++i < Console.WindowWidth;) { Console.Write(" "); }

            if (this.ProgressBarType == ProgressBarType.Multicolor)
            {
                // 绘制进度条背景； 
                colorBack = Console.BackgroundColor;
                Console.SetCursorPosition(Left, Top);
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                for (int i = 0; ++i <= width;) { Console.Write(" "); }
                Console.BackgroundColor = colorBack;
            }
            else
            {
                // 绘制进度条背景；    
                Console.SetCursorPosition(left, top);
                Console.Write("[");
                Console.SetCursorPosition(left + width - 1, top);
                Console.Write("]");
            }
        }

        public int Dispaly(int value)
        {
            return Dispaly(value, null);
        }

        public int Dispaly(int value, string msg)
        {
            if (this.Value != value)
            {
                this.Value = value;

                if (this.ProgressBarType == ProgressBarType.Multicolor)
                {
                    // 保存背景色与前景色；
                    colorBack = Console.BackgroundColor;
                    colorFore = Console.ForegroundColor;
                    // 绘制进度条进度                
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(this.Left, this.Top);
                    Console.Write(new string(' ', (int)Math.Round(this.Value / (100.0 / this.Width))));
                    Console.BackgroundColor = colorBack;

                    // 更新进度百分比,原理同上.                 
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(this.Left + this.Width + 1, this.Top);
                    if (string.IsNullOrWhiteSpace(msg)) { Console.Write("{0}%", this.Value); } else { Console.Write(msg); }
                    Console.ForegroundColor = colorFore;
                }
                else
                {
                    // 绘制进度条进度      
                    Console.SetCursorPosition(this.Left + 1, this.Top);
                    Console.Write(new string('*', (int)Math.Round(this.Value / (100.0 / (this.Width - 2)))));
                    // 显示百分比   
                    Console.SetCursorPosition(this.Left + this.Width + 1, this.Top);
                    if (string.IsNullOrWhiteSpace(msg)) { Console.Write("{0}%", this.Value); } else { Console.Write(msg); }
                }
            }
            return value;
        }

    }


    /// <summary>
    /// GZip文件操作类；
    /// </summary>
    public class GZipHelper
    {
        /// <summary>
        /// 压缩文件；
        /// </summary>
        /// <param name="inputFileName">输入文件</param>
        /// <param name="dispalyProgress">进度条显示函数</param>
        public static void Compress(string inputFileName, Func<int, int> dispalyProgress = null)
        {
            using (FileStream inputFileStream = File.Open(inputFileName, FileMode.Open))
            {
                using (FileStream outputFileStream = new FileStream(Path.Combine(Path.GetDirectoryName(inputFileName), string.Format("{0}.7z", Path.GetFileNameWithoutExtension(inputFileName))), FileMode.Create, FileAccess.Write))
                {
                    using (GZipStream gzipStream = new GZipStream(outputFileStream, CompressionMode.Compress))
                    {
                        byte[] buffer = new byte[1024];
                        int count = 0;
                        while ((count = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            gzipStream.Write(buffer, 0, count);
                            if (dispalyProgress != null) { dispalyProgress(Convert.ToInt32((inputFileStream.Position / (inputFileStream.Length * 1.0)) * 100)); }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="inputFileName">输入文件</param>
        /// <param name="outFileName">输出文件</param>
        /// <param name="dispalyProgress">进度条显示函数</param>
        public static void Decompress(string inputFileName, string outFileName, Func<int, int> dispalyProgress = null)
        {
            using (FileStream inputFileStream = File.Open(inputFileName, FileMode.Open))
            {
                using (FileStream outputFileStream = new FileStream(outFileName, FileMode.Create, FileAccess.Write))
                {
                    using (GZipStream decompressionStream = new GZipStream(inputFileStream, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[1024];
                        int count = 0;
                        while ((count = decompressionStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            outputFileStream.Write(buffer, 0, count);
                            dispalyProgress?.Invoke(Convert.ToInt32((inputFileStream.Position / (inputFileStream.Length * 1.0)) * 100));
                        }
                    }
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("正在压缩文件...");
                ProgressBar progressBar = new ProgressBar(Console.CursorLeft, Console.CursorTop, 50, ProgressBarType.Character);
                GZipHelper.Compress(@"C:\3\Corporate Manuals.docx", progressBar.Dispaly);
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("正在解压文件...");
                progressBar = new ProgressBar(Console.CursorLeft, Console.CursorTop, 50, ProgressBarType.Multicolor);
                GZipHelper.Decompress(@"C:\3\code记录.rar", @"C:\3\code记录", progressBar.Dispaly);
                Console.WriteLine();

            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                Console.Beep();
                Console.WriteLine("进度条宽度超出可显示区域！");
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("操作完成，按任意键退出！");
                Console.ReadKey(true);
            }
        }
    }

}