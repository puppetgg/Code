using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于遍历的测试
{

    public class Car
    {
        public Car(string name, int mon)
        {
            CName = name;
            Money = mon;
        }
        public string CName { get; set; }
        public int Money { get; set; }


    }
    public class MyEnumerable : IEnumerable
    {

        public Car[] carArray = new Car[4];
        public MyEnumerable()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 50);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 45);
        }

        public IEnumerator GetEnumerator()
        {
            return carArray.GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            MyEnumerable carLot = new MyEnumerable();

            foreach (Car c in carLot)
            {
                // Console.WriteLine("{0} is going {1} MPH", c.CarName, c.CurrentSpeed);
            }

            Console.WriteLine($" my test result:");
        }
    }
}
