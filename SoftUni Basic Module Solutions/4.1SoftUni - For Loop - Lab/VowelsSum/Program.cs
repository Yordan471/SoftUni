using System;

namespace VowelsSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int sum = 0;

            for (int f = 0; f < word.Length; f++)
            {
                char letter = word[f];
                
                    switch (letter)
                    {
                        case 'a': sum += 1; break;
                        case 'e': sum += 2; break;
                        case 'i': sum += 3; break;
                        case 'o': sum += 4; break;
                        case 'u': sum += 5; break;
                    }                
            }
            Console.WriteLine(sum);                   
        }
    }
}
