using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPartOfASCIITable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startLetter = int.Parse(Console.ReadLine());
            int endLetter = int.Parse(Console.ReadLine());

            for (int i = startLetter; i <= endLetter; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
