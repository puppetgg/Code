using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace yield_Example
{
    /// <summary>
    /// 课程
    /// </summary>
    public class Course
    {
        public Course(String name)
        {
            this.name = name;
        }

        private String name = string.Empty;
        public String Name
        {
            get { return name; }
        }
    }

    public class CourseCollection : IEnumerable<String>
    {
        public CourseCollection()
        {
            arr_Course = new Course[] 
            {
                new Course("语文"),
                new Course("数学"),
                new Course("英语"),
                new Course("体育")
            };
        }

        private Course[] arr_Course;

        public Course this[int index]
        {
            get { return arr_Course[index]; }
        }

        // 注意：返回什么，泛型就为什么类型
        public IEnumerator<String> GetEnumerator()
        {
            for (int i = 0; i < arr_Course.Length; i++)
            {
                Course course = arr_Course[i];
                yield return "选修：" + course.Name;

                // 两个 yield return
                yield return Environment.NewLine;

                // yield return 只是做必要的返回值，之后又将控制权退回到迭代器，
                // 并继续执行后续代码
                if (String.Compare(course.Name, "英语") == 0)
                    yield break;

                List<string> strs=new List<string>{"435435","546546"};
                foreach (string s in strs)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public IEnumerable<String> GetEnumerable_ASC()
        {
            return this;
        }

        public IEnumerable<String> GetEnumerable_DESC()
        {
            for (int i = arr_Course.Length - 1; i >= 0; i--)
            {
                Course course = arr_Course[i];
                yield return "选修：" + course.Name;                
                yield return Environment.NewLine;
               
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
