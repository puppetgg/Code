using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 三表连接查询加分组
{
    class Program
    {
        static void Main(string[] args)
        {


            // var result = Data.Users.GroupJoin(Data.Parents,)



        }
    }




    public static class Data
    {
        public static List<Parent> Parents = new List<Parent>() {
            new Parent() { Id=1,Father="aa0",Mather="bb0",UserId=1},
            new Parent() { Id=1,Father="aa1",Mather="bb1",UserId=5},
            new Parent() { Id=1,Father="aa2",Mather="bb2",UserId=3},

        };

        public static List<Users> Users = new List<Users>() {
            new Users() {Id=1,UserName="Usr1",Number="NS001",UClass="ddd1",CheckType=1 },
            new Users() {Id=1,UserName="Usr2",Number="NS002",UClass="ddd2",CheckType=1 },
            new Users() {Id=1,UserName="Usr3",Number="NS003",UClass="ddd3",CheckType=1 },
            new Users() {Id=1,UserName="Usr4",Number="NS004",UClass="ddd4",CheckType=2 },

        };

        public static List<Score> Score = new List<Score>()
        {
            new Score() { Id=5,Sub="天文",Scores=39,UserId=5},
            new Score() { Id=6,Sub="数学",Scores=39,UserId=5},
            new Score() { Id=7,Sub="物理",Scores=39,UserId=1},
            new Score() { Id=8,Sub="英文",Scores=39,UserId=1},
            new Score() { Id=9,Sub="英文",Scores=39,UserId=1},

            new Score() { Id=11,Sub="数学",Scores=39,UserId=3},
            new Score() { Id=12,Sub="英文",Scores=39,UserId=3},
            new Score() { Id=13,Sub="地理",Scores=39,UserId=4},
            new Score() { Id=14,Sub="地理",Scores=39,UserId=2},


        };

    }


    public class Parent
    {
        public int Id { get; set; }
        public string Father { get; set; }
        public string Mather { get; set; }
        public int UserId { get; set; }


    }


    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Number { get; set; }
        public string UClass { get; set; }
        public int CheckType { get; set; }
    }


    public class Score
    {
        public int Id { get; set; }
        public string Sub { get; set; }
        public int Scores { get; set; }
        public int UserId { get; set; }

    }
}
