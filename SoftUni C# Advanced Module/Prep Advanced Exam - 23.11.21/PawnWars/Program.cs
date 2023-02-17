using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSize = 8;
            string[,] board = new string[boardSize, boardSize];
            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;

            Dictionary<int, string> numberAndLetter = new Dictionary<int, string>()
            {
                { 0, "a" },
                { 1, "b" },
                { 2, "c" },
                { 3, "d" },
                { 4, "e" },
                { 5, "f" },
                { 6, "g" },
                { 7, "h" },
            };

            for (int row = 0; row < boardSize; row++)
            {
                string rowInput = Console.ReadLine();

                for (int col = 0; col < boardSize; col++)
                {
                    board[row, col] = rowInput[col].ToString();

                    if (board[row, col] == "w")
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }

                    if (board[row, col] == "b")
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            bool whiteWins = false;
            bool blackWins = false;
            bool capture = false;
            int saveBlackRow = 0;
            int saveBlackCol = 0;
            int saveWhiteRow = 0;
            int saveWhiteCol = 0;

            if (blackCol - 1 == whiteCol || blackCol + 1 == whiteCol)
            {
                capture = true;

                if ((whiteRow - blackRow) % 2 == 0)
                {
                    saveBlackRow = blackRow + (whiteRow - blackRow) / 2;
                    saveBlackCol = whiteCol;
                    blackWins = true;
                }
                else
                {
                    saveWhiteRow = blackRow + ((whiteRow - blackRow) / 2);
                    saveWhiteCol = blackCol;
                    whiteWins = true;
                }
            }
            else
            {
                if (-blackRow + boardSize - 1 >= boardSize - 1 - whiteRow)
                {
                    saveWhiteCol = whiteCol;
                    saveWhiteRow = 8;
                    whiteWins = true;
                }
                else
                {
                    saveBlackCol = blackCol;
                    saveBlackRow = 1;
                    blackWins = true;
                }
            }

            if (capture)
            {
                if (blackWins)
                {
                    string letter = numberAndLetter[saveBlackCol];
                    Console.WriteLine($"Game over! Black capture on {letter}{boardSize - saveBlackRow}");
                }
                else
                {
                    string letter = numberAndLetter[saveWhiteCol];
                    Console.WriteLine($"Game over! White capture on {letter}{boardSize - saveWhiteRow}");
                }
            }
            else
            {
                if (blackWins)
                {
                    string letter = numberAndLetter[saveBlackCol];
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {letter}{saveBlackRow}");
                }
                else
                {
                    string letter = numberAndLetter[saveWhiteCol];
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {letter}{saveWhiteRow}");
                }
            }
            
            
        }
    }
}
