using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
            string command = string.Empty;

            int counterForTargetsShot = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                int index = int.Parse(command);

                if (index < 0 || index >= targets.Length)
                {
                    continue;
                }

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[index] != -1 && index != i && targets[i] != -1)
                    {
                        if (targets[index] >= targets[i])
                        {
                            targets[i] += targets[index];
                        }
                        else
                        {
                            targets[i] -= targets[index];
                        }
                    }                                        
                }

                targets[index] = -1;
                counterForTargetsShot++;
            }

            Console.Write($"Shot targets: {counterForTargetsShot} -> ");
            Console.Write(String.Join(" ", targets));
        }
    }
}
