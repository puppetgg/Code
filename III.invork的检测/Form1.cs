using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace III.invork的检测
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() =>
              {
                  Task.Delay(2000).Wait();

                  return "abssdd";
              });


            task.GetAwaiter().OnCompleted(new Action(() => textBox1.Text = task.Result));
        }
    }
}
