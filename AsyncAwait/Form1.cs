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

namespace AsyncAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            long length = await AccessWebAsync();

            //OtherWork();

            richTextBox1.Text += string.Format("\n 回复的字节长度为:  {0}.\r\n", length);

            textBox1.Text = Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString().ToString();

        }

        private async Task<long> AccessWebAsync()
        {
            MemoryStream content = new MemoryStream();

            // 对MSDN发起一个Web请求
            HttpWebRequest webRequest = WebRequest.Create("http://msdn.microsoft.com/zh-cn/") as HttpWebRequest;
            if (webRequest != null)
            {
                // 返回回复结果
                using (WebResponse response = await webRequest.GetResponseAsync())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        await responseStream.CopyToAsync(content);
                    }
                }
            }

            textBox2.Text = Thread.CurrentThread.ManagedThreadId + "--" + DateTime.Now.ToString().ToString();
            return content.Length;
        }

        private void OtherWork()
        {
            richTextBox1.Text += DateTime.Now.ToString();
            Task.Run<string>(() =>
            {
                Thread.Sleep(5000);
                return "\r\n等待服务器回复中.................\n";

            }).GetAwaiter().OnCompleted(new Action(() => richTextBox1.Text = "123564"));

        }
    }
}
