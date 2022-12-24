using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[,] squareMatrix = new char[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                string characters = Console.ReadLine();

                char[] rowArray = characters.ToCharArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    squareMatrix[row, col] = rowArray[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool foundSymbol = false;
            bool notFoundSymbol = true;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    if (symbol == squareMatrix[row, col])
                    {
                        Console.WriteLine($"({row}, {col})");
                        notFoundSymbol = false;
                        foundSymbol = true;
                        break;
                    }
                }

                if (foundSymbol)
                {
                    break;
                }
            }

            if (notFoundSymbol)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
