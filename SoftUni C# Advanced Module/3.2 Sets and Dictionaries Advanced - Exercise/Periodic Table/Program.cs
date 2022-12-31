using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfInputLines = int.Parse(Console.ReadLine());

            HashSet<string> chemicalElements = new HashSet<string>();

            for (int i = 0; i < countOfInputLines; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(' ');

                for (int j = 0; j < elements.Length; j++)
                {
                    chemicalElements.Add(elements[j]);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalElements.OrderBy(el => el)));
        }
    }
}
