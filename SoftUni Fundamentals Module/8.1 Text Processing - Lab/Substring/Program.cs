using System;

namespace Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string word = Console.ReadLine();
            int index = word.IndexOf(wordToRemove);

            //while (word.Contains(wordToRemove))
            //{          
            //    word = word.Remove(index, wordToRemove.Length);
            //    index = word.IndexOf(wordToRemove);
            //}

            while (word.Contains(wordToRemove))
            {
                word = word.Replace(wordToRemove, String.Empty);
            }

            Console.WriteLine(word);
        }
    }
}
