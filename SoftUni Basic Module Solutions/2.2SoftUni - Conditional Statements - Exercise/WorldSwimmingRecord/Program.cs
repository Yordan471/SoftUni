using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("");
            double secRec = double.Parse(Console.ReadLine());

            Console.Write("");
            double distanceM = double.Parse(Console.ReadLine());

            Console.Write("");
            double secTime = double.Parse(Console.ReadLine());
           
            int waterResM = 15;
            double waterRes = 12.5;

            double distanceIvan = distanceM * secTime;          
            double distanceIvanRes = (Math.Floor(distanceM / waterResM)) * waterRes;                      
            double fullTime = distanceIvan + (distanceIvanRes);
                   
            if (fullTime >= secRec)
            {
                Console.WriteLine($"No, he failed! He was {fullTime - secRec:f2} seconds slower.");
            }
            else if (secRec > fullTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {fullTime:f2} seconds.");                     
            }              
        }
    }
}
