using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace II.inbvork的检测
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var task = new Task<string>(() =>
            //{
            //    Task.Delay(2000).Wait();

            //    return "abssdd";
            //});

            //var task = Task.Run(() =>
            //  {
            //      Task.Delay(2000).Wait();

            //      return "abssdd";
            //  });

            textBox1.Invoke(new Func<string>(() =>
            {
                Task.Delay(2000).Wait();

                textBox1.Text = "123564";
                return "abssdd";
            }));
            //task.GetAwaiter().OnCompleted(new Action(() => textBox1.Text = task.Result));

        }
    }
}
