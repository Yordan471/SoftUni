using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcdeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            int firstNumberBeginning = numberOne / 1000;
            int firstNumberEnding = numberTwo / 1000;
            int secondNumberStart = (numberOne / 100) % 10;
            int secondNumberEnding = (numberTwo / 100) % 10;
            int thirdNumberStart = (numberOne % 100) / 10;
            int thirdNumberEnding = (numberTwo % 100) / 10;
            int fourthNumberStart = numberOne % 10;
            int fourthNumberEnding = numberTwo % 10;

            for (int i = firstNumberBeginning; i <= firstNumberEnding; i++)
            {
                if (i % 2 != 0)
                {

                    for (int j = secondNumberStart; j <= secondNumberEnding; j++)
                    {

                        if (j % 2 != 0)
                        {

                            for (int k = thirdNumberStart; k <= thirdNumberEnding; k++)
                            {
                                if (k % 2 != 0)
                                {

                                    for (int l = fourthNumberStart; l <= fourthNumberEnding; l++)
                                    {
                                        if (l % 2 != 0)
                                        {
                                            Console.Write($"{i}{j}{k}{l} ");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }            
            }
        }
    }
}
