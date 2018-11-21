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

namespace IV.Invork的使用检测
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            var task = Task.Run<string>(() =>
            {
                Thread.Sleep(5000);

                return "123564879" + "当前线程好号：" + Thread.CurrentThread.ManagedThreadId;
            });

            richTextBox1.Text = "task创建后" + task.Status + "当前线程好号：" + Thread.CurrentThread.ManagedThreadId + "\r\n";
            testc(task);
        }

        private void testc(Task<string> task)
        {        task.Wait();
            Task.Run(() =>
            {
              
        
                task.GetAwaiter().UnsafeOnCompleted(() =>
                {
                    richTextBox1.Text += "结果" + task.Result + task.Status + "当前线程好号：" + Thread.CurrentThread.ManagedThreadId + "\r\n";



                });




            });
        }
    }
}
