using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 重写的检测
{
    class Program
    {
        static void Main(string[] args)
        {

            Return r = new Return();
            r.Name = "抓鬼";
            r.MyProperty = new List<string>() { "fdsaf", "fsdfs" };


            var ss = r.ToString();

            Console.WriteLine(ss);
            Console.Read();
        }
    }


    public class Return
    {
        public string Name { get; set; }

        public object MyProperty { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


    }


}
