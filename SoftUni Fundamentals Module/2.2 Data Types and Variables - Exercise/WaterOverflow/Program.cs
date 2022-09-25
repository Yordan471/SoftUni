using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int waterCapacity = 255;
            int saveWaterCapacity = waterCapacity;

            for (int i = 0; i < n; i++)
            {
                int litersReceived = int.Parse(Console.ReadLine());

                waterCapacity -= litersReceived;

                if (waterCapacity < 0)
                {
                    Console.WriteLine("Insufficient capacity!");
                    waterCapacity += litersReceived;
                }
            }

            Console.WriteLine(saveWaterCapacity - waterCapacity);
        }
    }
}
