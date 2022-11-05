using System;

namespace CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine()
                .Split(' ');

            int result = 0;
            char[] firstString = strings[0].ToCharArray();
            char[] secondString = strings[1].ToCharArray();
            int firstNumber = 0;
            int secondNumber = 0;
            for (int i = 0; i < Math.Min(strings[0].Length, strings[1].Length); i++)
            {
                 firstNumber = firstString[i];
                 secondNumber = secondString[i];

                result += firstNumber * secondNumber;
            }

            if (firstString.Length > secondString.Length)
            {
                int index = firstString.Length - secondString.Length;

                for (int i = firstString.Length - index; i < firstString.Length; i++)
                {
                    result += firstString[i];
                }
            }
            else
            {
                if (firstString.Length < secondString.Length)
                {
                    int index = secondString.Length - firstString.Length;

                    for (int i = secondString.Length - index; i < secondString.Length; i++)
                    {
                        result += secondString[i];
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
