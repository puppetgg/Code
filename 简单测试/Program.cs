using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单测试
{
    class Program
    {
        // unsafe 关键字允许在下列
        // 方法中使用指针：
        static unsafe void Copy(byte[] src, int srcIndex, byte[] dst, int dstIndex, int count)
        {


            if (src == null || srcIndex < 0 ||
            dst == null || dstIndex < 0 || count < 0)
            {
                throw new ArgumentException();
            }
            int srcLen = src.Length;
            int dstLen = dst.Length;
            if (srcLen - srcIndex < count || dstLen - dstIndex < count)
            {
                throw new ArgumentException();
            }
            // 以下固定语句固定
            // src 对象和 dst 对象在内存中的位置，以使这两个对象
            // 不会被垃圾回收移动。
            fixed (byte* pSrc = src, pDst = dst)
            {
                byte* ps = pSrc;
                byte* pd = pDst;
                // 以 4 个字节的块为单位循环计数，一次复制
                // 一个整数（4 个字节）：
                for (int n = 0; n < count / 4; n++)
                {
                    *((int*)pd) = *((int*)ps);
                    pd += 4;
                    ps += 4;
                }
                // 移动未以 4 个字节的块移动的所有字节，
                // 从而完成复制：
                for (int n = 0; n < count % 4; n++)
                {
                    *pd = *ps;
                    pd++;
                    ps++;
                }
            }
        }
        static unsafe void Main(string[] args)
        {


            int ii = 123;
            int* pointer = &ii;
            Console.WriteLine("ii is:" + ii);
            Console.WriteLine("the pointer points to:" + *pointer);

            byte[] a = new byte[100];
            byte[] b = new byte[100];
            for (int i = 0; i < 100; ++i)
                a[i] = (byte)i;
            Copy(a, 0, b, 0, 100);
            Console.WriteLine("The first 10 elements are:");
            for (int i = 0; i < 10; ++i)
                Console.Write(b[i] + " ");
            Console.WriteLine("\n");
            Console.Read();
        }
    }
}
