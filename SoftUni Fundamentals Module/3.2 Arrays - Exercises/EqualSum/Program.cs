using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int sumLeft = 0;
            int sumRight = 0;
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    sumLeft += array[j];
                }

                for (int k = i + 1; k < array.Length; k++)
                {
                    sumRight += array[k];
                }

                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    counter++;
                } 
                
                sumLeft = 0;
                sumRight = 0;
            }

            if (counter == 0)
            {
                Console.WriteLine("no");
            }
        }
    }
}
