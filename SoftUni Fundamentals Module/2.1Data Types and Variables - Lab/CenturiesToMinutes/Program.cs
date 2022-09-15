using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenturiesToMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int centurie = int.Parse(Console.ReadLine());

            int centurieToYears = centurie * 100;

            int centurieToDays = (int)(centurieToYears * 365.2422);
            int centurieToHours = 24 * centurieToDays;
            int centurieToMinutes = centurieToHours * 60;

            Console.WriteLine($"{centurie} centuries = {centurieToYears} years = " +
                $"{centurieToDays} days = {centurieToHours} hours = " +
                $"{centurieToMinutes} minutes");
        }
    }
}
