using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            if (sizeOfMatrix == 0)
            {
                Console.WriteLine($"Alive cells: 0");
                Console.WriteLine($"Sum: 0");
                Console.WriteLine(0);
                return;
            }

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowArray = Console.ReadLine()
                    .Split(' ')
                    .Select(x => int.Parse(x))
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }

            string[] bombs = Console.ReadLine()
                .Split();

            for (int i = 0; i < bombs.Length; i++)
            {
                int[] bombCoordinates = bombs[i]
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

                int firstIndex = bombCoordinates[0];
                int secondIndex = bombCoordinates[1];

                if (matrix[firstIndex, secondIndex] > 0)
                {
                    if (ValidCoordinates(matrix, firstIndex, secondIndex - 1))
                    {
                        if (BombToZero(matrix, firstIndex, secondIndex, bombs, firstIndex, secondIndex))
                        {
                            matrix[firstIndex, secondIndex - 1] = 0;
                        }
                        else
                        {
                            if (matrix[firstIndex, secondIndex - 1] >= 0)
                                matrix[firstIndex, secondIndex - 1] -= matrix[firstIndex, secondIndex];
                        }
                    }

                    if (ValidCoordinates(matrix, firstIndex - 1, secondIndex - 1))
                    {
                        if (BombToZero(matrix, firstIndex - 1, secondIndex - 1, bombs, firstIndex, secondIndex))
                        {
                            matrix[firstIndex - 1, secondIndex - 1] = 0;
                        }
                        else
                        {
                            if (matrix[firstIndex - 1, secondIndex - 1] >= 0)
                                matrix[firstIndex - 1, secondIndex - 1] -= matrix[firstIndex, secondIndex];
                        }
                    }

                    if (ValidCoordinates(matrix, firstIndex - 1, secondIndex))
                    {
                        if (BombToZero(matrix, firstIndex - 1, secondIndex, bombs, firstIndex, secondIndex))
                        {
                            matrix[firstIndex - 1, secondIndex] = 0;
                        }
                        else
                        {
                            if (matrix[firstIndex - 1, secondIndex] >= 0)
                                matrix[firstIndex - 1, secondIndex] -= matrix[firstIndex, secondIndex];
                        }
                    }

                    if (ValidCoordinates(matrix, firstIndex - 1, secondIndex + 1))
                    {
                        if (BombToZero(matrix, firstIndex - 1, secondIndex + 1, bombs, firstIndex, secondIndex))
                        {
                            matrix[firstIndex - 1, secondIndex + 1] = 0;
                        }
                        else
                        {
                            if (matrix[firstIndex - 1, secondIndex + 1] >= 0)
                                matrix[firstIndex - 1, secondIndex + 1] -= matrix[firstIndex, secondIndex];
                        }
                    }

                    if (ValidCoordinates(matrix, firstIndex, secondIndex + 1))
                    {
                        if (BombToZero(matrix, firstIndex, secondIndex + 1, bombs, firstIndex, secondIndex))
                        {
                            matrix[firstIndex, secondIndex + 1] = 0;
                        }
                        else
                        {
                            if (matrix[firstIndex, secondIndex + 1] >= 0)
                                matrix[firstIndex, secondIndex + 1] -= matrix[firstIndex, secondIndex];
                        }
                    }

                    if (ValidCoordinates(matrix, firstIndex + 1, secondIndex + 1))
                    {
                        if (BombToZero(matrix, firstIndex + 1, secondIndex + 1, bombs, firstIndex, secondIndex))
                        {
                            matrix[firstIndex + 1, secondIndex + 1] = 0;
                        }
                        else
                        {
                            if (matrix[firstIndex + 1, secondIndex + 1] >= 0)
                                matrix[firstIndex + 1, secondIndex + 1] -= matrix[firstIndex, secondIndex];
                        }
                    }

                    if (ValidCoordinates(matrix, firstIndex + 1, secondIndex))
                    {
                        if (BombToZero(matrix, firstIndex + 1, secondIndex, bombs, firstIndex, secondIndex))
                        {
                            matrix[firstIndex + 1, secondIndex] = 0;
                        }
                        else
                        {
                            if (matrix[firstIndex + 1, secondIndex] >= 0)
                                matrix[firstIndex + 1, secondIndex] -= matrix[firstIndex, secondIndex];
                        }
                    }

                    if (ValidCoordinates(matrix, firstIndex + 1, secondIndex - 1))
                    {
                        if (BombToZero(matrix, firstIndex + 1, secondIndex - 1, bombs, firstIndex, secondIndex))
                        {
                            matrix[firstIndex + 1, secondIndex - 1] = 0;
                        }
                        else
                        {
                            if (matrix[firstIndex + 1, secondIndex - 1] >= 0)
                                matrix[firstIndex + 1, secondIndex - 1] -= matrix[firstIndex, secondIndex];
                        }
                    }
                }

                matrix[firstIndex, secondIndex] = 0;
            }

            int countCells = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        countCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {countCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        public static bool ValidCoordinates(int[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        public static bool BombToZero(int[,] matrix, int row, int col, string[] bombs, int firstIndex, int secondIndex)
        {
            for (int i = 0; i < bombs.Length; i ++)
            {
                int[] bombCoordinates = bombs[i]
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
                
                if (matrix[row, col] == matrix[bombCoordinates[0], bombCoordinates[1]])
                    
                {
                    int number = 0;
                    number = matrix[row, col] - matrix[firstIndex, secondIndex];

                    if (number < 0)
                    {
                        return true;
                    }
                }
            }

            return false;      
        }
    }
}
