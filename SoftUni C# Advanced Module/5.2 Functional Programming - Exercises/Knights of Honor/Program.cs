using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfNames = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> print = names =>
            {
                foreach (string name in names)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            print(listOfNames);
        }
    }
}
