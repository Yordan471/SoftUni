using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string snake = Console.ReadLine();

            char[,] matrix = new char[rows, cols];

            int currIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (currIndex == snake.Length)
                        {
                            currIndex = 0;
                        }

                        matrix[row, cols] = snake[currIndex];

                        currIndex++;
                    }
                }
                else
                {

                }
            }

            
        }
    }
}
