using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            if (numberOfRows == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(1);
                Console.WriteLine($"1 1");

                int[] currentArray = { 1, 1 };

                for (int i = 3; i <= numberOfRows; i++)
                {
                    int[] row = new int[i];
                    row[0] = 1;

                    for (int j = 1; j < row.Length - 1; j++)
                    {
                        row[j] = currentArray[j - 1] + currentArray[j];
                        row[j + 1] = 1;
                    }

                    currentArray = row;
                    Console.WriteLine(String.Join(" ", currentArray));
                }
            }          
        }
    }
}
