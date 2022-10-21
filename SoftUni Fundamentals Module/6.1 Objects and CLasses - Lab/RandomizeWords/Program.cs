using System;
using System.Linq;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            string[] arrayOfWords = sequence
                .Split()
                .ToArray();
          
            Random randomize = new Random();
          
            for (int i = 0; i < arrayOfWords.Length; i++)
            {
                int randomNum = randomize.Next(0, arrayOfWords.Length);

                string tempWord = arrayOfWords[i];

                arrayOfWords[i] = arrayOfWords[randomNum];
                arrayOfWords[randomNum] = tempWord; 
            }

            foreach (string word in arrayOfWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
