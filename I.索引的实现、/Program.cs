using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I.索引的实现_
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }



    public class MyClass
    {
        //private MyClass[] myClasses

        public MyClass(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public class MyClassCollection : IEnumerable<MyClass>
    {
        private MyClass[] myClasses;

        public MyClassCollection()
        {
            myClasses = new MyClass[]
            {
                new MyClass("语文"),
                new MyClass("数学"),
                new MyClass("英语"),
                new MyClass("体育")
            };
        }

        public MyClass this[int index] => myClasses[index];




        public IEnumerator<MyClass> GetEnumerator()
        {
            //return new CourseEnumerator(this);
            var ss = myClasses[1];
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
