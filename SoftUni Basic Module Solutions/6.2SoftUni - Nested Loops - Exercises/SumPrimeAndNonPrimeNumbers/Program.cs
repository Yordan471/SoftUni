using System;

namespace SumPrimeAndNonPrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            int compundSum = 0;
            int primeSum = 0;

            while (command != "stop")
            {
                command = Console.ReadLine(); // expect string numbers and "stop"

                if (command == "stop")
                {
                    break;
                }

                int num = int.Parse(command); // string numbers to int numbers

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                bool numIsPrime = true;

                for (int divider = 2; divider < num; divider++)
                {
                    int remainder = num % divider;

                    if (remainder == 0)
                    {
                        compundSum += num;
                        numIsPrime = false;// 
                        break;
                    }
                }

                if (numIsPrime)
                {
                    primeSum += num;
                }              
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {compundSum}");
        }
    }
}
