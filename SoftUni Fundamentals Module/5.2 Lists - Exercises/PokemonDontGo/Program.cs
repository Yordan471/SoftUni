using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> sumRemovedElements = new List<int>();

            while (numbers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    sumRemovedElements.Add(numbers[0]);
                    int currentNumber = numbers[0];

                    indexLessThenZero(ref numbers, index);
                  
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] > currentNumber)
                        {
                            numbers[i] -= currentNumber;
                        }
                        else
                        {
                            numbers[i] += currentNumber;
                        }
                    }
                }
                else if (index > numbers.Count - 1)
                {
                    sumRemovedElements.Add(numbers[numbers.Count - 1]);
                    int currentNumber = numbers[numbers.Count - 1];

                    IndexBiggerThenZero(ref numbers, index);
                 
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] > currentNumber)
                        {
                            numbers[i] -= currentNumber;
                        }
                        else
                        {
                            numbers[i] += currentNumber;
                        }
                    }
                }
                else
                {
                    sumRemovedElements.Add(numbers[index]);

                    IndexWithinNumbersCount(ref numbers, index);   
                }
            }

            Console.WriteLine(sumRemovedElements.Sum());
        }

        static List<int> indexLessThenZero(ref List<int> numbers, int index)
        {
            numbers.RemoveAt(0);
            numbers.Insert(0, numbers[numbers.Count - 1]);

            return numbers;
        }

        static List<int> IndexBiggerThenZero(ref List<int> numbers, int index)
        {
            numbers.RemoveAt(numbers.Count - 1);
            numbers.Insert(numbers.Count, numbers[0]);

            return numbers;
        }

        static List<int> IndexWithinNumbersCount(ref List<int> numbers, int index)
        {
            int currentNumber = numbers[index];
            numbers.RemoveAt(index);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > currentNumber)
                {
                    numbers[i] -= currentNumber;
                }
                else
                {
                    numbers[i] += currentNumber;
                }
            }

            return numbers;
        }
    }
}
