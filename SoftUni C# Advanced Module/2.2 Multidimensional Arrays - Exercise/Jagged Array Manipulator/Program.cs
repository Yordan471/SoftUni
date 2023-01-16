using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                jagged[row] = Console.ReadLine()
                    .Split(' ')
                    .Select(x =>int.Parse(x))
                    .ToArray();
            }

            for (int row = 0; row < jagged.Length - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    if (jagged[row].Length != jagged[row + 1].Length)
                    {
                        for (int col = 0; col < jagged[row].Length; col++)
                        {
                            jagged[row][col] /= 2;
                        }

                        for (int col1 = 0; col1 < jagged[row + 1].Length; col1++)
                        {
                            jagged[row + 1][col1] /= 2;
                        }
                    }
                }
            }

            string command = string.Empty;
            bool end = false;

            while (true)
            {
                string[] commandToArray = Console.ReadLine()
                    .Split()
                    .ToArray();

                string operation = commandToArray[0];

                if (operation == "End")
                {                   
                    end = true;
                    break;
                }

                int rowIndex = int.Parse(commandToArray[1]);
                int columnIndex = int.Parse(commandToArray[2]);
                int value = int.Parse(commandToArray[3]);

                if (rowIndex >= 0 && rowIndex < jagged.GetLength(0) &&
                    columnIndex >= 0 && columnIndex < jagged[rowIndex].Length)
                {
                    if (operation == "Add")
                    {
                        jagged[rowIndex][columnIndex] += value;
                    }
                    else if (operation == "Subtract")
                    {
                        jagged[rowIndex][columnIndex] -= value;
                    }
                }
            }

            if (end)
            {
                for (int row = 0; row < jagged.GetLength(0); row++)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        Console.Write($"{jagged[row][col]} ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
