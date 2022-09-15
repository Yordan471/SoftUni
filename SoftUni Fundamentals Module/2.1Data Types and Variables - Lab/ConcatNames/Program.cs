using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcatNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordOne = Console.ReadLine();
            string wordTwo = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine($"{wordOne}{delimiter}{wordTwo}");
        }
    }
}
