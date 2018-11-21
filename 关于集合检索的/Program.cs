using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于集合检索的
{
    class Program
    {
        static void Main(string[] args)
        {






            List<AAA> dLst = new List<AAA>() {
                new AAA() { Id=1,Name="aaa",Fart="111"},
                new AAA() { Id=1,Name="bbb",Fart="aaa"},
                new AAA() { Id=1,Name="ccc",Fart="333"},
                new AAA() { Id=1,Name="ddd",Fart="444"},
                new AAA() { Id=12,Name="eee",Fart="aaa"},
                new AAA() { Id=15,Name="aaa",Fart="666"},
                new AAA() { Id=115,Name=null,Fart="666"},

            };
            //---------检测查字段为空询条件
            var ss = dLst.Where(x => (x?.Name.Contains("fff") ?? false) || x.Id == 115).ToList();
            //---------检测统计当前集合数量赋值给一个变量后 改变集合数量后 前面的变量会不会变
            int firstCount = dLst.Count;
            dLst = dLst.Take(2).ToList();
            Console.WriteLine(firstCount);



            //---------查询条件加括号的区别
            var date = dLst.Where(x => x.Id == 1 && x.Name == "aaa" || x.Fart == "aaa");
            var date2 = dLst.Where(x => x.Id == 1 && (x.Name.Contains("a") || x.Fart.Contains("a")));

            Console.Read();


        }
    }



    public class AAA
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Fart { get; set; }


    }
}
