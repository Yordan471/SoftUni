using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine()
                .Split(' ');

            int numberOfRotations = int.Parse(Console.ReadLine());

            int tossBall = 1;
            Queue<string> winner = new Queue<string>(kids);

            while (winner.Count > 1)
            {
                string currentKid = winner.Dequeue();

                if (tossBall == numberOfRotations)
                {
                    Console.WriteLine($"Removed {currentKid}");
                    tossBall = 1;
                    continue;
                }

                tossBall++;
                winner.Enqueue(currentKid);
            }

            Console.WriteLine($"Last is {winner.Peek()}");
        }
    }
}
