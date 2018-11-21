using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josn
{/// <summary>  
 /// 学生信息实体  
 /// </summary>  
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }
    }
    /// <summary>  
    /// 学生班级实体  
    /// </summary>  
    public class Class
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    internal class newtonsoftJosn
    {



        public static void DoJsonTest()
        {

            Student stu = new Student();
            stu.ID = 1001;
            stu.Name = "张三";
            stu.Class = new Class() { ID = 0121, Name = "CS0121" };

            //使用方法1  
            //实体序列化、反序列化  
            //结果：{"ID":1,"Name":"张三","Class":{"ID":121,"Name":"CS0121"}}  
            string json1 = JsonConvert.SerializeObject(stu);
            Console.WriteLine(json1);
            Student stu2 = JsonConvert.DeserializeObject<Student>(json1);
            Console.WriteLine(stu2.Name + "---" + stu2.Class.Name);

            //实体集合，序列化和反序列化  
            List<Student> stuList = new List<Student>() { stu, stu2 };
            string json2 = JsonConvert.SerializeObject(stuList);
            Console.WriteLine(json2);
            List<Student> stuList2 = JsonConvert.DeserializeObject<List<Student>>(json2);
            foreach (var item in stuList2)
            {
                Console.WriteLine(item.Name + "----" + item.Class.Name);
            }

            //匿名对象的解析,  
            //匿名独享的类型  obj.GetType().Name： "<>f__AnonymousType0`2"  
            var obj = new { ID = 2, Name = "李四" };
            string json3 = JsonConvert.SerializeObject(obj);
            Console.WriteLine(json3);
            object obj2 = JsonConvert.DeserializeAnonymousType(json3, obj);
            Console.WriteLine(obj2.GetType().GetProperty("ID").GetValue(obj2));
            object obj3 = JsonConvert.DeserializeAnonymousType(json3, new { ID = default(int), Name = default(string) });
            Console.WriteLine(obj3.GetType().GetProperty("ID").GetValue(obj3));
            //匿名对象解析，可以传入现有类型，进行转换  
            Student stu3 = new Student();
            stu3 = JsonConvert.DeserializeAnonymousType(json3, new Student());
            Console.WriteLine(stu3.Name);
        }
    }
}