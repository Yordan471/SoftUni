using System;

namespace MovieProfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            int prcntgTheater = int.Parse(Console.ReadLine());

            double income = days * (tickets * ticketPrice);
            double incomeForTheater = income * (prcntgTheater * 1.0 / 100);
            double overallIncome = income - incomeForTheater;

            Console.WriteLine($"The profit from the movie {movieName} is {overallIncome:f2} lv.");
        }
    }
}
