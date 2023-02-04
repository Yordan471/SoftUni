using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelpAMole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());

            string[,] field = new string[sizeOfField, sizeOfField];
            int saveRow = 0;
            int saveCol = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowArray = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowArray[col].ToString();

                    if (field[row, col] == "M")
                    {
                        field[row, col] = "-";
                        saveRow = row;
                        saveCol = col;
                    }
                }
            }
            
            int winPoints = 25;
            int currPoints = 0;

            string command = string.Empty;

            while (currPoints < 25 && (command = Console.ReadLine()) != "End")
            {
                string direction = command;

                if (direction == "left")
                { 
                    if (MoveToLeftOrRight(field, saveRow, saveCol - 1))
                    {
                        saveCol--;
                        string nextPosition = field[saveRow, saveCol];

                        currPoints = GoThroughNextPosition(nextPosition, currPoints);                      
                    } 
                    else
                    {
                        Console.WriteLine($"Don't try to escape the playing field!");
                    }
                }
                else if (direction == "right")
                {
                    if (MoveToLeftOrRight(field, saveRow, saveCol + 1))
                    {
                        saveCol++;
                        string nextPosition = field[saveRow, saveCol];

                        currPoints = GoThroughNextPosition(nextPosition, currPoints);
                    }
                    else
                    {
                        Console.WriteLine($"Don't try to escape the playing field!");
                    }
                }
                else if (direction == "up")
                {
                    if (MoveToUpOrDown(field, saveRow - 1, saveCol))
                    {
                        saveRow--;
                        string nextPosition = field[saveRow, saveCol];

                        currPoints = GoThroughNextPosition(nextPosition, currPoints);
                    }
                    else
                    {
                        Console.WriteLine($"Don't try to escape the playing field!");
                    }
                }
                else if (direction == "down")
                {
                    if (MoveToUpOrDown(field, saveRow + 1, saveCol))
                    {
                        saveRow++;
                        string nextPosition = field[saveRow, saveCol];

                        currPoints = GoThroughNextPosition(nextPosition, currPoints);
                    }
                    else
                    {
                        Console.WriteLine($"Don't try to escape the playing field!");
                    }
                }

                if (field[saveRow, saveCol] == "S")
                {
                    Teleport(field, ref saveRow, ref saveCol);
                }
                else if (field[saveRow, saveCol] != "-")
                {
                    field[saveRow, saveCol] = "-";
                }             
            }

            field[saveRow, saveCol] = "M";

            if (command == "End")
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {currPoints} points.");
            }
            else
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {currPoints} points.");
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static bool CheckBoundaries(string[,] field, int saveRow, int saveCol)
        {
            if (saveRow >= 0 && saveRow < field.GetLength(0) && saveCol >= 0 && saveCol < field.GetLength(1))
            {
                return true;
            }

            return false;
        }
        private static void Teleport(string[,] field, ref int saveRow, ref int saveCol)
        {
            field[saveRow, saveCol] = "-";

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == "S")
                    {
                        field[row, col] = "-";
                        saveRow = row;
                        saveCol = col;
                    }
                }
            }
        }

        private static bool MoveToUpOrDown(string[,] field, int saveRow, int saveCol)
        {
            if (saveRow >= 0 && saveRow < field.GetLength(0))
            {
                return true;
            }

            return false;
        }

        private static int GoThroughNextPosition(string nextPosition, int currPoints)
        {
            switch(nextPosition)
            {
                case "S":
                   return currPoints -= 3;                 
                case "-":
                    return currPoints;
                default:
                    return currPoints += int.Parse(nextPosition);
            }
        }

        public static bool MoveToLeftOrRight(string[,] field, int saveRow, int saveCol)
        {
            if (saveCol >= 0 && saveCol < field.GetLength(1))
            {           
                return true;
            }

            return false;
        }
    }
}
