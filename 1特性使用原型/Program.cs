using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1特性使用原型
{
    class Program
    {
        static void Main(string[] args)
        {
            GetName();
            Console.Read();
        }


        private static string GetName()
        {
            var type = typeof(CustomAttributes);

            var attribute = type.GetCustomAttributes(typeof(NameAttribute), false).FirstOrDefault();

            //var ass = type.GetProperty("Address").Attributes;
            var attrs = type.GetProperty("Address").GetCustomAttributes(typeof(NameAttribute), false);

            var attributes = type.GetCustomAttributes(typeof(NameAttribute), false).FirstOrDefault();

            if (attribute == null)
            {
                return null;
            }

            return ((NameAttribute)attribute).Name;
        }

    }



    [Name("dept")]
    public class CustomAttributes
    {
        [Name("Deptment Name")]
        public string Name { get; set; }

        //[Name("Deptment Address")]
        public string Address { get; set; }
    }
    [AttributeUsage(AttributeTargets.All)]
    public sealed class NameAttribute : Attribute
    {

        public string Name { get; }

        public NameAttribute(string name)
        {
            Name = name;
        }
    }
}
