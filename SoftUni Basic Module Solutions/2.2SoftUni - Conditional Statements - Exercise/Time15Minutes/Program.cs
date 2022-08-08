using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time15Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("");
            int entryHours = int.Parse(Console.ReadLine());

            Console.Write("");
            int entryMinutes = int.Parse(Console.ReadLine());

            int hoursToMinutes = entryHours * 60;
            int resultMinutes = hoursToMinutes + entryMinutes + 15;

            double exitHours = resultMinutes / 60;
            double exitMinutes = resultMinutes % 60;

            if (exitHours > 23 && exitMinutes < 10)
            {
                exitHours = 0;
                Console.WriteLine($"{exitHours}:0{exitMinutes}");
            }
            else if (exitHours > 23)
            {
                exitHours = 0;
                Console.WriteLine($"{exitHours}:{exitMinutes}");
            }
            else if (exitMinutes < 10)
            {
                Console.WriteLine($"{exitHours}:0{exitMinutes}");
            }       
            else
            {
                Console.WriteLine($"{exitHours}:{exitMinutes}");
            }           
        }
    }
}
