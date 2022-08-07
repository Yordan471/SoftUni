using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingHours
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("");
            double number = double.Parse(Console.ReadLine());

            string weekDay = Console.ReadLine();

            if (number >= 10 && number <= 18 && weekDay != "Sunday")
            {
                Console.WriteLine("open");
            }
            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}
