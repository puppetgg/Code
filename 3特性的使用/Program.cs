using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3特性的使用
{
    class Program
    {
        static void Main(string[] args)
        {
            ReplaceBookMarks(new Model());

        }




        static string ReplaceBookMarks<T>(T model)
        {



            var props = typeof(T).GetProperties();


            //遍历属性
            foreach (var item in props)
            {
                var att = item.CustomAttributes;
            }

            return "OK";
        }

        public class Model
        {
            private string aa = "A";
            [DisplayName("DD")]
            public string Aa { get; set; }
            public string Bb { get; set; }
        }
    }
}
