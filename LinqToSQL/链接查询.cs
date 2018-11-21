using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    public class 链接查询
    {

        public static void 做链接分组()
        {


            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };


            var fun1 = from p in people
                       join a in pets on p equals a.Owner into ljobj
                       from subpet in ljobj.DefaultIfEmpty()
                       group subpet by p.FirstName into newper
                       select new { newper.Key, Persons = newper.FirstOrDefault() == null ? null : newper.ToList() };

            Console.WriteLine("lambada表达式方法");

            //var fun2=people.j



            foreach (var ownerAndPet in fun1)
            {
                if (ownerAndPet.Persons != null)
                {
                    foreach (var p in ownerAndPet.Persons)
                    {
                        Console.WriteLine(string.Format("{0} is owned by {1}", ownerAndPet.Key, p.Name));
                    }

                }
                else
                {
                    Console.WriteLine(string.Format("{0} is owned by {1}", ownerAndPet.Key, "没有值"));
                }
            }


         





        }

        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }
    }
}
