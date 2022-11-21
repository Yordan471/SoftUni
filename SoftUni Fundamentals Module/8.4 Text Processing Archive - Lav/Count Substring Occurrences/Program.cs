using System;
using System.Linq;

namespace Count_Substring_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine().ToLower();

            string substring = Console.ReadLine().ToLower();

            int counter = 0;
            int index = 0;

            while (index != -1)
            {
                index = sequence.IndexOf(substring, index);

                if (index >= 0)
                {
                    counter++;
                    index++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
