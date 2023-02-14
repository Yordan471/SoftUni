using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfArmory = int.Parse(Console.ReadLine());

            string[,] armory = new string[sizeOfArmory, sizeOfArmory];
            int officerRow = 0;
            int officerCol = 0;
            int firstMRow = 0;
            int firstMCol = 0;
            int secondMRow = 0;
            int secondMCol = 0;
            int count = 0;

            for (int row = 0; row < armory.GetLength(0); row++)
            {
                string rowInput = Console.ReadLine();

                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    armory[row, col] = rowInput[col].ToString();

                    if (armory[row, col] == "A")
                    {
                        officerRow = row;
                        officerCol = col;
                        armory[row, col] = "-";
                    }

                    if (armory[row, col] == "M" && count == 0)
                    {
                        count++;
                        firstMRow = row;
                        firstMCol = col;
                    }
                    else if (armory[row, col] == "M" && count == 1)
                    {
                        secondMRow = row;
                        secondMCol = col;
                    }
                }
            }

            int gold = 0;
            int kingsGold = 65;
            string command = string.Empty;
            bool outOfAmory = false;

            while (gold < kingsGold && (command = Console.ReadLine()) != null)
            {
                string position = command;

                if (position == "left" && officerCol - 1 >= 0)
                {
                    officerCol--;
                }
                else if (position == "right" && officerCol + 1 < armory.GetLength(1))
                {
                    officerCol++;
                }
                else if (position == "up" && officerRow - 1 >= 0)
                {
                    officerRow--;
                }
                else if (position == "down" && officerRow + 1 < armory.GetLength(0))
                {
                    officerRow++;
                }
                else
                {
                    outOfAmory = true;
                    armory[officerRow, officerCol] = "-";
                    break;
                }

                if (armory[officerRow, officerCol] == "M")
                {
                    armory[officerRow, officerCol] = "-";

                    if (officerRow == firstMRow && officerCol == firstMCol)
                    {
                        officerRow = secondMRow;
                        officerCol = secondMCol;
                    }
                    else
                    {
                        officerRow = firstMRow;
                        officerCol = firstMCol;
                    }

                    armory[officerRow, officerCol] = "-";
                }
                else if (armory[officerRow, officerCol] != "-")
                {
                    gold += int.Parse(armory[officerRow, officerCol]);
                    armory[officerRow, officerCol] = "-";
                }
            }

            if (outOfAmory)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                armory[officerRow, officerCol] = "A";
                Console.WriteLine($"Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {gold} gold coins.");

            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write($"{armory[row, col]}"); 
                }

                Console.WriteLine();
            }
        }
    }
}
