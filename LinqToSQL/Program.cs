using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{




    public class StudentScore
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Course { set; get; }
        public int Score { set; get; }
        public string Term { set; get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //SelectManay的使用.TT();

            分组链接查询.分组查询();

            List<StudentScore> lst = new List<StudentScore>() {
                new StudentScore(){ID=1,Name="张三",Term="第一学期",Course="Math",Score=80},
                new StudentScore(){ID=1,Name="张三",Term="第一学期",Course="Chinese",Score=90},
                new StudentScore(){ID=1,Name="张三",Term="第一学期",Course="English",Score=70},
                new StudentScore(){ID=2,Name="李四",Term="第一学期",Course="Math",Score=60},
                new StudentScore(){ID=2,Name="李四",Term="第一学期",Course="Chinese",Score=70},
                new StudentScore(){ID=2,Name="李四",Term="第一学期",Course="English",Score=30},
                new StudentScore(){ID=3,Name="王五",Term="第一学期",Course="Math",Score=100},
                new StudentScore(){ID=3,Name="王五",Term="第一学期",Course="Chinese",Score=80},
                new StudentScore(){ID=3,Name="王五",Term="第一学期",Course="English",Score=80},
                new StudentScore(){ID=4,Name="赵六",Term="第一学期",Course="Math",Score=90},
                new StudentScore(){ID=4,Name="赵六",Term="第一学期",Course="Chinese",Score=80},
                new StudentScore(){ID=4,Name="赵六",Term="第一学期",Course="English",Score=70},
                new StudentScore(){ID=1,Name="张三",Term="第二学期",Course="Math",Score=100},
                new StudentScore(){ID=1,Name="张三",Term="第二学期",Course="Chinese",Score=80},
                new StudentScore(){ID=1,Name="张三",Term="第二学期",Course="English",Score=70},
                new StudentScore(){ID=2,Name="李四",Term="第二学期",Course="Math",Score=90},
                new StudentScore(){ID=2,Name="李四",Term="第二学期",Course="Chinese",Score=50},
                new StudentScore(){ID=2,Name="李四",Term="第二学期",Course="English",Score=80},
                new StudentScore(){ID=3,Name="王五",Term="第二学期",Course="Math",Score=90},
                new StudentScore(){ID=3,Name="王五",Term="第二学期",Course="Chinese",Score=70},
                new StudentScore(){ID=3,Name="王五",Term="第二学期",Course="English",Score=80},
                new StudentScore(){ID=4,Name="赵六",Term="第二学期",Course="Math",Score=70},
                new StudentScore(){ID=4,Name="赵六",Term="第二学期",Course="Chinese",Score=60},
                new StudentScore(){ID=4,Name="赵六",Term="第二学期",Course="English",Score=70},
            };


            ////分组，根据姓名，统计Sum的分数，统计结果放在匿名对象中。两种写法。
            var fun1 = from li in lst
                       group li by li.Name into g
                       orderby g.Sum(x => x.Score)
                       select new { name = g.Key, score = g.Sum(m => m.Score) };
            foreach (var item in fun1)
            {
                //    Console.WriteLine($"{ item.name}------{ item.score}");
            }

            var fun2 = lst.GroupBy(x => x.Name).Select(k => new { name = k.Key, score = k.Sum(x => x.Score) }).ToList();

            // fun2.ForEach(x => Console.WriteLine($"----{x.name}-----{x.score}----"));


            Console.WriteLine("分组，根据2个条件学期和课程，统计各科均分,统计结果放在匿名对象中。两种写法。");
            var fun3 = from li in lst
                       group li by new { li.Term, li.Course } into g
                       select new
                       {
                           name = g.Key,
                           score = g.Average(k => k.Score)
                       };
            foreach (var item in fun3)
            {
                Console.WriteLine($"{ item.name}------{ item.score}");
            }

            Console.WriteLine("---------第一种写法");
            var TermAvgScore_1 = (from l in lst
                                  group l by new { Term = l.Term, Course = l.Course } into grouped
                                  orderby grouped.Average(m => m.Score) ascending
                                  orderby grouped.Key.Term descending
                                  select new
                                  {
                                      Term = grouped.Key.Term,
                                      Course = grouped.Key.Course,
                                      Scores = grouped.Average(m => m.Score)
                                  }).ToList();
            foreach (var l in TermAvgScore_1)
            {
                Console.WriteLine("学期:{0},课程{1},均分{2}", l.Term, l.Course, l.Scores);
            }


            Console.WriteLine("lambda表达式");
            var fun4 = lst.GroupBy(x => new { x.Term, x.Course })
                .Select(x => new { name = x.Key, avg = x.Average(v => v.Score) }).ToList();
            fun4.ForEach(x => Console.WriteLine($"---{x.name}-----{x.avg}---------"));

            Console.WriteLine(".//分组，带有Having的查询，查询均分>80的学生");
            var fun5 = from li in lst
                       group li by li.Name into g
                       where g.Average(m => m.Score) >= 80
                       select new
                       {
                           name = g.Key,
                           avg = g.Average(x => x.Score)
                       };

            foreach (var item in fun5)
            {
                Console.WriteLine($"{ item.name}------{ item.avg}");
            }
            //-------------------------------------------------------------
            //分组，带有Having的查询，查询均分>80的学生
            Console.WriteLine("---------第一种写法");
            var AvgScoreGreater80_1 = (from l in lst
                                       group l by new { Name = l.Name, Term = l.Term } into grouped
                                       where grouped.Average(m => m.Score) >= 80
                                       orderby grouped.Average(m => m.Score) descending
                                       select new
                                       {
                                           Name = grouped.Key.Name,
                                           Term = grouped.Key.Term,
                                           Scores = grouped.Average(m => m.Score)
                                       }).ToList();
            foreach (var l in AvgScoreGreater80_1)
            {
                Console.WriteLine("姓名:{0},学期{1},均分{2}", l.Name, l.Term, l.Scores);
            }

            Console.WriteLine("啦马达版");
            var fun6 = lst.GroupBy(b => new { b.Name, b.Term })
                .Select(g => new { name = g.Key.Name, term = g.Key.Term, avg = g.Average(v => v.Score) })
                .Where(g => g.avg >= 80)
                .OrderByDescending(x => x.avg).ThenByDescending(x => x.term).ToList();

            fun6.ForEach(x => Console.WriteLine($"-----{x.name}--{x.term}----{x.avg}-----"));
            链接查询.做链接分组();


            lambada表达式左链接.测试链接();

            Console.ReadKey();

        }
    }
}
