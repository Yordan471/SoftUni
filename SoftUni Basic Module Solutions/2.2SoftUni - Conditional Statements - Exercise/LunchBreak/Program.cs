using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchBreak
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("");
            string name = Console.ReadLine();

            Console.Write("");
            int vremeEpizod = int.Parse(Console.ReadLine());

            Console.Write("");
            int vremePochivka = int.Parse(Console.ReadLine());

            double vremeObqd = vremePochivka * 0.125;
            double vremeOtdih = vremePochivka * 0.25;

            double timeLeft = vremePochivka - vremeObqd - vremeOtdih;
            
            if (timeLeft >= vremeEpizod)
            {
                Console.WriteLine($"You have enough time to watch {name} and left with {Math.Ceiling(timeLeft - vremeEpizod)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(vremeEpizod - timeLeft)} more minutes.");
            }           
        }
    }
}
