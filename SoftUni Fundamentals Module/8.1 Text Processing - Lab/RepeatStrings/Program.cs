using System;

namespace RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            string[] wordsToArray = words.Split();
            string result = string.Empty;

            foreach (string word in wordsToArray)
            {
                for (int r = 0; r < word.Length; r++)
                {
                    result += word;
                }
            }

            Console.WriteLine(result);
        }
    }
}
