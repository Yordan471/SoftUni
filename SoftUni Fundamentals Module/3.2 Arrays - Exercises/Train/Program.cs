using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());

            int sum = 0;
            int[] wagons = new int[numberOfWagons];

            for (int i = 0; i < numberOfWagons; i++)
            {
                int numberOfPeople = int.Parse(Console.ReadLine());

                wagons[i] = numberOfPeople;
                sum += numberOfPeople;
            }

            foreach (int wagon in wagons)
            {
                Console.Write(wagon + " ");
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
