using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix_Q_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> integers = new Queue<int>();

            PushNumbersInStack(nsx, numbers, integers);

            PopNumbersFromStack(nsx, integers);

            FindIfQueueContainsNumber(nsx, integers);
        }

        private static void FindIfQueueContainsNumber(int[] nsx, Queue<int> integers)
        {
            if (integers.Count > 0)
            {
                if (!(integers.Contains(nsx[2])))
                {
                    Console.WriteLine(integers.Min());
                }
                else if (integers.Contains(nsx[2]))
                {
                    Console.WriteLine("true");
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        private static void PopNumbersFromStack(int[] nsx, Queue<int> integers)
        {
            if (nsx[1] >= integers.Count)
            {
                integers.Clear();
            }
            else
            {
                for (int i = 0; i < nsx[1]; i++)
                {
                    integers.Dequeue();
                }
            }
        }

        private static void PushNumbersInStack(int[] nsx, int[] numbers, Queue<int> integers)
        {
            for (int i = 0; i < nsx[0]; i++)
            {
                integers.Enqueue(numbers[i]);
            }
        }
    }
}
