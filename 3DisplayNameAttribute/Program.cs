using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _3DisplayNameAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(MyClass);
            var props = type.GetProperties();
            var all = type.GetCustomAttributes(typeof(DisplayNameAttribute), false);
            foreach (var item in props)
            {
                var d = item.GetCustomAttributes(typeof(DisplayNameAttribute), false);
            }
            //type.GetProperty("Mm").PropertyType.get
            //.GetCustomAttributes(typeof(DisplayNameAttribute), false)
            //.DisplayName.Equals(i.Name.ToUpper());
            var iSExit = props.FirstOrDefault(_ =>
            {
                //  value = _.GetValue(model);
                //_.Name.ToUpper().Contains(i.Name.ToUpper());
                var val = ((DisplayNameAttribute)_.GetCustomAttribute(typeof(DisplayNameAttribute), false));
                return false;
            });
        }
    }




    public class MyClass
    {
        [DisplayName()]
        public string Cc { get; set; } = "45";
        [DisplayName("nn")]
        public string Mm { get; set; } = "12";
    }
}
