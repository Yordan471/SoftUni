using System;

namespace Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string word = Console.ReadLine();
            string result = string.Empty;
            int index = word.IndexOf(wordToRemove);

            while (word.Contains(wordToRemove))
            {          
                word = word.Remove(index, wordToRemove.Length);
                index = word.IndexOf(wordToRemove);
            }

            Console.WriteLine(result);
        }
    }
}
