using System;

namespace Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sequenceOfString = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            decimal result = 0;

            for (int i = 0; i < sequenceOfString.Length; i++)
            {
                decimal sum = 0;

                char[] inputToCharArray = sequenceOfString[i].ToCharArray();
                char firstLetter = inputToCharArray[0];
                char secondLetter = inputToCharArray[inputToCharArray.Length - 1];

                string number = sequenceOfString[i].Substring(1, sequenceOfString[i].Length - 2);
                int digit = 0;

                digit = FirstLetterNumber(firstLetter, digit);

                if (char.IsLower(firstLetter))
                {
                    sum += digit * decimal.Parse(number);
                }
                else
                {
                    sum += decimal.Parse(number) / digit;
                }

                digit = FirstLetterNumber(secondLetter, digit);

                if (char.IsLower(secondLetter))
                {
                    sum += digit;
                }
                else
                {
                    sum -= digit;
                }

                result += sum;
            }

            Console.WriteLine($"{result:f2}");
        }

        private static int FirstLetterNumber(char letter, int digit)
        {
            switch (letter)
            {
                case 'A':
                case 'a':
                    digit = 1;
                    break;
                case 'B':
                case 'b':
                    digit = 2;
                    break;
                case 'C':
                case 'c':
                    digit = 3;
                    break;
                case 'D':
                case 'd':
                    digit = 4;
                    break;
                case 'E':
                case 'e':
                    digit = 5;
                    break;
                case 'F':
                case 'f':
                    digit = 6;
                    break;
                case 'G':
                case 'g':
                    digit = 7;
                    break;
                case 'H':
                case 'h':
                    digit = 8;
                    break;
                case 'I':
                case 'i':
                    digit = 9;
                    break;
                case 'J':
                case 'j':
                    digit = 10;
                    break;
                case 'K':
                case 'k':
                    digit = 11;
                    break;
                case 'L':
                case 'l':
                    digit = 12;
                    break;
                case 'M':
                case 'm':
                    digit = 13;
                    break;
                case 'N':
                case 'n':
                    digit = 14;
                    break;
                case 'O':
                case 'o':
                    digit = 15;
                    break;
                case 'P':
                case 'p':
                    digit = 16;
                    break;
                case 'Q':
                case 'q':
                    digit = 17;
                    break;
                case 'R':
                case 'r':
                    digit = 18;
                    break;
                case 'S':
                case 's':
                    digit = 19;
                    break;
                case 'T':
                case 't':
                    digit = 20;
                    break;
                case 'U':
                case 'u':
                    digit = 21;
                    break;
                case 'V':
                case 'v':
                    digit = 22;
                    break;
                case 'W':
                case 'w':
                    digit = 23;
                    break;
                case 'X':
                case 'x':
                    digit = 24;
                    break;
                case 'Y':
                case 'y':
                    digit = 25;
                    break;
                case 'Z':
                case 'z':
                    digit = 26;
                    break;
            }

            return digit;
        }
    }
}
