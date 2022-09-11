using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string namePlayer = Console.ReadLine();

            int saveGoals = 0;
            string saveName = "";
            bool hatTrick = false;

            while (namePlayer != "END")
            {
                int numberOfGoals = int.Parse(Console.ReadLine());

                if (saveGoals < numberOfGoals)
                {
                    saveGoals = numberOfGoals;
                    saveName = namePlayer;

                    if (saveGoals >= 3)
                    {
                        hatTrick = true;
                    }
                }

                if (numberOfGoals >= 10)
                {
                    break;
                }

                namePlayer = Console.ReadLine();
            }

            if (hatTrick)
            {
                Console.WriteLine($"{saveName} is the best player!");
                Console.WriteLine($"He has scored {saveGoals} goals and made a hat-trick !!!");
            }
            else if (hatTrick == false)
            {
                Console.WriteLine($"{saveName} is the best player!");
                Console.WriteLine($"He has scored {saveGoals} goals.");
            }
        }
    }
}
