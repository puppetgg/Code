using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拓展方法的使用
{
    public class String类的静态拓展
    {

        public static void ToSBCTT()
        {
            string strss = "ｇｆｆｓｄｆｓ，．．／　gfdsg fsdf ";
            Console.WriteLine("转换之前的字符:");
            Console.WriteLine(strss);
            //strss = string.Empty;
            var resSbc = strss.ToSBC();
            Console.WriteLine("转换全角之后的字符:");
            Console.WriteLine(resSbc);
            Console.WriteLine("转换半角之后的字符:");
            var resDbc = strss.ToDBC();
            Console.WriteLine(resDbc);

        }







    }


    public static class String
    {
        //拓展方法的三要素  静态类，静态方法，this关键字；

        //切换半角
        public static string ToDBC(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("ss");
            }

            var strArr = str.ToCharArray();
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i] == 12288)
                {
                    strArr[i] = (char)32;
                    continue;
                }
                if (strArr[i] > 127)
                {
                    strArr[i] -= (char)65248;
                }

            }


            return new string(strArr);
        }

        //切换全角
        public static string ToSBC(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException($" {nameof(str)} is null or empty");
            }
            //转换成字节数组
            var charArr = str.ToList();


            //foreach操作期间，其集合处于锁定状态，无法修改其值（为什么会忘记？？？）
            charArr.ForEach(x =>
            {
                if (x == 32)//半角空格
                {
                    x = (char)12288;

                }
                else if (x < 127)
                {
                    x = (char)(x + 65248);
                }
            });
            for (int i = 0; i < charArr.Count; i++)
            {
                if (charArr[i] == 32)
                {
                    charArr[i] = (char)12288;
                    continue;
                }
                if (charArr[i] < 127)
                {
                    charArr[i] += (char)65248;
                }
            }
            return new string(charArr.ToArray());
        }



    }

}
