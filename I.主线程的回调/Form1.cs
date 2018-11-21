using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I.主线程的回调
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "当前时间：" + DateTime.Now.ToString() + "当前线程id:" + Task.CurrentId + "---task创建之前" + "\r\n";
            MoveNext();


        }

        private void MoveNext()
        {
            Task<string> task = null;
            task = new Task<string>(() =>
            {
                Debug.WriteLine("当前时间：" + DateTime.Now.ToString() + "当前线程id:" + Task.CurrentId + "---task创建中的");
                Thread.Sleep(5000);
                Debug.WriteLine("当前时间：" + DateTime.Now.ToString() + "当前线程id:" + Task.CurrentId + "---task创建中的");


                return "当前时间：" + DateTime.Now.ToString() + "当前线程id:" + Task.CurrentId + "---task的结果";
            });

            var callback = new WaitCallback(t =>
            {
                var tt = (Task<string>)t;
                var ttAwaiter = tt.GetAwaiter();
                var val = ttAwaiter.GetResult();
                Console.WriteLine("From ThreadPool");
            });
            ThreadPool.QueueUserWorkItem(callback, task);

            //task.GetAwaiter().UnsafeOnCompleted(new Action(
            //      () =>
            //      richTextBox1.Text += "当前时间：" + DateTime.Now.ToString() + "当前线程id:" + Task.CurrentId + "---task的结果"));
            richTextBox1.Text += "当前时间：" + DateTime.Now.ToString() + "当前线程id:" + Task.CurrentId + "---task创建之后" + "\r\n";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
