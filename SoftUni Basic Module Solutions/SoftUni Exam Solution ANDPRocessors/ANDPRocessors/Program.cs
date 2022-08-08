using System;

namespace ANDPRocessors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPocessorsToBeMade = int.Parse(Console.ReadLine());
            int numEmployees = int.Parse(Console.ReadLine());
            int workDays = int.Parse(Console.ReadLine());

            int makingProcessorTime = 3;
            double priceForOneProcessor = 110.10;

            int allWorkedHours = numEmployees * workDays * 8;
            double processorsMade = Math.Floor(allWorkedHours * 1.0 / makingProcessorTime);

            if (processorsMade < numPocessorsToBeMade)
            {
                double processorsLess = numPocessorsToBeMade - processorsMade;
                double moneyLost = processorsLess * priceForOneProcessor;
                Console.WriteLine($"Losses: -> {moneyLost:f2} BGN");
            }
            else
            {
                double processorsMore = processorsMade - numPocessorsToBeMade;
                double moneyEarned = processorsMore * priceForOneProcessor;
                Console.WriteLine($"Profit: -> {moneyEarned:f2} BGN");
            }
        }
    }
}
