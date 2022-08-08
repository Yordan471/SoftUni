using System;

namespace MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
           for (int number = 1; number <= 10; number++)
            {
                for (int multiplicator = 1; multiplicator <= 10; multiplicator++)
                {
                    int result = number * multiplicator;
                    Console.WriteLine($"{number} * {multiplicator} = {result}");
                }
            }
        }
    }
}
