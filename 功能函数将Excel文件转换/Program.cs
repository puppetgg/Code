using BaseDal;
using BaseModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 功能函数将Excel文件转换
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = new Manage_TypeDataLogic().FindByLambda().Count;
            Console.WriteLine("ok" + count);
            Console.Read();
        }
    }
}
