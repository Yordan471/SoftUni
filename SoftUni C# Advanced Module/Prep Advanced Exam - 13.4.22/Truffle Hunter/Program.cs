using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Truffle_Hunter
{
    public class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            string[,] forest = new string[sizeOfMatrix, sizeOfMatrix];     

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                string[] rowArray = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    forest[row, col] = rowArray[col];
                }
            }

            int countBlack = 0;
            int countWhite = 0;
            int countSummer = 0;
            int countBoarTruffles = 0;
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] commandInfo = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string action = commandInfo[0];
                int rowInfo = int.Parse(commandInfo[1]);
                int colInfo = int.Parse(commandInfo[2]);

                if (action[0] == 'C')
                {
                    if (CheckCoordinates(forest, rowInfo, colInfo))
                    {
                        string nextPosition = forest[rowInfo, colInfo];

                        CountTruffles(ref countBlack, ref countWhite, ref countSummer, nextPosition);

                        forest[rowInfo, colInfo] = "-";
                    }
                }
                else if (action[0] == 'W')
                {
                    string direction = commandInfo[3];

                    if (forest[rowInfo, colInfo] != "-")
                    {
                        forest[rowInfo, colInfo] = "-";
                        countBoarTruffles++;
                    }

                    if (direction == "left")
                    {
                        while (colInfo >= 0)
                        {
                            colInfo -= 2;
                  
                            if (colInfo >= 0)
                            {
                                string nextPosition = forest[rowInfo, colInfo];
                  
                                if (nextPosition != "-")
                                {
                                    countBoarTruffles++;
                                    forest[rowInfo, colInfo] = "-";
                                }
                            }
                        }
                    }
                    else if (direction == "up")
                    {
                        while (rowInfo >= 0)
                        {
                            rowInfo -= 2;
                  
                            if (rowInfo >= 0)
                            {
                                string nextPosition = forest[rowInfo, colInfo];
                  
                                if (nextPosition != "-")
                                {
                                    countBoarTruffles++; 
                                    forest[rowInfo, colInfo] = "-";
                                }
                            }
                        }
                    }
                    else if (direction == "right")
                    {                      
                        while (colInfo < forest.GetLength(1))
                        {
                            colInfo += 2;
                  
                            if (colInfo < forest.GetLength(1))
                            {
                                string nextPosition = forest[rowInfo, colInfo];
                  
                                if (nextPosition != "-")
                                {
                                    countBoarTruffles++;
                                    forest[rowInfo, colInfo] = "-";
                                }
                            }
                        }                      
                    }
                    else if (direction == "down")
                    {
                        while (rowInfo < forest.GetLength(0))
                        {
                            rowInfo += 2;
                  
                            if (rowInfo < forest.GetLength(0))
                            {
                                string nextPosition = forest[rowInfo, colInfo];
                  
                                if (nextPosition != "-")
                                {
                                   countBoarTruffles++;
                                   forest[rowInfo, colInfo] = "-";
                                }
                            }
                        }
                    }                   
                }
            }

            Console.WriteLine($"Peter manages to harvest {countBlack} black, {countSummer} summer, and {countWhite} white truffles.");
            Console.WriteLine($"The wild boar has eaten {countBoarTruffles} truffles.");

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write($"{forest[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void CountTruffles(ref int countBlack, ref int countWhite, ref int countSummer, string nextPosition)
        {
            if (nextPosition != "-")
            {
                if (nextPosition == "B")
                {
                    countBlack++;
                }
                else if (nextPosition == "S")
                {
                    countSummer++;
                }
                else if (nextPosition == "W")
                {
                    countWhite++;
                }
            }
        }

        private static bool CheckCoordinates(string[,] forest, int rowInfo, int colInfo)
        {
            if (rowInfo >= 0 && rowInfo < forest.GetLength(0) &&
                colInfo >= 0 && colInfo < forest.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
