using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrix = Console.ReadLine()
               .Split(new string[] { ", " }, StringSplitOptions.None)
               .Select(int.Parse)
               .ToArray();

            int[,] doubleMatrix = new int[matrix[0], matrix[1]];

            for (int row = 0; row < doubleMatrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.None)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < doubleMatrix.GetLength(1); col++)
                {
                    doubleMatrix[row, col] = colElements[col];
                }
            }

            long[] sum = new long[matrix[1]];

            for (int row = 0; row < doubleMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < doubleMatrix.GetLength(1); col++)
                {
                    sum[col] += doubleMatrix[row, col];
                }
            }

            foreach (int number in sum)
            {
                Console.WriteLine(number);
            }
        }
    }
}
