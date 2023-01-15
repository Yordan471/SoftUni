using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sideOfBoard = int.Parse(Console.ReadLine());

            if (sideOfBoard < 3)
            {
                Console.WriteLine(0);

                return;
            }

            char[,] board = new char[sideOfBoard, sideOfBoard];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string rowString = Console.ReadLine();
                char[] rowArray = rowString.ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = rowArray[col];
                }
            }

            int countKnightToRemove = 0;


            while (true)
            {
                int saveAttackedKnight = 0;
                int mostAtackedKnight = 0;
                int rowIndexKnight = 0;
                int colIndexKnight = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            saveAttackedKnight = CheckIfWeHitKnight(row, col, sideOfBoard, board);

                            if (mostAtackedKnight < saveAttackedKnight)
                            {
                                mostAtackedKnight = saveAttackedKnight;
                                rowIndexKnight = row;
                                colIndexKnight = col;
                            }
                        }
                    }
                }

                if (mostAtackedKnight == 0)
                {
                    break;
                }
                else
                {
                    board[rowIndexKnight, colIndexKnight] = '0';
                    countKnightToRemove++;
                }
            }

            Console.WriteLine(countKnightToRemove);
        }

        public static int CheckIfWeHitKnight(int row, int col, int sideOfBoard, char[,] board)
        {
            int attackedKnight = 0;

            if (CheckIfInsideBoundaries(row + 2, col + 1, sideOfBoard) &&
                board[row + 2, col + 1] == 'K')
            {
                attackedKnight++;
            }

            if (CheckIfInsideBoundaries(row + 2, col - 1, sideOfBoard) &&
                board[row + 2, col - 1] == 'K')
            {
                attackedKnight++;
            }

            if (CheckIfInsideBoundaries(row - 2, col + 1, sideOfBoard) &&
                board[row - 2, col + 1] == 'K')
            {
                attackedKnight++;
            }

            if (CheckIfInsideBoundaries(row - 2, col - 1, sideOfBoard) &&
                board[row - 2, col - 1] == 'K')
            {
                attackedKnight++;
            }

            if (CheckIfInsideBoundaries(row + 1, col + 2, sideOfBoard) &&
                board[row + 1, col + 2] == 'K')
            {
                attackedKnight++;
            }

            if (CheckIfInsideBoundaries(row - 1, col + 2, sideOfBoard) &&
                board[row - 1, col + 2] == 'K')
            {
                attackedKnight++;
            }

            if (CheckIfInsideBoundaries(row + 1, col - 2, sideOfBoard) &&
                board[row + 1, col - 2] == 'K')
            {
                attackedKnight++;
            }

            if (CheckIfInsideBoundaries(row - 1, col - 2, sideOfBoard) &&
                board[row - 1, col - 2] == 'K')
            {
                attackedKnight++;
            }

            return attackedKnight;
        }

        public static bool CheckIfInsideBoundaries(int row, int col, int sideOfBoard)
        {
            if (row >= 0 && row < sideOfBoard && col >= 0 && col < sideOfBoard)
            {
                return true;
            }

            return false;           
        }
    }
}
