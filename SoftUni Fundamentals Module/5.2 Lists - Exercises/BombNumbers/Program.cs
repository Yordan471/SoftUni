using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> bombNumberAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int bombNumber = bombNumberAndPower[0];
            int power = bombNumberAndPower[1];

            for (int i = 0; i < sequenceOfNumbers.Count; i++)
            {
                if (sequenceOfNumbers[i] == bombNumber)
                {
                    for (int j = 0; j < power;  j++)
                    {
                        if (i == 0)
                        {
                            break;
                        }
                        else
                        {
                            // изаждаме -1 защото взимаме числото преди бомбата
                            if (i - 1 < 0)
                            {
                                sequenceOfNumbers.RemoveAt(0);
                            }
                            else
                            {
                               sequenceOfNumbers.RemoveAt(i - 1);
                                // намаляме с i-- защото индекса на бомбата се променя
                               i--;
                            }                     
                        }
                    }

                    for (int j = 0; j < power; j++)
                    {
                        if (i == sequenceOfNumbers.Count - 1)
                        {
                            break;                       
                        }
                        else
                        {
                            // увеличаваме с +1 защото взимаме числото след бомбата
                            if (i + 1 > sequenceOfNumbers.Count - 1)
                            {
                                break;
                            }
                            else
                            {                              
                                sequenceOfNumbers.RemoveAt(i + 1);
                                // тук ненамалям с i-- защото индекса на бомбата не се променя
                            }
                        }
                    }
                    // Премахвам бомбата
                    sequenceOfNumbers.RemoveAt(i);
                    // съответно намалям i
                    i--;
                }
            }

            int sum = 0;

            for (int i = 0; i < sequenceOfNumbers.Count; i++)
            {
                sum += sequenceOfNumbers[i];
            }

            Console.WriteLine(sum);
        }
    }
}
