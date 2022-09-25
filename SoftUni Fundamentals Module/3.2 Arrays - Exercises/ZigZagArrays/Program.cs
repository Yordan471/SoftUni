using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArray = new int[n];
            int[] secondArray = new int[n];
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                int[] arrayOfIntegers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                counter++;

                if (counter == 1)
                {
                    firstArray[i] = arrayOfIntegers[0];
                    secondArray[i] = arrayOfIntegers[1];
                }
                else if (counter == 2)
                {
                    firstArray[i] = arrayOfIntegers[1];
                    secondArray[i] = arrayOfIntegers[0];
                    counter = 0;
                }
            }  
            
            for (int i = 0; i < firstArray.Length; i++)
            {
                Console.Write(firstArray[i] + " ");
            }

            Console.WriteLine();

            foreach (int arr in secondArray)
            {
                Console.Write(arr + " ");
            }
        }
    }
}
