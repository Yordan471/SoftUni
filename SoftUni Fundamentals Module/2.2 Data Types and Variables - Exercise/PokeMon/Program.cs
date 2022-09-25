using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distanceBetweenTargets = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int pokedTargetsCounter = 0;
            int savePokePower = pokePower;

            while (pokePower >= distanceBetweenTargets)
            {
                pokePower -= distanceBetweenTargets;

                if (pokePower == (decimal)savePokePower / 2)
                {
                    savePokePower = pokePower;

                    if (exhaustionFactor != 0)
                    {
                        pokePower /= exhaustionFactor;
                    }
                    
                    if (pokePower == 0)
                    {
                        pokePower = savePokePower;
                    }
                }

                pokedTargetsCounter++;
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargetsCounter);
        }
    }
}
