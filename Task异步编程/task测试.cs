using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task异步编程
{
    public class task测试
    {



        public void Action()
        {
          Task ta=  Task.Run(new Action(Pp));



            //  ta.  GetAwaiter().
            //Action a = new Action(Pp);


            Action bb = Pp;



        }
        public void Pp()
        {
            Console.WriteLine("aaa");
        }









    }



}