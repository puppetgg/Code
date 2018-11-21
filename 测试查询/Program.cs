using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试查询
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------同类型的集合-------------------------------------------------------
            // Intersect 交集，Except 差集，Union 并集
            int[] oldArray = { 1, 2, 3, 4, 5 };
            int[] newArray = { 2, 4, 5, 7, 8, 9 };
            var jiaoJi = oldArray.Intersect(newArray).ToList();//2,4,5
            var oldChaJi = oldArray.Except(newArray).ToList();//1,3
            var newChaJi = newArray.Except(oldArray).ToList();//7,8,9
            var bingJi = oldArray.Union(newArray).ToList();//1,2,3,4,5,7,8,9

            //---------------------------------不同类型的集合---------------------------------------------------

            List<A> aLst = new List<A>() {
                new A() { AName = "A0", A_BID = 0 },
                new A() { AName = "A1", A_BID = 1 },
                new A() { AName = "A2", A_BID = 2 },
                new A() { AName = "A3", A_BID = 2 },
                new A() { AName = "B中没有的", A_BID = 8 },
            };

            List<B> bLst = new List<B>() {
                new B() { BName = "B0", BId = 0 },
                new B() { BName = "B1", BId = 1 },
                new B() { BName = "B2", BId = 2 },
                new B() { BName = "B3", BId = 3 },
                new B() { BName = "A中没有的", BId = 88 },
            };

            //---------------------------------------------------内链接-----------------------------------------------
            //简单内链接
            var v = from a in aLst
                    from b in bLst
                    where a.A_BID == b.BId
                    select new { a.AName, a.A_BID, b.BName };

            var v2 = from a in aLst
                     from b in bLst
                     where a.A_BID != b.BId
                     select a;

            var vv = from a in aLst
                     join b in bLst on a.A_BID equals b.BId
                     select new { a.AName, a.A_BID, b.BName };

            var vvv = aLst.Join(bLst, a => a.A_BID, b => b.BId, (a, b) => new { a.AName, a.A_BID, b.BName }).ToList();

            var vvvv = aLst.Join(bLst, a => a.A_BID, b => b.BId, (a, b) => a).ToList();
            //---------------------------------------------------  外链接-----------------------------------------------
            var c = from a in aLst
                    join b in bLst on a.A_BID equals b.BId into g
                    select g;

            var cc = aLst.GroupJoin(bLst, a => a.A_BID, b => b.BId, (a, b) => new { a, b.FirstOrDefault()?.BName })
                .Select(x => x).ToList();
            var ccc = aLst.GroupJoin(bLst, a => a.A_BID, b => b.BId, (a, b) => new { a, b })
                .SelectMany(x => x.b.DefaultIfEmpty(), (x, b) => new { x, b.BName }).ToList();
            //复合联接

            //var vv2 = from a in aLst
            //          join b in bLst 
            //          on new { a.AName } 
            //          equals new { b.BName }
            //          select a.AName;

            List<Employee> employees = new List<Employee>();
            List<Student> students = new List<Student>();
            var query = from employee in employees
                        join student in students
                        on new { employee.FirstName, employee.LastName }
                        equals new { student.FirstName, student.LastName }
                        select employee.FirstName + " " + employee.LastName;





            Console.Read();
        }
    }


    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeID { get; set; }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentID { get; set; }
    }



    public class A
    {
        public string AName { get; set; }
        public int A_BID { get; set; }

    }

    public class B
    {
        public int BId { get; set; }
        public string BName { get; set; }
    }
}
