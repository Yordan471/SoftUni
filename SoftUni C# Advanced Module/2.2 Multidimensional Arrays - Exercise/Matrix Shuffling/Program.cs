using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfAMatrix = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rows = sizeOfAMatrix[0];
            int cols = sizeOfAMatrix[1];

            string[,] rectangleMatrix = FillingMatrix(rows, cols);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandToArray = command
                    .Split();

                string operation = commandToArray[0];

                if (operation == "swap")
                {
                    int row1 = int.Parse(commandToArray[1]);
                    int col1 = int.Parse(commandToArray[2]);
                    int row2 = int.Parse(commandToArray[3]);
                    int col2 = int.Parse(commandToArray[4]);

                    if (row1 >= 0 && row1 <= rows - 1 &&
                        col1 >= 0 && col1 <= cols - 1 &&
                        row2 >= 0 && row2 <= rows - 1 &&
                        col2 >= 0 && col2 <= cols - 1)
                    {
                        string swapOne = rectangleMatrix[row1, col1];
                        string swapTwo = rectangleMatrix[row2, col2];

                        rectangleMatrix[row1, col1] = swapTwo;
                        rectangleMatrix[row2, col2] = swapOne;

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write($"{rectangleMatrix[row, col]} ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static string[,] FillingMatrix(int rows, int cols)
        {
            string[,] rectangleMatrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowArray = Console.ReadLine()
                    .Split(' ');

                for (int col = 0; col < cols; col++)
                {
                    rectangleMatrix[row, col] = rowArray[col];
                }
            }

            return rectangleMatrix;
        }
    }
}
