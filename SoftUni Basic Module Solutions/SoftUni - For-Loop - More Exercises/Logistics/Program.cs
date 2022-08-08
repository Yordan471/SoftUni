using System;

namespace Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int load = int.Parse(Console.ReadLine());
            int sum = 0;
            int allTons = 0;
            int microBus = 0; int microBusTons = 0;
            int truck = 0;    int truckTons = 0;
            int train = 0;    int trainTons = 0;

            for (int i = 1; i <= load; i++)
            {
                int loadTons = int.Parse(Console.ReadLine());

                allTons += loadTons;
                if (loadTons <= 3)
                {
                    microBusTons += loadTons;
                    microBus++;
                    sum += 3 * loadTons;
                }
                else if (loadTons >= 4 && loadTons <= 11)
                {
                    truckTons += loadTons;
                    truck++;
                    sum += loadTons * 175;
                }
                else if (loadTons >= 12)
                {
                    trainTons += loadTons;
                    train++;
                    sum += loadTons * 120;
                }
            }
            double averageValue = (microBusTons * 200 + truckTons * 175 + trainTons * 120) * 1.0 / allTons;
            Console.WriteLine($"{averageValue:f2}");

            double procentTonMicroBus = (microBusTons * 1.0 / allTons * 1.0) * 100;
            Console.WriteLine($"{procentTonMicroBus:f2}%");

            double procentTonTruck = (truckTons * 1.0 / allTons * 1.0) * 100;
            Console.WriteLine($"{procentTonTruck:f2}%");

            double procentTonTrain = (trainTons * 1.0 / allTons * 1.0) * 100;
            Console.WriteLine($"{procentTonTrain:f2}%");
        }
    }
}
