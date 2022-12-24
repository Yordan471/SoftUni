using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2x2_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            string[,] rectangleMatrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowArray = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    rectangleMatrix[row, col] = rowArray[col];
                }
            }

            int countMatches = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (rectangleMatrix[row, col] == rectangleMatrix[row, col + 1] &&
                        rectangleMatrix[row, col] == rectangleMatrix[row + 1, col] &&
                        rectangleMatrix[row, col] == rectangleMatrix[row + 1, col +1])
                    {
                        countMatches++;
                    }
                }
            }

            Console.WriteLine(countMatches);
        }
    }
}
