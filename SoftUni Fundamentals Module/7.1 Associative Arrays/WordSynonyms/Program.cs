using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPairs = int.Parse(Console.ReadLine());

            Dictionary<string, string> wordsAndSynonyms = new Dictionary<string, string>();

            for (int i = 0; i < numberOfPairs; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (wordsAndSynonyms.ContainsKey(word))
                {
                    wordsAndSynonyms[word] += ", " + synonym;
                }
                else
                {
                    wordsAndSynonyms.Add(word, synonym);
                }              
            }

            foreach (var word in wordsAndSynonyms)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
