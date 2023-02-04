using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDestroyer
{
    public class Program
    {
        private static int saveRow = 0;
        private static int saveCol = 0;
        private static int countHoles = 1;
        private static int countHitRods = 0;

        static void Main(string[] args)
        {
            int wallSize = int.Parse(Console.ReadLine());

            string[,] wall = new string[wallSize, wallSize];
               

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                string rowInfo = Console.ReadLine();

                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    wall[row, col] = rowInfo[col].ToString();

                    if (wall[row, col] == "V")
                    {
                        saveRow = row;
                        saveCol = col;
                        wall[row, col] = "*";
                    }
                }
            }

            string command = string.Empty;
            
            bool hitCable = false;

            while ((command = Console.ReadLine()) != "End")
            {
                string movePosition = command;
                string nextPosition = string.Empty;

                if (movePosition == "left")
                {
                    if (CheckValidPosition(wall, saveRow, saveCol - 1))
                    {
                        saveCol--;
                        nextPosition = GetPosition(wall, saveRow, saveCol);

                        NextPositionLandsOn(wall, saveRow, saveCol, nextPosition);
                    }
                }
                else if (movePosition == "right")
                {
                    if (CheckValidPosition(wall, saveRow, saveCol + 1))
                    {
                        saveCol++;
                        nextPosition = GetPosition(wall, saveRow, saveCol);

                        NextPositionLandsOn(wall, saveRow, saveCol, nextPosition);
                    }
                }
                else if (movePosition == "down")
                {
                    if (CheckValidPosition(wall, saveRow + 1, saveCol))
                    {
                        saveRow++;
                        nextPosition = GetPosition(wall, saveRow, saveCol);

                        NextPositionLandsOn(wall, saveRow, saveCol, nextPosition);
                    }
                }
                else if (movePosition == "up")
                {
                    if (CheckValidPosition(wall, saveRow - 1, saveCol))
                    {
                        saveRow--;
                        nextPosition = GetPosition(wall, saveRow, saveCol);

                        NextPositionLandsOn(wall, saveRow, saveCol, nextPosition);
                    }
                }

                if (nextPosition == "R")
                {
                    if (movePosition == "left" || movePosition == "right")
                    {
                        saveCol = ReturnRowCol(saveRow, saveCol, movePosition);
                    }
                    else
                    {
                        saveRow = ReturnRowCol(saveRow, saveCol, movePosition);
                    }

                    countHitRods++;
                }
                else if (nextPosition == "C")
                {
                    hitCable = true;
                    countHoles++;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
                    break;
                }
                else if (nextPosition == "-")
                {
                    countHoles++;
                }
            }

            if (!hitCable)
            {
                Console.WriteLine($"Vanko managed to make {countHoles} hole(s) and he hit only {countHitRods} rod(s).");
                wall[saveRow, saveCol] = "V";
            }

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col  = 0; col  < wall.GetLength(1); col ++)
                {
                    Console.Write($"{wall[row, col]}");
                }

                Console.WriteLine();
            }
        }

        public static int ReturnRowCol(int saveRow, int saveCol, string movePosition)
        {          
            switch(movePosition)
            {
                case "left":
                   return ++saveCol;
                    
                case "right":
                   return --saveCol;
                    
                case "down":
                   return --saveRow;
                    
                case "up":
                   return ++saveRow;
                default:
                    return default;
            }
        }


        private static void NextPositionLandsOn(string[,] wall, int saveRow, int saveCol, string nextPosition)
        {
            switch(nextPosition)
            {
                case "R":
                    Console.WriteLine("Vanko hit a rod!");
                    break;
                case "-":
                    wall[saveRow, saveCol] = "*";
                    break;
                case "C":
                    wall[saveRow, saveCol] = "E";                   
                    break;
                default:
                    Console.WriteLine($"The wall is already destroyed at position [{saveRow}, {saveCol}]!");
                    break;
            }               
        }

        private static string GetPosition(string[,] wall, int saveRow, int saveCol)
        {
            return wall[saveRow, saveCol];
        }

        public static bool CheckValidPosition(string[,] wall, int saveRow, int saveCol)
        {
            if (saveRow >= 0 && saveRow < wall.GetLength(0) && 
                saveCol >= 0 && saveCol < wall.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
