using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

            int[] leftSideFoldedArray = new int[(array.Length / 2) / 2];

            for (int i = 0; i < leftSideFoldedArray.Length; i++)
            {
                leftSideFoldedArray[i] = array[i];
            }

            int[] rightSideFoldedArray = new int[(array.Length / 2) / 2];

            for (int i = 0; i < rightSideFoldedArray.Length; i++)
            {
                rightSideFoldedArray[i] = array[(array.Length / 2) + (rightSideFoldedArray.Length) + i];
            }

            int[] middlePartArray = new int[array.Length / 2];

            for (int i = 0; i < middlePartArray.Length; i++)
            {
                middlePartArray[i] = array[((array.Length / 2) / 2) + i];
            }

            Array.Reverse(rightSideFoldedArray);
            Array.Reverse(leftSideFoldedArray);

            int[] wholeFoldedArray = leftSideFoldedArray.Concat(rightSideFoldedArray).ToArray();

            int[] sumArray = new int[array.Length / 2];

            for (int i = 0; i < sumArray.Length; i++)
            {
                sumArray[i] = wholeFoldedArray[i] + middlePartArray[i];
            }

            Console.WriteLine(String.Join(" ", sumArray));
        }
    }
}
