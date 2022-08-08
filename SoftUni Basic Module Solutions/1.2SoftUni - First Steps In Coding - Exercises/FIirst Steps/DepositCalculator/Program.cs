using System;

namespace DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            double depositSum = double.Parse(Console.ReadLine());

            Console.WriteLine(" ");
            int time = int.Parse(Console.ReadLine());

            Console.WriteLine(" ");
            double annual = double.Parse(Console.ReadLine());

            double totalSum = depositSum + time * ((depositSum * (annual / 100)) / 12);

            Console.WriteLine(totalSum);
        }
    }
}
