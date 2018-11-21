using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 异步测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            var sss = await Task.Run(async () =>
              {

                  await Task.Delay(5000);

                  label1.Text = "这话isfdsfdsafsfdsfsd Fdsfds f 多少   多少速度多少三点式 十点半";


                  return "dsd";

              });



            label1.Text = "这话i";

        }
    }
}
