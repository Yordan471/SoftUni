using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquareMatrix = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[sizeOfSquareMatrix, sizeOfSquareMatrix];

            for (int row = 0; row < sizeOfSquareMatrix; row++)
            {
                int[] rowArray = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < sizeOfSquareMatrix; col++)
                {
                    squareMatrix[row, col] = rowArray[col];
                }
            }

            int firstSum = 0;

            for (int row = 0; row < sizeOfSquareMatrix; row++)
            {
                firstSum += squareMatrix[row, row];
            }

            int secondSum = 0;
            int count = 0;

            for (int row = 0; row < sizeOfSquareMatrix; row++)
            {
                count++;
                secondSum += squareMatrix[row, sizeOfSquareMatrix - count];
            }

            Console.WriteLine($"{Math.Abs(firstSum - secondSum)}");
        }
    }
}
