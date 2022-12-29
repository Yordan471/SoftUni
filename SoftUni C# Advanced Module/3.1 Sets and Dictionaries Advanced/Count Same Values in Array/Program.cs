using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(' ');

            Dictionary<string, int> numbersAndCount = new Dictionary<string, int>();

            foreach (string number in numbers)
            {
                if (!(numbersAndCount.ContainsKey(number)))
                {
                    numbersAndCount.Add(number, 0);
                }

                numbersAndCount[number] += 1;
            }

            foreach (KeyValuePair<string, int> pair in numbersAndCount)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
