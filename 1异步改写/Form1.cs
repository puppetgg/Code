using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

using System.Windows.Forms;

namespace _1异步改写
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button1_Click()====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
            this.richTextBox1.Clear();
            button1.Enabled = false;
            Func<string> caller = new Func<string>(TestMethod);
            Console.WriteLine("button1_Click()创建caller后====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            IAsyncResult result = caller.BeginInvoke(GetResult, caller);
            Console.WriteLine("button1_Click()开始BeginInvoke后====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

        }

        private void GetResult(IAsyncResult ar)
        {
            Console.WriteLine("1GetResult()====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            Func<string> caller = ar.AsyncState as Func<string>;
            var content = caller.EndInvoke(ar);
            Invoke(new Action<string>(_ =>
            {
                richTextBox1.Text += _;
                Console.WriteLine("Invoke()====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

            }), content);
            Console.WriteLine("2GetResult()====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);

        }

        // 同步方法
        private string TestMethod()
        {
            // 模拟做一些耗时的操作
            // 实际项目中可能是读取一个大文件或者从远程服务器中获取数据等。
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("TestMethod()====" + DateTime.Now.ToString() + "================" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
            }

            return "点击我按钮事件完成";
        }
    }
}
