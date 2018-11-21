using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMQMainFrm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageQueue myQueue = null;
            if (!MessageQueue.Exists(@".\private$\myQueue"))
            {
                myQueue = MessageQueue.Create(@".\private$\myQueue");
            }
            myQueue = new MessageQueue(@".\private$\myQueue");
            System.Messaging.Message msg = new System.Messaging.Message();
            msg.Label = textBox1.Text.Trim();
            msg.Body = textBox3.Text.Trim();
            if (checkBox1.Checked)
            {
                msg.Priority = MessagePriority.Highest;

            }
            else
            {
                msg.Priority = MessagePriority.Normal;
            }


            myQueue.Send(msg);
            MessageBox.Show("发送成功！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageQueue myQueue = new MessageQueue(@".\private$\myQueue");
            myQueue.MessageReadPropertyFilter.Priority = true;
            DataTable msgtab = new DataTable();


}
    }
}
