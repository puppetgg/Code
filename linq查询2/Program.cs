using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq查询2
{
    class Program
    {
        static void Main(string[] args)
        {


            //  1、组连接组连接是与分组查询是一样的。即根据分组得到结果。
            //如下例,根据Subject科目进行分组得到结果。使用组连接的查询语句如下：
            var q = from sub in SampleData.Subjects
                    join book in SampleData.Books on sub equals book.Subject into AllBooks
                    select new { Subject = sub.Name, Books = AllBooks };


            var qq = SampleData.Subjects.GroupJoin(SampleData.Books, x => x, y => y.Subject, (a, g) => new { a.Name, g });

            //分组查询
            var gq = from book in SampleData.Books
                     group book by book.Subject into g
                     select new { Subject = g.Key.Name, Books = g };

            var lgq1 = SampleData.Books.GroupBy(x => x.Subject).ToList();
            // var lgq2 = SampleData.Books.GroupBy(x => x.Subject, EqualityComparer<Book>.Default).ToList();
            var lgq = SampleData.Books.GroupBy(x => x.Subject, (k, g) => new { k.Name, g }).ToList();
            Console.Read();
        }



        public class Compare<T> : IEqualityComparer
        {
            public new bool Equals(object x, object y)
            {
                throw new NotImplementedException();
            }

            public int GetHashCode(object obj)
            {
                throw new NotImplementedException();
            }
        }
    }



    public class Student
    {
        public string Name { get; set; }
    }
    public class Subject
    {
        public string Name { get; set; }
    }
    public class Book
    {
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public Subject Subject { get; set; }
    }
    static public class SampleData
    {
        static public Student[] Students =
        {
          new Student {Name="Richard"},
          new Student {Name="Joe"},
          new Student {Name="Tom"}
        };

        static public Subject[] Subjects =
        {
          new Subject {Name="语文"},
          new Subject {Name="数学"},
          new Subject {Name="英语"},
            new Subject {Name="业余"}
        };
        static public Book[] Books =
        {
          new Book {
            Title="人教版语文",
            PublicationDate=new DateTime(2004, 11, 10),
            Subject=Subjects[0]
          },
          new Book {
            Title="苏教版语文",
            PublicationDate=new DateTime(2007, 9, 2),
            Subject=Subjects[0]
          },
          new Book {
            Title="人教版数学",
            PublicationDate=new DateTime(2007, 4, 1),
            Subject=Subjects[1]
          },
          new Book {
            Title="人教版英语",
            PublicationDate=new DateTime(2006, 5, 5),
            Subject=Subjects[2]
          },
          new Book {
            Title="苏教版数学",
            PublicationDate=new DateTime(1973, 2, 18),
            Subject=Subjects[1]
          }
        };
    }
}
