using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int counterWins = 0;
            bool notEnoughEnergy = false;
            bool end = false;

            while (true)
            {
                if (command == "End of battle")
                {
                    end = true;
                    break;
                }

                int distance = int.Parse(command);

                if (initialEnergy < distance)
                {
                    notEnoughEnergy = true;
                    break;
                }

                initialEnergy -= distance;
                counterWins++;

                if (counterWins % 3 == 0)
                {
                    initialEnergy += counterWins;
                }

                command = Console.ReadLine();   
            }

            if (end)
            {
                Console.WriteLine($"Won battles: {counterWins}. Energy left: {initialEnergy}");
            }
            else if (notEnoughEnergy)
            {
                Console.WriteLine($"Not enough energy! Game ends with {counterWins} won battles and {initialEnergy} energy");
            }
        }
    }
}
