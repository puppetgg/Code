using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace II.void与task
{
    class Program
    {
        static void Main(string[] args)
        {



            Enumerable.Range(0, 3).ToList().ForEach(async (i) =>
            {
                try
                {
                    await new Task(() =>
                    {
                        try
                        {
                            Thread.Sleep(2000);
                            Console.WriteLine("aaaa");
                            //  throw new Exception("aaaa" + i);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message + "iiiiiiiiiiiiiii" + i);
                        }

                    });


                    Console.WriteLine("bbbbba");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            });


            Console.WriteLine("wwwwwwwwwwwwwwww");
            Console.Read();
        }
    }
}
