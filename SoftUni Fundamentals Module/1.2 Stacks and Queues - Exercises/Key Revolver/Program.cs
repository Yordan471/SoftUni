using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceForBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int intelValue = int.Parse(Console.ReadLine());

            Queue<int> queueLocks = new Queue<int>(locks);
            Stack<int> stackBullets = new Stack<int>(bullets);
            int countBullets = 0;
            int barrelCount = 0;

            while (queueLocks.Count !=0)
            {
                for (int i = 0; i < sizeOfGunBarrel; i++)
                {
                    if (stackBullets.Count != 0 && queueLocks.Count != 0)
                    {
                        barrelCount++;
                        countBullets++;

                        if (stackBullets.Peek() <= queueLocks.Peek())
                        {
                            Console.WriteLine("Bang!");

                            stackBullets.Pop();
                            queueLocks.Dequeue();
                        }
                        else
                        {
                            Console.WriteLine("Ping!");

                            stackBullets.Pop();
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (stackBullets.Count != 0 && barrelCount == sizeOfGunBarrel)
                {
                    Console.WriteLine("Reloading!");
                }
                else
                {
                    break;
                }

                barrelCount = 0;
            }

            if (queueLocks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
            }
            else
            {
                int moneyEarned = intelValue - (countBullets * priceForBullet);
                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
