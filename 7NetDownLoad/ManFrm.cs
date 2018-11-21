using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7NetDownLoad
{
    public partial class ManFrm : Form
    {
        public ManFrm()
        {
            InitializeComponent();
        }

        private void ManFrm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            IDataObject iData = Clipboard.GetDataObject();
            //确定数据的格式是否是你想要的
            if (iData.GetDataPresent(DataFormats.Text))
            {
                //如果是，那就把它粘贴到textbox2里
                Program.url = (string)iData.GetData(DataFormats.Text);
            }

            Close();
            Dispose();
        }
    }
}
