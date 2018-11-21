using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectMany的使用
{
    public class Stu
    {
        public string SName;
        public int Score { get; set; }
    }
    public class Tea
    {
        public string Name;

        public List<Stu> StuLst;

    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Tea> TeaLst = new List<Tea>() {

              new Tea() {
               Name = "t1",
                StuLst = new List<Stu>() {
                                   new Stu() { SName="s1",Score = 10},
                                    new Stu() { SName="s2",Score = 20},
                                    new Stu() { SName="s3",Score = 30},
                                     new Stu() { SName="s4",Score = 40}
               }
              },
              new Tea() {
               Name = "t2",
                StuLst = new List<Stu>() {
                                   new Stu() { SName="s5",Score = 110},
                                    new Stu() { SName="s6",Score = 20},
                                    new Stu() { SName="s7",Score = 30},
                                     new Stu() { SName="s8",Score = 40}
               }
              },
              new Tea() {
               Name = "t3",
                StuLst = new List<Stu>() {
                                   new Stu() { SName="s9",Score = 10},
                                    new Stu() { SName="s0",Score = 120},
                                    new Stu() { SName="s13",Score = 30},
                                     new Stu() { SName="s14",Score = 140}
               }
              },
              new Tea() {
               Name = "t4",
                StuLst = new List<Stu>() {
                                   new Stu() { SName="s11",Score = 10},
                                    new Stu() { SName="s112",Score =120},
                                    new Stu() { SName="s113",Score = 30},
                                     new Stu() { SName="s114",Score = 140}
               }
              }
            };


            var nv = TeaLst.Select(x => x.StuLst).ToList();
            var v = TeaLst.SelectMany(t=>t.StuLst).ToList();
            //var sss = TeaLst.FackSelectMany((x. y) => {  });
            //  var sname = TeaLst.SelectMany((x,index) =>new { a=x.StuLst,b=index }).Where(x => x.Score > 100).ToList();


            var TAndSName = TeaLst.SelectMany(x => x.StuLst, (tt, x) => new { tt.Name, x.Score }).Where(x => x.Score > 100).ToList();


            Console.WriteLine("dsd");

        }
    }
}
