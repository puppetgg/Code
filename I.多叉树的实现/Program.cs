using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I.多叉树的实现
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch watch = new Stopwatch();

            /*创建多叉树并存入大量数据并监视插入用时*/
            MulTree tree = new MulTree();
            watch.Start();
            for (long i = 3013101000; i < 3023101171; i++)
                tree.Insert(i + "");
            watch.Stop();
            Console.WriteLine("添加用时：" + watch.Elapsed.TotalMilliseconds + "ms");

            /*查询，并记录查询用时*/
            watch = new Stopwatch();
            watch.Start();
            Node result = tree.SearchSingleNode("3013203182");
            watch.Stop();

            Console.WriteLine("查询用时：" + watch.Elapsed.TotalMilliseconds + "ms");
            Console.WriteLine("查询到数据学号为：" + result.Data);
            Console.ReadKey();

        }
    }
    /*多叉树类*/
    class MulTree
    {
        public int Deepth = 10;/*树的深度，存学号就是学号的长度*/
        public Node Root { get; set; }/*根节点*/
        public MulTree()
        {
            Root = new Node();
        }
        /*插入*/
        public bool Insert(string str)
        {
            /*先检测插入字符串是否有效*/
            int[] array = new int[Deepth];
            bool flag = DetectionString(str, ref array);
            if (!flag)
            {
                return false;
            }
            /*开始插入，将字符串写入最后节点的data里面*/
            Node temp = Root;
            for (int i = 0; i < array.Length; i++)
            {
                if (temp == null) temp = new Node();
                if (temp.Childs[array[i]] == null)
                    temp.Childs[array[i]] = new Node();
                temp = temp.Childs[array[i]];
            }
            temp.Data = str;

            return true;
        }
        /*检测字符串是否有效*/
        public bool DetectionString(string str, ref int[] array)
        {
            if (str.Length != Deepth) return false;
            char[] strArray = str.ToArray<char>();
            int[] intArray = new int[Deepth];
            for (int i = 0; i < strArray.Length; i++)
            {
                bool flag = int.TryParse(strArray[i] + "", out intArray[i]);
                if (!flag) return false;
            }
            array = intArray;
            return true;
        }
        /*查找，返回查找到的节点*/
        public Node SearchSingleNode(string str)
        {
            /*检测字符串是否是有效的学号*/
            int[] array = new int[Deepth];
            bool flag = DetectionString(str, ref array);
            if (!flag)
            {
                return null;
            }

            /*开始查询*/
            Node result = Root;
            for (int i = 0; i < array.Length; i++)
            {
                if (result.Childs[array[i]] == null)
                    return null;
                result = result.Childs[array[i]];
            }
            return result;
        }
    }
    /*节点类*/
    class Node
    {
        public Node[] Childs;
        public string Data { get; set; }
        public Node()
        {
            Childs = new Node[10];
            for (int i = 0; i < Childs.Length; i++)
                Childs[i] = null;
        }
    }
}