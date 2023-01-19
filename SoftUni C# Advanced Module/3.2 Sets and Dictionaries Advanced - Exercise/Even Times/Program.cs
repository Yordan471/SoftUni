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

            Dictionary<int, int> numbersAndCounts = new 
                Dictionary<int, int>();

            for (int i = 0; i < numberOfIntegers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbersAndCounts.ContainsKey(number))
                {
                    numbersAndCounts.Add(number, 0 );
                }

                numbersAndCounts[number]++;
            }
            // Single method returns if there is only one element as count
            // else fals
            Console.WriteLine(numbersAndCounts.Single(x => x.Value % 2 == 0).Key);
            

          //  HashSet<int> numbers = new HashSet<int>();
          //  HashSet<int> saveNumbers = new HashSet<int>();
          //
          //  for (int i = 0; i < numberOfIntegers; i++)
          //  {
          //      int number = int.Parse(Console.ReadLine());
          //
          //      if (!(numbers.Contains(number)))
          //      {
          //          numbers.Add(number);
          //      }
          //      else
          //      {                    
          //          if (saveNumbers.Contains(number))
          //          {
          //              saveNumbers.Remove(number);
          //          }
          //          else
          //          {
          //              saveNumbers.Add(number);
          //          }                   
          //      }               
          //  }
          //
          //  Console.WriteLine(string.Join("", saveNumbers));
        }
    }
}
