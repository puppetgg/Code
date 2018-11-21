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

namespace 同步原型
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            long length = AccessWeb();
            button1.Enabled = true;

            OtherWork();
            richTextBox1.Text += String.Format("\n 回复的字节长度为:  {0}.\r\n", length);
            textBox1.Text = Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString().ToString();
        }

        private long AccessWeb()
        {
            MemoryStream ms = new MemoryStream();
            HttpWebRequest webRequest = WebRequest.CreateHttp("http://msdn.microsoft.com/zh-cn/");
            if (webRequest != null)
            {
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        responseStream.CopyTo(ms);
                    }
                }
            }
            textBox2.Text = Thread.CurrentThread.ManagedThreadId+"--"+DateTime.Now.ToString().ToString();
            return ms.Length;
        }

        private void OtherWork()
        {
            for (int i = 0; i < 5; i++)
            {
                richTextBox1.Text += "----OtherWork----";
                Thread.Sleep(1000);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
