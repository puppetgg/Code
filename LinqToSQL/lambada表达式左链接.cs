using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    public class lambada表达式左链接
    {




        public static void 测试链接()
        {
            List<Pet> pets =
                   new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 } };

            List<Pet2> pets2 =
                   new List<Pet2>{ new Pet2 { Name="Barley", Sex = "男" },
                                   new Pet2 { Name="Boots", Sex = "男"}, };
            Console.WriteLine("------------------linq------------------");

            var fun = from p in pets
                      join p2 in pets2 on p.Name equals p2.Name into j
                      from e in j.DefaultIfEmpty(new Pet2())
                      select new { name = p.Name, age = p.Age, sex = e.Sex };

            foreach (var item in fun)
            {
                Console.WriteLine($"-^^^--------------{item.age}--{item.name}---{item.sex}------------");
            }
            Console.WriteLine($"-----------------------------rightanswer------------------------");

            var list2 = from x in pets
                        join y in pets2 on x.Name equals y.Name into ptelist
                        from z in ptelist.DefaultIfEmpty(new Pet2())
                        select new { Name = x.Name, Age = x.Age, Sex = z.Sex };

            list2.ToList().ForEach(x => Console.WriteLine($"======={x.Sex}=={x.Name}==={x.Age}============================="));


            Console.WriteLine("--------------------------内链接----------------------");

            var list3 = pets.Join(pets2, x => x.Name, y => y.Name, (x, y) => new { Name = x.Name, Age = x.Age, Sex = y.Sex })
                .DefaultIfEmpty();


            var innerLst = pets.Join(pets2, x => x.Name, y => y.Name, (x, y) => new { name = y.Name, age = x.Age, sex = y.Sex })
                .Select(o => o).ToList();
            innerLst.ForEach(c => Console.WriteLine($"-------***----------{c.age}--{c.name}--{c.sex}------------------"));
            list3.ToList().ForEach(c => Console.WriteLine($"--***--right-------------{c.Age}--{c.Name}--{c.Sex}------------------"));



            var list = pets.GroupJoin(pets2, x => x.Name, y => y.Name, (x, y) => y.DefaultIfEmpty(new Pet2())
            .Select(z => new { Name = x.Name, Age = x.Age, Sex = z.Sex }))
            .SelectMany(x => x);
            foreach (var item in list)
            {
                Console.WriteLine($"---------------------{item.Age}--{item.Name}---{item.Sex}------------------------------------");
            }

            Console.ReadKey();




        }

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    internal class Pet
    {
        public string Name;
        public int Age;

    }

    internal class Pet2
    {

        public string Name;
        public string Sex;
    }
}
