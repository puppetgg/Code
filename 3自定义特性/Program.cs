using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3自定义特性
{
    class Oyster : Attribute                         // 必需以System.Attribute类为基类  
    {
        public string Kind { get; set; }
        public uint Age { get; set; }

        // 值为null的string是危险的，所以必需在构造函数中赋值  
        public Oyster(string arg)         // 定位参数  
        {
            Kind = arg;
        }
    }
    [Oyster("Thorny ", Age = 3)]    // 3年的多刺牡蛎附着在轮船（这是一个类）上。注意：对属性的赋值是在圆括号里完成的！  
    class Ship
    {
        [Oyster("Saddle")]          // 0年的鞍形牡蛎附着在船舵（这是一个数据成员）上，Age使用的是默认值，构造函数的参数必需完整  
        public string Rudder;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ... 使用反射来读取Attribute  
        }
    }
}
