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
                    int liters = que[0];
                    int distance = que[1];

                    litersLeft += liters;

                    if (litersLeft - distance < 0)
                    {
                        int[] currPump = pumps.Dequeue();
                        pumps.Enqueue(currPump);
                        countPumps++;
                        circleIsComplete = false;
                        break;
                    }

                    litersLeft -= distance;
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
