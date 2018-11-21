using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1EAP下载
{
    class Program
    {
        static void Main(string[] args)
        {

            MyFormEAP eap = new MyFormEAP();
            eap.ShowDialog();

            MyFormAPM apm = new MyFormAPM();
            apm.ShowDialog();
        }
    }
}
