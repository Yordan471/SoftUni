using System;

namespace AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string sequence = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (firstChar > secondChar)
                {
                    if (sequence[i] > secondChar && sequence[i] < firstChar)
                    {
                        sum += char.Parse(sequence[i].ToString());
                    }
                }
                else
                {
                    if (sequence[i] < secondChar && sequence[i] > firstChar)
                    {
                        sum += char.Parse(sequence[i].ToString());
                    }
                }            
            }

            Console.WriteLine(sum);
        }
    }
}
