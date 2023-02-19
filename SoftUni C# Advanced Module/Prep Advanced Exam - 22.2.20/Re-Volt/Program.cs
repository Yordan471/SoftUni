using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int numberOfCommands = int.Parse(Console.ReadLine());

            string[,] matrix = new string[sizeOfMatrix, sizeOfMatrix];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowInput = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col].ToString();

                    if (matrix[row, col] == "f")
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[row, col] = "-";
                    }
                }
            }

            bool finished = false;

            while (numberOfCommands != 0 && finished != true)
            {
                string moveTo = Console.ReadLine();
                numberOfCommands--;

                Move(matrix, ref playerRow, ref playerCol, moveTo);

                if (matrix[playerRow, playerCol] == "T")
                {
                    if (moveTo == "left")
                    {
                        playerCol += 2;
                        Move(matrix, ref playerRow, ref playerCol, moveTo);
                    }
                    else if (moveTo == "right")
                    {
                        playerCol -= 2;
                        Move(matrix, ref playerRow, ref playerCol, moveTo);
                    }
                    else if (moveTo == "up")
                    {
                        playerRow += 2;
                        Move(matrix, ref playerRow, ref playerCol, moveTo);
                    }
                    else if (moveTo == "down")
                    {
                        playerRow -= 2;
                        Move(matrix, ref playerRow, ref playerCol, moveTo);
                    }                   
                }
                else if (matrix[playerRow, playerCol] == "B")
                {
                    Move(matrix, ref playerRow, ref playerCol, moveTo);
                }
                else if (matrix[playerRow, playerCol] == "F")
                {
                    finished = true;
                }
            }

            matrix[playerRow, playerCol] = "f";

            if (finished)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }

        private static void Move(string[,] matrix, ref int playerRow, ref int playerCol, string moveTo)
        {
            if (moveTo == "left")
            {
                if (playerCol - 1 < 0)
                {
                    playerCol = matrix.GetLength(1) - 1;
                }
                else
                {
                    playerCol--;
                }
            }
            else if (moveTo == "right")
            {
                if (playerCol + 1 == matrix.GetLength(1))
                {
                    playerCol = 0;
                }
                else
                {
                    playerCol++;
                }
            }
            else if (moveTo == "up")
            {
                if (playerRow - 1 < 0)
                {
                    playerRow = matrix.GetLength(0) - 1;
                }
                else
                {
                    playerRow--;
                }
            }
            else if (moveTo == "down")
            {
                if (playerRow + 1 == matrix.GetLength(0))
                {
                    playerRow = 0;
                }
                else
                {
                    playerRow++;
                }
            }
        }
    }
}
