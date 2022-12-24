using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_with_Max_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] doubleMatrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowArray = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.None)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    doubleMatrix[row, col] = rowArray[col];
                }
            }

            int saveBiggestSum = 0;
            int sumNumbers = 0;
            string saveSquare = string.Empty;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    sumNumbers = doubleMatrix[row, col] +
                        doubleMatrix[row, col + 1] +
                        doubleMatrix[row + 1, col] +
                        doubleMatrix[row + 1, col + 1];

                    if (saveBiggestSum < sumNumbers)
                    {
                        saveBiggestSum = sumNumbers;
                        saveSquare = $"{doubleMatrix[row, col]} {doubleMatrix[row, col + 1]}\n" +
                            $"{doubleMatrix[row + 1, col]} {doubleMatrix[row + 1, col + 1]}";
                    }
                }
            }

            Console.WriteLine(saveSquare);
            Console.WriteLine(saveBiggestSum);
        }
    }
}
