using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> saveNewNumbers = new List<int>();

            for (int i = 0; i <= numbers.Count / 2; i++)
            {
                if (numbers.Count % 2 != 0)
                {
                    if (i == numbers.Count / 2)
                    {
                        saveNewNumbers.Add(numbers[numbers.Count / 2]);
                        break;
                    }

                    saveNewNumbers.Add(numbers[(0 + i)] + numbers[numbers.Count - 1 - i]);
                }
                else
                {
                    if (i == numbers.Count / 2)
                    {
                        break;
                    }

                    saveNewNumbers.Add(numbers[(0 + i)] + numbers[numbers.Count - 1 - i]);
                }
            }

            Console.WriteLine(String.Join(" ", saveNewNumbers));
        }
    }
}
