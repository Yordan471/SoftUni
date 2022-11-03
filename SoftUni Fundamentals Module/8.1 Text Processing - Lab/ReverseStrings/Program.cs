using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = string.Empty;
            Dictionary<string, string> wordAndReverseWord = 
                new Dictionary<string, string>();

            while ((word = Console.ReadLine()) != "end")
            {
                string reverseString = string.Empty; 
                
                char[] chars = word.ToCharArray();
                Array.Reverse(chars);

                reverseString = new string(chars);
                wordAndReverseWord.Add(word, reverseString);          
            }

            foreach (var wordd in wordAndReverseWord)
            Console.WriteLine($"{wordd.Key} = {wordd.Value}");
        }
    }
}
