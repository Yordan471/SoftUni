using System;

namespace TextFiltering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine()
                .Split(", ");
            string text = Console.ReadLine();

            foreach (string word in banWords)
            {
                if (text.Contains(word))
                {
                    text = text.Replace(word, new string('*',
                        word.Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
