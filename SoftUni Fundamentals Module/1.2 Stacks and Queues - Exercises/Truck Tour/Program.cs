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
            int numberOfPetrolPumps = int.Parse(Console.ReadLine());

            Queue<int> lPetrol = new Queue<int>();
            int lastStop = 0;

            for (int i = 0; i < numberOfPetrolPumps; i++)
            {
                int[] integers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                int amountOfPetrol = integers[0];
                int distance = integers[1];               

                if (amountOfPetrol >= distance)
                {
                    if (amountOfPetrol > lastStop)
                    {
                        lPetrol.Enqueue(amountOfPetrol);
                    }
                    else
                    {
                        
                    }
                    
                    
                }



            }
        }
    }
}
