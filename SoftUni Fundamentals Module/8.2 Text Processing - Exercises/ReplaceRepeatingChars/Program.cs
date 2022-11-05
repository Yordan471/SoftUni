using System;

namespace ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();
            char[] lettersToChars = letters.ToCharArray();
            int count = 0;

            for (int i = 0; i < letters.Length - 1; i++)
            {
                char letter = letters[i];
                string sequenceToRemove = string.Empty;

                for (int j = 0; j < letters.Length - 1; j++)
                {        
                    if (j + count == letters.Length - 1)
                    {
                        sequenceToRemove += letter;
                        letters = letters.Replace(sequenceToRemove, letter.ToString());
                        break;
                    }

                    if (letter == letters[j + count])
                    {
                        sequenceToRemove += letter;

                        if (j == letters.Length - 2)
                        {
                            sequenceToRemove += letter;
                            letters = letters.Replace(sequenceToRemove, letter.ToString());
                            break;
                        }
                    }
                    else
                    {
                        count++;
                        letters = letters.Replace(sequenceToRemove, letter.ToString());                      
                        break;
                    }    
                }
            }

            Console.WriteLine(letters);
        }
    }
}
