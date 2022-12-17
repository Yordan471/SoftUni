using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> evenNumbers = new Queue<int>(integers);

            for (int i = 0; i < integers.Length; i++)
            {
                int currNum = evenNumbers.Dequeue();

                if (currNum % 2 == 0)
                {
                    evenNumbers.Enqueue(currNum);
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
