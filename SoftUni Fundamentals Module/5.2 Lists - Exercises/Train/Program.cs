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
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxPassangers = int.Parse(Console.ReadLine());

            while (true)
            {
                string addWagonWithPassangersOrOnlyPassangers = Console.ReadLine();

                if (addWagonWithPassangersOrOnlyPassangers == "end")
                {
                    break;
                }

                List<string> addWagonWithPeople = addWagonWithPassangersOrOnlyPassangers.Split().ToList();
                string add = addWagonWithPeople[0];

                int numberOfPassangers = 0;

                if (add == "Add")
                {
                    numberOfPassangers = int.Parse(addWagonWithPeople[1]);

                    wagons.Add(numberOfPassangers);
                }
                else
                {
                    int passangers = int.Parse(addWagonWithPassangersOrOnlyPassangers);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (passangers + wagons[i] <= maxPassangers)
                        {
                            wagons[i] += passangers;                         
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            Console.WriteLine(String.Join(" ", wagons));
        }     
    }
}
