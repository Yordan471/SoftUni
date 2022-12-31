using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfIntegers = int.Parse(Console.ReadLine());

            HashSet<int> numbers = new HashSet<int>();
            HashSet<int> saveNumbers = new HashSet<int>();

            for (int i = 0; i < numberOfIntegers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!(numbers.Contains(number)))
                {
                    numbers.Add(number);
                }
                else
                {                    
                    if (saveNumbers.Contains(number))
                    {
                        saveNumbers.Remove(number);
                    }
                    else
                    {
                        saveNumbers.Add(number);
                    }                   
                }               
            }

            Console.WriteLine(string.Join("", saveNumbers));
        }
    }
}
