using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace III.Await的检测
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "检测await是谁在等待" + "\r\n";
            richTextBox1.Text += "MainStart====" + DateTime.Now.ToString() + "================@" + Thread.CurrentThread.ManagedThreadId + "\r\n";
            SimpleMethod();
            richTextBox1.Text += "MainEnd====" + DateTime.Now.ToString() + "================@" + Thread.CurrentThread.ManagedThreadId + "\r\n";


        }
        public async void SimpleMethod()
        {
            richTextBox1.Text += "SimpleMethod()-s-@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString() + "\r\n";
            string res = await GetHere();
            richTextBox1.Text += Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString() + res + "\r\n";
            richTextBox1.Text += "主线程即将卡2秒-e-@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString() + "\r\n";

            Thread.Sleep(2000);
            richTextBox1.Text += "SimpleMethod()-e-@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString() + "\r\n";

        }

        async Task<string> GetHere()
        {
            richTextBox1.Text += "GetHere()-s-@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString() + "\r\n";
            var task = await Task.Run(() =>
            {
                // richTextBox1.Text += "GetHere()-news-@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString();
                Thread.Sleep(3000);
                return "HERE返回值线程@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString();
            });
            richTextBox1.Text += "GetHere()-end-@" + Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString() + "\r\n";
            return task;

        }
    }
}
