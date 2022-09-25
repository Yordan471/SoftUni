using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sNumber = Console.ReadLine();
            int number = int.Parse(sNumber);
            int saveNumber = number;

            int sum = 1;
            int saveSum = 0;
                
            while (number > 0)
            {
                int numberCopy = number % 10;
                number /= 10;

                for (int j = 2; j <= numberCopy; j++)
                {
                    sum *= j;
                }

                saveSum += sum;
                sum = 1;
            }
      
            if (saveSum == saveNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
