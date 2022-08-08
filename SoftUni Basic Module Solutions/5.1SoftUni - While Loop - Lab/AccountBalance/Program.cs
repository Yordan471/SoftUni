using System;

namespace AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string deposit = Console.ReadLine();
            double sum = 0.0;

            while (deposit != "NoMoreMoney")
            {
                double amount = double.Parse(deposit);

                if (amount < 0)
                {
                    Console.WriteLine($"Invalid operation!");
                    break;
                }
                sum += amount;

                Console.WriteLine($"Increase: {amount:F2}");
                deposit = Console.ReadLine();
            }

            Console.WriteLine($"Total: {sum:F2}");
        }
    }
}
