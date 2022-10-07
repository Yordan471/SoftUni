using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> appendArray = Console.ReadLine().Split('|').Reverse().ToList();
            List<int> numbers = new List<int>();
            string[] separator = new string[] { " " };

            foreach (var symbol in appendArray)
            {
                numbers.AddRange(symbol.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
