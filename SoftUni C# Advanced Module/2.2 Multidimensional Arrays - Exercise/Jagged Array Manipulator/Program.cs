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
                int[] rowArray = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < rowArray.Length; col++)
                {
                    jagged[row][col] = rowArray[col];
                }
            }

            
        }
    }
}
