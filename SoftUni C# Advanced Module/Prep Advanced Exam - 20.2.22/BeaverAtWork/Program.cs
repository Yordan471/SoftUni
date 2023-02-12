using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfThePond = int.Parse(Console.ReadLine());

            char[,] pond = new char[sizeOfThePond, sizeOfThePond];

            int beaverRow = 0;
            int beaverCol = 0;
            int countBranches = 0;
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine()
                    .Split(' ')
                    .Select(x => char.Parse(x))
                    .ToArray();

                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row, col] = rowInput[col];

                    if (pond[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                        pond[row, col] = '-';
                    }

                    if (pond[row, col] >= 97 && pond[row, col] <= 122)
                    {
                        countBranches++;
                    }
                }             
            }

            List<string> collection = new List<string>();
            string command = string.Empty;

            while (countBranches != 0 && ((command = Console.ReadLine())!= "end"))
            {
                string position = command;
                bool outsideOfBoundaries = false;

                if (position == "left" && beaverCol - 1 >= 0)
                {
                    beaverCol--;
                }
                else if (position == "right" && beaverCol + 1 < pond.GetLength(1))
                {
                    beaverCol++;
                }
                else if (position == "up" && beaverRow - 1 >= 0)
                {
                    beaverRow--;
                }
                else if (position == "down" && beaverRow + 1 < pond.GetLength(0))
                {
                    beaverRow++;
                }
                else
                {
                    outsideOfBoundaries = true;
                }

                if (outsideOfBoundaries)
                {
                    if (collection.Any())
                    {
                        collection.Remove(collection[collection.Count - 1]);
                    }
                }
                else if (pond[beaverRow, beaverCol] >= 97 && pond[beaverRow, beaverCol] <= 122)
                {
                    countBranches--;
                    collection.Add(pond[beaverRow, beaverCol].ToString());
                    pond[beaverRow, beaverCol] = '-';
                }
                else if (pond[beaverRow, beaverCol] == 'F')
                {
                    pond[beaverRow, beaverCol] = '-';

                    if (position == "up")
                    {
                        if (beaverRow == 0)
                        {
                            if (char.IsLower(pond[pond.GetLength(0) - 1, beaverCol]))
                            {
                                collection.Add(pond[pond.GetLength(0) - 1, beaverCol].ToString());
                                countBranches--;
                            }
                            beaverRow = pond.GetLength(0) - 1;
                            //pond[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            if (char.IsLower(pond[0, beaverCol]))
                            {
                                collection.Add(pond[0, beaverCol].ToString());
                                countBranches--;
                            }
                            beaverRow = 0;
                           // pond[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else if (position == "down")
                    {
                        if (beaverRow == pond.GetLength(0) - 1)
                        {
                            if (char.IsLower(pond[0, beaverCol]))
                            {
                                collection.Add(pond[0, beaverCol].ToString());
                                countBranches--;
                            }
                            beaverRow = 0;
                           // pond[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            if (char.IsLower(pond[pond.GetLength(0) - 1, beaverCol]))
                            {
                                collection.Add(pond[pond.GetLength(0) - 1, beaverCol].ToString());
                                countBranches--;
                            }
                            beaverRow = pond.GetLength(0) - 1;
                            //pond[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else if (position == "right")
                    {
                        if (beaverCol == pond.GetLength(1) - 1)
                        {
                            if (char.IsLower(pond[beaverRow, 0]))
                            {
                                collection.Add(pond[beaverRow, 0].ToString());
                                countBranches--;
                            }
                            beaverCol = 0;
                            //pond[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            if (char.IsLower(pond[beaverRow, pond.GetLength(1) - 1]))
                            {
                                collection.Add(pond[beaverRow, pond.GetLength(1) - 1].ToString());
                                countBranches--;
                            }
                            beaverCol = pond.GetLength(1) - 1;
                            //pond[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else if (position == "left")
                    {
                        if (beaverCol == 0)
                        {
                            if (char.IsLower(pond[beaverRow, pond.GetLength(1) - 1]))
                            {
                                collection.Add(pond[beaverRow, pond.GetLength(1) - 1].ToString());
                                countBranches--;
                            }
                            beaverCol = pond.GetLength(1) - 1;
                           // pond[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            if (char.IsLower(pond[beaverRow, 0]))
                            {
                                collection.Add(pond[beaverRow, 0].ToString());
                                countBranches--;
                            }
                            beaverCol = 0;
                            //pond[beaverRow, beaverCol] = 'B';
                        }
                    }

                    // pond[beaverRow, beaverCol] = '-';
                    //
                    // if (beaverCol == pond.GetLength(1) - 1)
                    // {
                    //     if (beaverRow == 0 || beaverRow == pond.GetLength(0) - 1)
                    //     {
                    //         GoToTheEndOfTheRowReverse(position, ref beaverRow, ref beaverCol, pond);
                    //     }
                    //     else
                    //     {
                    //         beaverCol = 0;
                    //     }                     
                    // }
                    // else if (beaverCol == 0)
                    // {
                    //     if (beaverRow == pond.GetLength(0) - 1 || beaverRow == 0)
                    //     {
                    //         GoToTheEndOfTheRowReverse(position, ref beaverRow, ref beaverCol, pond);
                    //     }
                    //     else
                    //     {
                    //         beaverCol = pond.GetLength(1) - 1;
                    //     }                 
                    // }
                    // else if (beaverRow == pond.GetLength(0) - 1)
                    // {
                    //     if (beaverCol == 0 || beaverCol == pond.GetLength(1))
                    //     {
                    //         GoToTheEndOfTheRowReverse(position, ref beaverRow, ref beaverCol, pond);
                    //     }
                    //     else
                    //     {
                    //         beaverRow = 0;
                    //     }                       
                    // }
                    // else if (beaverRow == 0)
                    // {
                    //     if (beaverCol == pond.GetLength(1) - 1 || beaverCol == 0)
                    //     {
                    //         GoToTheEndOfTheRowReverse(position, ref beaverRow, ref beaverCol, pond);
                    //     }
                    //     else
                    //     {
                    //         beaverRow = pond.GetLength(0) - 1;
                    //     }                       
                    // }
                    // else
                    // {
                    //     GoToTheEndOfTheRow(position, ref beaverRow, ref beaverCol, pond);
                    // }
                    //
                    // if (pond[beaverRow, beaverCol] >= 97 && pond[beaverRow, beaverCol] <= 122)
                    // {
                    //     collection.Add(pond[beaverRow, beaverCol].ToString());
                    //     countBranches--;
                    //     pond[beaverRow, beaverCol] = '-';
                    // }
                }               
            }

            pond[beaverRow, beaverCol] = 'B';

            if (countBranches == 0)
            {
                Console.Write($"The Beaver successfully collect {collection.Count} wood branches: ");

                if (collection.Count > 0 && collection[0] != string.Empty)
                {
                    Console.WriteLine($"{string.Join(", ", collection)}.");
                }
                
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countBranches} branches left.");
            }

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col  = 0; col  < pond.GetLength(1); col ++)
                {
                    Console.Write($"{pond[row, col]} "); 
                }

                Console.WriteLine();
            }
        }

        private static void GoToTheEndOfTheRow(string position, ref int beaverRow, ref int beaverCol, char[,] pond)
        {
            if (position == "left")
            {
                beaverCol = 0;
            }
            else if (position == "right")
            {
                beaverCol = pond.GetLength(1) - 1;
            }
            else if (position == "up")
            {
                beaverRow = 0;
            }
            else if (position == "down")
            {
                beaverRow = pond.GetLength(0) - 1;
            }
        }

        private static void GoToTheEndOfTheRowReverse(string position, ref int beaverRow, ref int beaverCol, char[,] pond)
        {
            if (position == "left")
            {
                beaverCol = pond.GetLength(1) - 1;
            }
            else if (position == "right")
            {
                beaverCol = 0;
            }
            else if (position == "up")
            {
                beaverRow = pond.GetLength(0) - 1;
            }
            else if (position == "down")
            {
                beaverRow = 0;
            }
        }
    }
}
