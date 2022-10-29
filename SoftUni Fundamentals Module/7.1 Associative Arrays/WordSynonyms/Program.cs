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

            Dictionary<string, List<string>> wordsAndSynonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < numberOfPairs; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!wordsAndSynonyms.ContainsKey(word))
                {
                    wordsAndSynonyms.Add(word, new List<string>());
                }

                wordsAndSynonyms[word].Add(synonym);
            }

            foreach (var word in wordsAndSynonyms)
            {
                List <string> synonyms = new List<string>(word.Value);

                Console.WriteLine($"{word.Key} - {string.Join(", ", synonyms)}");
            }
        }
    }
}
