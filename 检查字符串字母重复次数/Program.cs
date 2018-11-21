using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 检查字符串字母重复次数
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "fskdjahfufyhiudshfbndsnmvckjdsjdeelifjdsliafhyfuhdsakjhgfdsakjhgfhsgahfgbagsfhdsaghf";

            char[] charArr = str.ToArray();
            Console.WriteLine("----------------------Dictionary-------------------------------");
            //定义数组存储字母和次数
            Dictionary<char, int> dicCharNum = new Dictionary<char, int>();

            foreach (var item in charArr)
            {
                if (dicCharNum.ContainsKey(item))
                {
                    dicCharNum[item]++;
                }
                else
                {
                    dicCharNum.Add(item, 1);
                }
            }
            Console.WriteLine("----------------------Aggregate-------------------------------");
            var vv = charArr.Aggregate(new Dictionary<char, int>(), (dic, sorce) =>
                     {
                         if (dic.ContainsKey(sorce))
                             dic[sorce]++;
                         else
                             dic.Add(sorce, 1);
                         return dic;
                     });


            Console.WriteLine("----------------------linqGroupby-------------------------------");
            var vvv = from c in charArr
                      group charArr by c into g
                      select new { g.Key, count = g.Count() };

            Console.WriteLine("----------------------Groupby-------------------------------");
            var vvvv = charArr.GroupBy(c => c).Select(g => new { g.Key, count = g.Count() });

            Console.Read();
        }
    }
}
