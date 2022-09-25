using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNumbersInReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];
            int[] newarray = new int[n];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                array[i] = number;
            }

            Array.Reverse(array);
            
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{array[i]} ");
            }

     //    for (int i = array.Length - 1; i >= 0; i--)
     //    {
     //        Console.WriteLine($"{array[i]} ");
     //    }
        }
    }
}
