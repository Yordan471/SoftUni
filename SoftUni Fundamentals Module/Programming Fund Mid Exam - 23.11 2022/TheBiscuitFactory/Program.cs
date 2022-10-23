using System;
using System.Security.Cryptography;

namespace TheBiscuitFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numberOfBiscuitsPerWorker = int.Parse(Console.ReadLine());
            double countOfWorkersInFactory = int.Parse(Console.ReadLine());
            double numberOfBiscutsCompFactory = int.Parse(Console.ReadLine());
            double saveNumberOfBiscuits = numberOfBiscuitsPerWorker;

            double producedBiscutsPerDay = 0;
            long producedBiscuitsForMonth = 0;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    numberOfBiscuitsPerWorker *= 0.75;
                }

                producedBiscutsPerDay = Math.Floor(numberOfBiscuitsPerWorker * countOfWorkersInFactory);
                producedBiscuitsForMonth += Convert.ToInt64(producedBiscutsPerDay);
                numberOfBiscuitsPerWorker = saveNumberOfBiscuits;
            }

            Console.WriteLine($"You have produced {producedBiscuitsForMonth} biscuits for the past month.");

            double productionDiff = Math.Abs(producedBiscuitsForMonth - numberOfBiscutsCompFactory);
            double prcntgDiff = 100 * productionDiff / numberOfBiscutsCompFactory;
            
            if (producedBiscuitsForMonth > numberOfBiscutsCompFactory)
            {
                Console.WriteLine($"You produce {prcntgDiff:f2} percent more biscuits.");
            }
            else if (producedBiscuitsForMonth < numberOfBiscutsCompFactory)
            {
                productionDiff = Math.Abs(productionDiff);
                Console.WriteLine($"You produce {prcntgDiff:f2} percent less biscuits.");
            }
        }
                    
    }
}
