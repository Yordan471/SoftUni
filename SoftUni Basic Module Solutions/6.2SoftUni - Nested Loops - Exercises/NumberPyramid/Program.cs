using System;

namespace NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currPrintedNums = 1;
            bool isBigger = false;

            for (int rows = 1; rows <= n; rows++) // rows to be printed
            {
              
               for (int cols = 1; cols <= rows; cols++) //numbers to be printed for a row
                {
                    if (currPrintedNums > n)
                    {
                        isBigger = true;
                        break;
                    }

                    Console.Write(currPrintedNums + " ");
                    currPrintedNums++;
                }

               if (isBigger)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
