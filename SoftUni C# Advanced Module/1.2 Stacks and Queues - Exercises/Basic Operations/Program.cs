using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Operations
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

            Stack<int> integers = new Stack<int>();

            PushNumbersInStack(nsx, numbers, integers);

            PopNumbersFromStack(nsx, integers);

            FindIfQueueContainsNumber(nsx, integers);
        }

        private static void FindIfQueueContainsNumber(int[] nsx, Stack<int> integers)
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

        private static void PopNumbersFromStack(int[] nsx, Stack<int> integers)
        {
            if (nsx[1] >= integers.Count)
            {
                integers.Clear();
            }
            else
            {
                for (int i = 0; i < nsx[1]; i++)
                {
                    integers.Pop();
                }
            }
        }

        private static void PushNumbersInStack(int[] nsx, int[] numbers, Stack<int> integers)
        {
            for (int i = 0; i < nsx[0]; i++)
            {
                integers.Push(numbers[i]);
            }
        }
    }
}
