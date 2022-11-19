using System;
using System.Linq;

namespace Short_Words_Sorted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] split = new string[]{ ".", ",", ":", ";", "()", "[]", "\"", "\\/", "!", "?", " "};

            string[] words = Console.ReadLine()
                .ToLower()
                .Split(split, StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .Where(x => x.Length < 5)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", words));               
        }
    }
}
