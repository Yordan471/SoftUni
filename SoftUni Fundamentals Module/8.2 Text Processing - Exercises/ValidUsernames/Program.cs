using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readNames = Console.ReadLine();

            string[] readNamesToArray = readNames
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<string> wordsToPrint = new List<string>();
            bool isTrue = false;

            foreach (string name in readNamesToArray)
            {
                char[] chars = name.ToCharArray();

                if (chars.Length > 3 && chars.Length < 16)
                {
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if ((chars[i] >= 48 && chars[i] <= 57) ||
                            (chars[i] >= 65 && chars[i] <= 90) ||
                            (chars[i] >= 97 && chars[i] <= 122) ||
                            chars[i] == 45 || chars[i] == 95)
                        {
                            isTrue = true;
                        }
                        else
                        {
                            isTrue = false;
                            break;
                        }
                    }

                    if (isTrue)
                    {
                        wordsToPrint.Add(name);
                    }
                }            
            }

            foreach (string word in wordsToPrint)
            {
                Console.WriteLine(word);
            }
        }
    }
}
