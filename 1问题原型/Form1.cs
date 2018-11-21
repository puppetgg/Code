using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1问题原型
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "\r\n等待服务器回复中.................\n";
            long length = await AccessWebAsync();

            richTextBox1.Text += String.Format("\n 回复的字节长度为:  {0}.\r\n", length);
            textBox1.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            richTextBox1.Text += String.Format("\n button1_Click  后方法，窗口暂停3秒（与下同时出现）.\r\n");

            Thread.Sleep(3000);
            richTextBox1.Text += String.Format("\n button1_Click  后方法，窗口恢复（与上同时出现）.\r\n");
        }
        private async Task<long> AccessWebAsync()
        {
            MemoryStream content = new MemoryStream();

            // 对MSDN发起一个Web请求
            HttpWebRequest webRequest = WebRequest.Create("http://msdn.microsoft.com/zh-cn/") as HttpWebRequest;
            if (webRequest != null)
            {
                richTextBox1.Text += String.Format("\n await前方法，窗口暂停3秒.\r\n");

                Thread.Sleep(3000);
                richTextBox1.Text += String.Format("\n await前方法，窗口恢复.\r\n");

                // 返回回复结果
                using (WebResponse response = await webRequest.GetResponseAsync())
                {
                    richTextBox1.Text += String.Format("\n await后方法，窗口暂停3秒（与下同时出现）.\r\n");

                    Thread.Sleep(3000);
                    richTextBox1.Text += String.Format("\n await后方法，窗口恢复（与上同时出现）.\r\n");
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        await responseStream.CopyToAsync(content);

                        richTextBox1.Text += String.Format("\n await2  后方法，窗口暂停3秒（与下同时出现）.\r\n");

                        Thread.Sleep(3000);
                        richTextBox1.Text += String.Format("\n await2  后方法，窗口恢复（与上同时出现）.\r\n");
                    }
                }
            }

            textBox2.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            return content.Length;
        }


    }
}
