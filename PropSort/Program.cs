using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 100, 12, 45, 89, 46, 121 };



            Prop(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);

            }

            Console.Read();

        }

        private static void Prop(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }

                }

            }

        }

        private static void FirstMax(int[] arr)
        {
            for (int i = 1; i <= arr.Length - 1; i++)
            {
                if (arr[0] < arr[i])
                {
                    int temp = arr[0];
                    arr[0] = arr[i];
                    arr[i] = temp;
                }
            }
        }






        private static void MySort(int[] arr)
        {
            //外面的循环告诉内循环数组从第几个元素开始
            for (int j = 0; j <= arr.Length - 1; j++)
            {
                for (int i = j; i <= arr.Length - 1; i++)
                {
                    if (arr[j] < arr[i])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

        }
    }
}
