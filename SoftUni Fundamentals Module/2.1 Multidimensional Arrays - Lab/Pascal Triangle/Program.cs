using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] figure = new int[n][];

            for (int row = 0; row < n; row++)
            {
                figure[row] = new int[row + 1];
                figure[row][0] = 1;

                for (int col = 1; col < row; col++)
                {
                    figure[row][col] =
                        figure[row - 1][col - 1] +
                        figure[row - 1][col];
                }

                figure[row][row] = 1;
            }

            for (int row = 0; row < figure.Length; row++)
            {
                Console.WriteLine(string.Join(" ", figure[row]));
            }
        }
    }
}
