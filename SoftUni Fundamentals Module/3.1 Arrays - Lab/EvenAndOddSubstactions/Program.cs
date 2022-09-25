using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenAndOddSubstactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int substraction = 0;
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    sumEven += array[i];
                }
                else
                {
                    sumOdd += array[i];
                }
            }

            substraction = sumEven - sumOdd;
            Console.WriteLine(substraction);
        }
    }
}
