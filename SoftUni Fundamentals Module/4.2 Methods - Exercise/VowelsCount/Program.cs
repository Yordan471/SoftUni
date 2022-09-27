using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            Console.WriteLine(PrintNumberOfVowels(word));
        }

        static int PrintNumberOfVowels(string word)
        {
            char[] chars = word.ToCharArray();
            int counterVowels = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 'e' || chars[i] == 'i' || chars[i] == 'o' ||
                    chars[i] == 'u' || chars[i] == 'a')
                {
                    counterVowels++;
                }
            }

            return counterVowels;
        }
    }
}
