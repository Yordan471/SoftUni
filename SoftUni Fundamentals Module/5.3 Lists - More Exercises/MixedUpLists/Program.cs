using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedUpLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstListNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondListNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> mixedList = new List<int>();

            for (int i = 0; i < Math.Min(firstListNumbers.Count, secondListNumbers.Count); i++)
            {
                if (firstListNumbers.Count > secondListNumbers.Count)
                {
                    
                    mixedList.Add(firstListNumbers[i]);
                    mixedList.Add(secondListNumbers[secondListNumbers.Count - 1 - i]);
                }
                else
                {
                    mixedList.Add(firstListNumbers[i]);
                    mixedList.Add(secondListNumbers[secondListNumbers.Count - 1 - i]);
                }         
            }

            List<int> numbersInRange = new List<int>();

            if (firstListNumbers.Count > secondListNumbers.Count)
            {
                if (firstListNumbers[firstListNumbers.Count - 1] > firstListNumbers[firstListNumbers.Count - 2])
                {
                    for (int i = 0; i < mixedList.Count; i++)
                    {
                        if (mixedList[i] < firstListNumbers[firstListNumbers.Count - 1] && mixedList[i] > firstListNumbers[firstListNumbers.Count - 2])
                        {
                            numbersInRange.Add(mixedList[i]);
                        }                   
                    }                 
                }
                else
                {
                    for (int i = 0; i < mixedList.Count; i++)
                    {
                        if (mixedList[i] > firstListNumbers[firstListNumbers.Count - 1] && mixedList[i] < firstListNumbers[firstListNumbers.Count - 2])
                        {
                            numbersInRange.Add(mixedList[i]);
                        }
                    }
                }
            }
            else if (firstListNumbers.Count < secondListNumbers.Count)
            {
                if (secondListNumbers[0] > secondListNumbers[1])
                {
                    for (int i = 0; i < mixedList.Count; i++)
                    {
                        if (mixedList[i] < secondListNumbers[0] && mixedList[i] > secondListNumbers[1])
                        {
                            numbersInRange.Add(mixedList[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < mixedList.Count; i++)
                    {
                        if (mixedList[i] > secondListNumbers[0] && mixedList[i] < secondListNumbers[1])
                        {
                            numbersInRange.Add(mixedList[i]);
                        }
                    }
                }
            }

            numbersInRange.Sort();
            Console.WriteLine(String.Join(" ", numbersInRange));
        }
    }
}
