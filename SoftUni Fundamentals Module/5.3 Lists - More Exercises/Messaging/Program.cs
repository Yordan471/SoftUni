using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            string aString = Console.ReadLine();

            List<char> aStringToChar = new List<char>(aString);
            int sumDigits = 0;
            string stringOutput = string.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                int saveNumber = numbers[i];

                while (saveNumber != 0)
                {
                    sumDigits += saveNumber % 10;
                    saveNumber /= 10;
                }

                if (sumDigits > aStringToChar.Count)
                {
                    while (sumDigits > aStringToChar.Count)
                    {
                        sumDigits -= aStringToChar.Count;
                    }

                    stringOutput += aStringToChar[sumDigits];
                    aStringToChar.RemoveAt(sumDigits);
                }
                else
                {
                    stringOutput += aStringToChar[sumDigits];
                    aStringToChar.RemoveAt(sumDigits);
                }

                sumDigits = 0;
            }

            Console.WriteLine(stringOutput); 
        }
    }
}
