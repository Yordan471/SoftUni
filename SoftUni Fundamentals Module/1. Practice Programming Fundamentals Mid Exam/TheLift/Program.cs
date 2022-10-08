using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleWaitingForTheLift = int.Parse(Console.ReadLine());
            int[] peopleInWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            for (int i = 0; i <= peopleInWagons.Length - 1; i++)
            {                      
                if (peopleInWagons[i] < 4)
                {
                    int peopleWillGoInThisWagon = 4 - peopleInWagons[i];

                    if (peopleWaitingForTheLift < peopleWillGoInThisWagon)
                    {
                        peopleInWagons[i] += peopleWaitingForTheLift;
                        peopleWaitingForTheLift -= peopleWillGoInThisWagon;
                        break;
                    }
                    else
                    {
                        peopleInWagons[i] += peopleWillGoInThisWagon;
                        peopleWaitingForTheLift -= peopleWillGoInThisWagon;;
                    }                      
                }
            }

            int counterFullWagons = 0;

            for (int i = 0; i <= peopleInWagons.Length - 1; i++)
            {
                if (peopleInWagons[i] == 4)
                {
                    counterFullWagons++;
                }
            }
     
            if (peopleWaitingForTheLift <= 0 && counterFullWagons != peopleInWagons.Length)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", peopleInWagons));
            }
            else if (peopleWaitingForTheLift > 0 && counterFullWagons == peopleInWagons.Length)
            {
                peopleWaitingForTheLift = Math.Abs(peopleWaitingForTheLift);

                Console.WriteLine($"There isn't enough space! {peopleWaitingForTheLift} people in a queue!");
                Console.WriteLine(string.Join(" ", peopleInWagons));
            }
            else
            {
                Console.WriteLine(String.Join(" ", peopleInWagons));
            }
        }    
    }
}
