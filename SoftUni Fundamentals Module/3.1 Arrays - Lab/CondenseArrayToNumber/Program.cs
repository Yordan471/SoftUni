using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondenseArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse) 
                .ToArray();

            int[] sumAdjacent = new int[array.Length - 1];

            while (sumAdjacent.Length > 0)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    sumAdjacent[i] = array[i] + array[i + 1];

                    if (i == array.Length - 2)
                    {
                        array = sumAdjacent;
                        sumAdjacent = new int[array.Length - 1];
                    }
                }
            }

            Console.WriteLine(array[0]);
        }
    }
}
