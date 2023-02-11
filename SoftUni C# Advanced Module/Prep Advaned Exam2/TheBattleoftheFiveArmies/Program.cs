using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBattleoftheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            string[][] mapOfMordor = new string[numberOfRows][];
            int armyRow = 0;
            int armyCol = 0;

            ReadMapOfMordor(mapOfMordor, ref armyRow, ref armyCol);

            string command = string.Empty;
            bool winWar = false;
            bool armyIsDead = false;

            while ((command = Console.ReadLine()) != null)
            {
                string[] spawnAndPosition = command
                    .Split(' ');

                string position = spawnAndPosition[0];
                int orcsRow = int.Parse(spawnAndPosition[1]);
                int orcsCol = int.Parse(spawnAndPosition[2]);

                mapOfMordor[orcsRow][orcsCol] = "O";

                if (position == "left")
                {
                    if (ChechBoundaries(mapOfMordor ,armyRow, armyCol - 1))
                    {
                        //mapOfMordor[armyRow][armyCol] = "-";
                        armyCol--;
                    }                   
                }
                else if (position == "right")
                {
                    if (ChechBoundaries(mapOfMordor, armyRow, armyCol + 1))
                    {
                        //mapOfMordor[armyRow][armyCol] = "-";
                        armyCol++;
                    }
                }
                else if (position == "up")
                {
                    if (ChechBoundaries(mapOfMordor, armyRow - 1, armyCol))
                    {
                        //mapOfMordor[armyRow][armyCol] = "-";
                        armyRow--;
                    }
                }
                else if (position == "down")
                {
                    if (ChechBoundaries(mapOfMordor, armyRow + 1, armyCol))
                    {
                        //mapOfMordor[armyRow][armyCol] = "-";
                        armyRow++;
                    }
                }

                //mapOfMordor[armyRow][armyCol] = "A";
                armyArmor--;
                

                if (mapOfMordor[armyRow][armyCol] == "O")
                {
                    armyArmor -= 2;

                    if (armyArmor <= 0)
                    {
                        mapOfMordor[armyRow][armyCol] = "X";
                        armyIsDead = true;
                       //PrintMapOfMordor(mapOfMordor);
                        break;
                    }

                    mapOfMordor[armyRow][armyCol] = "-";
                    //PrintMapOfMordor(mapOfMordor);
                    continue;
                }
                else if (mapOfMordor[armyRow][armyCol] == "M")
                {
                    winWar = true;
                    mapOfMordor[armyRow][armyCol] = "-";
                    break;
                }

                if (armyArmor <= 0)
                {
                    armyIsDead = true;
                    mapOfMordor[armyRow][armyCol] = "X";
                    break;
                }

                //PrintMapOfMordor(mapOfMordor);
            }

            if (winWar)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
            }
            else if (armyIsDead)
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

            PrintMapOfMordor(mapOfMordor);
        }

        private static bool ChechBoundaries(string[][] mapOfMordor, int armyRow, int armyCol)
        {
            if (armyRow >= 0 && armyRow < mapOfMordor.GetLength(0) && armyCol >= 0 && armyCol < mapOfMordor[armyRow].Length)
            {
                return true;
            }

            return false;
        }

        private static void ReadMapOfMordor(string[][] mapOfMordor, ref int armyRow, ref int armyCol)
        {
            for (int row = 0; row < mapOfMordor.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                mapOfMordor[row] = new string[rowInput.Length];

                for (int col = 0; col < rowInput.Length; col++)
                {
                    mapOfMordor[row][col] = rowInput[col].ToString();

                    if (mapOfMordor[row][col] == "A")
                    {
                        armyRow = row;
                        armyCol = col;
                        mapOfMordor[row][col] = "-";
                    }
                }
            }
        }

        private static void PrintMapOfMordor(string[][] mapOfMordor)
        {
            foreach (string[] row in mapOfMordor)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
