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

            for (int i = 0; i < wordsToArray.Length; i++)
            {
                for (int r = 0; r < wordsToArray[i].Length; r++)
                {
                    for (int j = 0; j < wordsToArray[i].Length; j++)
                    {
                        result += wordsToArray[i][j];
                    }
                }              
            }

            Console.WriteLine(result);
        }
    }
}
