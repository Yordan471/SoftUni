using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterEggss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dyedEggs = int.Parse(Console.ReadLine());

            int counterRed = 0;
            int counterOrange = 0;
            int counterBlue = 0;
            int counterGreen = 0;
            int maxEggs = 0;
            string color = "";

            for (int i = 1; i <= dyedEggs; i++)
            {
                string dye = Console.ReadLine();

                switch (dye)
                {
                    case "red":
                        counterRed++;
                        break;
                    case "orange":
                        counterOrange++;
                        break;
                    case "blue":
                        counterBlue++;
                        break;
                    case "green":
                        counterGreen++;
                        break;
                }
            }

            if (counterRed > counterOrange && counterRed > counterBlue && counterRed > counterOrange)
            {
                maxEggs = counterRed;
                color = "red";
            }
            else if (counterOrange > counterRed && counterOrange > counterBlue && counterOrange > counterGreen)
            {
                maxEggs = counterOrange;
                color = "orange";
            }
            else if (counterBlue > counterRed && counterBlue > counterOrange && counterBlue > counterGreen)
            {
                maxEggs = counterBlue;
                color = "blue";
            }
            else
            {
                maxEggs = counterGreen;
                color = "green";
            }

            Console.WriteLine($"Red eggs: {counterRed}");
            Console.WriteLine($"Orange eggs: {counterOrange}");
            Console.WriteLine($"Blue eggs: {counterBlue}");
            Console.WriteLine($"Green eggs: {counterGreen}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {color}");
        }
    }
}
