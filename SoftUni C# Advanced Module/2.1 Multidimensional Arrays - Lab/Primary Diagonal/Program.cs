using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                int[] rowArray = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    squareMatrix[row, col] = rowArray[col];
                }
            }

            int sumDiagonalNumbers = 0;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                sumDiagonalNumbers += squareMatrix[row, row];
            }

            Console.WriteLine(sumDiagonalNumbers);
        }
    }
}
