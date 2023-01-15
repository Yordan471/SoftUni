using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cups_And_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInfo = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            int[] bottlesInfo = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();
                
            Queue<int> cups = new Queue<int>(cupsInfo);
            Stack<int> bottles = new Stack<int>(bottlesInfo);
            int wastedLittersOfWater = 0;

            while (cups.Count > 0 && bottles.Count > 0) 
            {
                if (cups.Peek() <= bottles.Peek())
                {
                    wastedLittersOfWater += bottles.Pop() - cups.Dequeue();
                }
                else
                {
                    int cupCapacity = cups.Peek();

                    while (true)
                    {
                        if (cupCapacity - bottles.Peek() > 0)
                        {
                            cupCapacity -= bottles.Peek();
                            bottles.Pop();
                        }
                        else
                        {
                            wastedLittersOfWater += bottles.Pop() - cupCapacity;
                            cups.Dequeue();
                            break;
                        }
                    }
                }
            }

            if (cups.Count == 0)
            {
                Console.Write($"Bottles: ");
                Console.WriteLine(string.Join(" ", bottles));
                Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
            }

            if (bottles.Count == 0)
            {
                Console.Write($"Cups: ");
                Console.WriteLine(string.Join(" ", cups));
                Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
            }
        }
    }
}
