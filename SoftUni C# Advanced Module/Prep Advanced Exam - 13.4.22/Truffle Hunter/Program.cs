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

            Dictionary<string, int> PeterTrufflesNumber = new Dictionary<string, int>();
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
                        string truffle = string.Empty;

                        if (nextPosition != "-")
                        {
                            truffle = GetTruffle(nextPosition, truffle);
                            AddTruffle(PeterTrufflesNumber, truffle);
                        }
                        
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

            Console.WriteLine($"Peter manages to harvest {PeterTrufflesNumber["black"]} black, {PeterTrufflesNumber["summer"]} summer, and {PeterTrufflesNumber["white"]} white truffles.");
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

        private static string GetTruffle(string nextPosition, string truffle)
        {
            if (nextPosition == "B")
            {
                truffle = "black";
            }
            else if (nextPosition == "S")
            {
                truffle = "summer";
            }
            else if (nextPosition == "W")
            {
                truffle = "white";
            }

            return truffle;
        }

        private static void AddTruffle(Dictionary<string, int> PeterTrufflesNumber, string truffle)
        {

             if (!PeterTrufflesNumber.ContainsKey(truffle))
             {
                 PeterTrufflesNumber.Add(truffle, 0);
             }

             PeterTrufflesNumber[truffle]++;
                
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
