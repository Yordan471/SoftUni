using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] vowelsInput = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string[] consonantsInput = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> vowels = new Queue<string>(vowelsInput);
            Stack<string> consonants = new Stack<string>(consonantsInput);

            Dictionary<string, HashSet<string>> wordAndCount = new Dictionary<string, HashSet<string>>()
            {
                { "pear", new HashSet<string>() },
                { "flour", new HashSet<string>() },
                { "pork", new HashSet<string>() },
                { "olive", new HashSet<string>() }
            };

            while (consonants.Count != 0)
            {
                string checkVowel = vowels.Peek();
                string checkConsonant = consonants.Peek();

                foreach (var word in wordAndCount.Keys)
                {
                    if (word.Contains(checkVowel))
                    {
                        wordAndCount[word].Add(checkVowel);
                    }

                    if (word.Contains(checkConsonant))
                    {
                        wordAndCount[word].Add(checkConsonant);
                    }
                }

                string firstVowel = vowels.Dequeue();
                vowels.Enqueue(firstVowel);

                consonants.Pop();
            }

            int countWords = 0;

            foreach (var word in wordAndCount)
            {
                if (word.Key.Count() == word.Value.Count())
                {
                    countWords++;
                }
            }

            Console.WriteLine($"Words found: {countWords}");

            if (countWords > 0)
            {
                foreach (var word in wordAndCount)
                {
                    if (word.Key.Count() == word.Value.Count())
                    {
                        Console.WriteLine($"{word.Key}");
                    }
                }
            }
        }
    }
}
