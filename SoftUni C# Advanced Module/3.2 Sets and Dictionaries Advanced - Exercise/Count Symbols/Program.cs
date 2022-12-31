using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputInfo = Console.ReadLine();

            Dictionary<char, int> countChars = new Dictionary<char, int>();

            for (int i = 0; i < inputInfo.Length; i++)
            {
                if (!(countChars.ContainsKey(inputInfo[i])))
                {
                    countChars[inputInfo[i]] = 0;
                }

                countChars[inputInfo[i]]++;
            }

            foreach (var ch in countChars.Keys.OrderBy(c => c))
            {
                Console.WriteLine($"{ch}: {countChars[ch]} time/s");
            }
        }
    }
}
