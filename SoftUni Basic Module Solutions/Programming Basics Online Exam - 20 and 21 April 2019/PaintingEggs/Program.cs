using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintingEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sizeOfEggs = Console.ReadLine();
            string colorEggs = Console.ReadLine();
            int numPackages = int.Parse(Console.ReadLine());

            int sum = 0;

            if (sizeOfEggs == "Large")
            {
                switch (colorEggs)
                {
                    case "Red":
                        sum += 16;
                        break;
                    case "Green":
                        sum += 12;
                        break;
                    case "Yellow":
                        sum += 9;
                        break;
                }
            }
            else if (sizeOfEggs == "Medium")
            {
                switch (colorEggs)
                {
                    case "Red":
                        sum += 13;
                        break;
                    case "Green":
                        sum += 9;
                        break;
                    case "Yellow":
                        sum += 7;
                        break;
                }
            }
            else if (sizeOfEggs == "Small")
            {
                switch (colorEggs)
                {
                    case "Red":
                        sum += 9;
                        break;
                    case "Green":
                        sum += 8;
                        break;
                    case "Yellow":
                        sum += 5;
                        break;
                }
            }

            double priceOfAllPackages = sum * numPackages;
            double resultPrice = priceOfAllPackages * 0.65;
            Console.WriteLine($"{resultPrice:f2} leva.");
        }
    }
}
