using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothesInBox = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int capacityOfTheRack = int.Parse(Console.ReadLine());
            int newRack = capacityOfTheRack;
            int counterRacks = 1;

            for (int i = 0; i < clothesInBox.Count; i++)
            {
                if (capacityOfTheRack >= clothesInBox.Peek())
                {
                    capacityOfTheRack -= clothesInBox.Pop();
                    i--;
                }
                else
                {
                    counterRacks++;
                    capacityOfTheRack = newRack;
                    i--;
                }
            }

            Console.WriteLine(counterRacks);
        }
    }
}
