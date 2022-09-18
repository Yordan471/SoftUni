using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snowfall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snowballs = int.Parse(Console.ReadLine());
            
            BigInteger snowballValue = 0;
            BigInteger biggestValue = 0;
            double saveSnowballSnow = 0;
            double saveSnowballTime = 0;
            double saveSnowballQuality = 0;

            for (int i = 1; i <= snowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality); 

                if (biggestValue < snowballValue)
                {
                    biggestValue = snowballValue;
                    saveSnowballSnow = snowballSnow;
                    saveSnowballTime = snowballTime;
                    saveSnowballQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{saveSnowballSnow} : {saveSnowballTime} = {biggestValue} ({saveSnowballQuality})");
        }
    }
}
