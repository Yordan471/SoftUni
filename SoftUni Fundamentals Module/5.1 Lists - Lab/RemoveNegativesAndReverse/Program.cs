using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> newList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
                else
                {
                    newList.Add(numbers[i]);
                }
            }

            if (newList.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                newList.Reverse();

                Console.WriteLine(String.Join(" ", newList));
            }
        }
    }
}
