using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = ReadJaggedArrayFromConsole(rows);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commands = command
                    .Split(' ');

                string operation = commands[0];
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (operation == "Add")
                {
                    AddValue(rows, jagged, row, col, value);
                }
                else if (operation == "Subtract")
                {
                    SubtractValue(rows, jagged, row, col, value);
                }
            }

            foreach (int[] row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static int[][] ReadJaggedArrayFromConsole(int rows)
        {
            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jagged[row] = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            }

            return jagged;
        }

        private static void AddValue(int rows, int[][] jagged, int row, int col, int value)
        {
            if (row >= 0 && row <= rows - 1 &&
                col >= 0 && col <= jagged.Length - 1)
            {
                jagged[row][col] += value;
            }
            else
            {
                Console.WriteLine("Invalid coordinates");
            }
        }

        private static void SubtractValue(int rows, int[][] jagged, int row, int col, int value)
        {
            if (row >= 0 && row <= rows - 1 &&
                col >= 0 && col <= jagged.Length - 1)
            {
                jagged[row][col] -= value;
            }
            else
            {
                Console.WriteLine("Invalid coordinates");
            }
        }
    }
}
