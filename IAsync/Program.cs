﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            new MyClass().SimpleMethod();
            Console.WriteLine("THERE");
            Console.Read();
        }
    }




    class MyClass
    {

        public async void SimpleMethod()
        {
            Thread.Sleep(1000);
            Console.WriteLine("HERE");
        }


    }
}
