using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackIn30Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int thirtyMinutes = 30;
            minutes += thirtyMinutes;

            if (minutes > 59)
            {
                hours += 1;

                if (hours > 23)
                {
                    hours = 0;
                }

                minutes -= 60;
            }

            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
