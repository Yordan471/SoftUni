using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberPetrolPumps = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int petrolPump = 0; petrolPump < numberPetrolPumps; petrolPump++)
            {
                int[] petrolPumpInfo = Console.ReadLine()
                    .Split()
                    .Select(x => int.Parse(x))
                    .ToArray();

                pumps.Enqueue(petrolPumpInfo);
            }

            int countPumps = 0;

            while (true)
            {
                int litersLeft = 0;
                bool circleIsComplete = true;

                foreach (int[] que in pumps)
                {
                    litersLeft += que

                    if (litersLeft - distanceToNextPump.Peek() < 0)
                    {
                        int petrolLiters = amountOfPetrol.Dequeue();
                        int distance = distanceToNextPump.Dequeue();
                        amountOfPetrol.Enqueue(petrolLiters);
                        distanceToNextPump.Enqueue(distance);
                        countPumps++;
                        circleIsComplete = false;
                        break;
                    }

                    litersLeft -= distanceToNextPump.Peek();
                }

                if (circleIsComplete)
                {
                    Console.WriteLine(countPumps);
                    break;
                }
            }
        }
    }
}
