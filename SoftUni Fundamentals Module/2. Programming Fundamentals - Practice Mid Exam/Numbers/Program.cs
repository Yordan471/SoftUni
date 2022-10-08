using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfIntegers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            for (int i = 0; i < listOfIntegers.Count; i++)
            {
                sum += listOfIntegers[i];
            }

            int counterForNumbersBiggerThanAvrgSum = 0;
            List<int> reverseNumbers = new List<int>();
            double avrgNumber = sum * 1.0 / listOfIntegers.Count;

            for (int i = 0; i < listOfIntegers.Count; i++)
            {
                if (listOfIntegers[i] > avrgNumber)
                {                                       
                        reverseNumbers.Add(listOfIntegers[i]);                                      
                }
            }

            if (reverseNumbers.Count > 0)
            {
                reverseNumbers.Sort();
                reverseNumbers.Reverse();

                for (int i = 0; i < reverseNumbers.Count; i++)
                {
                    if (counterForNumbersBiggerThanAvrgSum < 5)
                    {
                        Console.Write($"{reverseNumbers[i]} ");
                    }

                    counterForNumbersBiggerThanAvrgSum++;
                }

            }
            else
            {
               Console.WriteLine("No");
            }                             
        }
    }
}
