using System;

namespace 请假流程1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");




            ApplyHoliday context = new ApplyHoliday();




        }
    }










    public class ApplyHoliday
    {
        public string Id { get; set; } = DateTime.Now.ToString();

        public string Name { get; set; }

        public int DayCount { get; set; }

        public bool IsAgree { get; set; }

        public string Resion { get; set; }


    }







}
