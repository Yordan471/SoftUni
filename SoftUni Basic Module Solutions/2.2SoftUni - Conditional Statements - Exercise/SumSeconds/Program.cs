using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("");
            int firstTime = int.Parse(Console.ReadLine());

            Console.WriteLine(" ");
            int secondTime = int.Parse(Console.ReadLine());

            Console.WriteLine(" ");
            int thirdTime = int.Parse(Console.ReadLine());

            int totalTime = firstTime + secondTime + thirdTime;

            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
