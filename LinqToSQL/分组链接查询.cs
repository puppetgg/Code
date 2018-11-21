using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    public class 分组链接查询
    {
        public static void 分组查询()
        {
            List<CustomerInfo> clist = new List<CustomerInfo>
            {
               new CustomerInfo{ Name="欧阳晓晓", Age=35, Tel ="1330708****"},
               new CustomerInfo{ Name="上官飘飘", Age=17, Tel ="1592842****"},
               new CustomerInfo{ Name="郭靖", Age=17, Tel ="1330708****"},
               new CustomerInfo{ Name="黄蓉", Age=17, Tel ="1300524****"}
            };

            List<CustomerTitle> titleList = new List<CustomerTitle>
            {
               new CustomerTitle{ Name="欧阳晓晓", Title="歌手"},
               new CustomerTitle{ Name="郭靖", Title="大侠"},
               new CustomerTitle{ Name="郭靖", Title="洪七公徒弟"},
               new CustomerTitle{ Name="黄蓉", Title="才女"},
               new CustomerTitle{ Name="黄蓉", Title="丐帮帮主"}
            };


            //根据姓名进行分组联接
            Console.WriteLine("\n根据姓名进行分组联接");
            var query2 = from customer in clist
                         join title in titleList
                         on customer.Name equals title.Name into tgroup
                         select new { Name = customer.Name, Age = customer.Age, Tel = customer.Tel, Titles = tgroup.Count() };
            foreach (var g in query2)
            {
                Console.WriteLine($"{ g.Name}--------------{g.Titles}");
                //foreach (var g2 in g.Titles)
                //{
                //    Console.WriteLine("   {0}", g2.Title);
                //}
            }
        }
    }
    internal class CustomerTitle
    {
        public string Name { get; set; }
        public string Title { get; set; }

    }

    internal class CustomerInfo
    {
        public string Name { get; set; }
        public string Tel { get; set; }
        public int Age { get; set; }
    }
}
