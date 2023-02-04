using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDestroyer
{
    public class Program
    {
        static void Main(string[] args)
        {
            int wallSize = int.Parse(Console.ReadLine());

            string[,] wall = new string[wallSize, wallSize];
            int saveRow = 0;
            int saveCol = 0;    

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


        }
    }
}
