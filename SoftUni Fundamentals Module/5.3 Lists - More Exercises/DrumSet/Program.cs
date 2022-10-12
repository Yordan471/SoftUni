using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrumSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<string> stringDrumsQuality = Console.ReadLine()
                .Split()
                .ToList();

            List<int> drumsQuality = stringDrumsQuality
                .Select(int.Parse)
                .ToList();

            List<int> saveDrumsQuality = stringDrumsQuality
                   .Select(int.Parse)
                   .ToList();

            string command = Console.ReadLine();

            while (true)
            {
                if (command == "Hit it again, Gabsy!")
                {
                    break;
                }

                int hitPower = int.Parse(command);
               
                for (int i = 0; i < drumsQuality.Count; i++)
                {
                    drumsQuality[i] -= hitPower;

                    if (drumsQuality[i] <= 0)
                    {
                        if (savings >= saveDrumsQuality[i] * 3)
                        {
                            drumsQuality[i] = saveDrumsQuality[i];
                            savings -= saveDrumsQuality[i] * 3;
                        }
                        else
                        {
                            drumsQuality.RemoveAt(i);
                            saveDrumsQuality.RemoveAt(i);                            
                            i--;                       
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (drumsQuality.Count >= 0 && drumsQuality[0] != 0)
            {
                Console.WriteLine(String.Join(" ", drumsQuality));
                Console.WriteLine($"Gabsy has {savings:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Gabsy has {savings:f2}lv.");
            }
        }
    }
}
