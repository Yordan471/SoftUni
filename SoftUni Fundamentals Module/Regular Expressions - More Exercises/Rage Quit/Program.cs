using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputInfo = Console.ReadLine();

            string pattern = @"(?<string>[ -\/:-~]+)(?<digit>[0-9]{0,2})";

            Dictionary <string, int> stringAndDigit = new Dictionary<string, int>();

            Regex regex = new Regex(pattern);

            int countUniqueSymbols = 0;

            string toLowerInput = inputInfo.ToLower();
            char[] inputToCharArray = toLowerInput.ToCharArray();

            for (int i = 0; i < inputInfo.Length; i++)
            {
                bool isEqual = false;

                for (int j = 0 + i + 1; j < inputInfo.Length; j++)
                {
                    if ((inputToCharArray[i] == inputToCharArray[j]) || (char.IsDigit(inputToCharArray[i])))
                    {
                        isEqual = true;
                        break;
                    }
                }
                
                if (!isEqual)
                {
                    if (i == inputInfo.Length - 1)
                    {
                        break;
                    }


                        countUniqueSymbols++;
                                    
                }
            }

            while (inputInfo.Length != 0)
            {
                Match stringPart = regex.Match(inputInfo);

                inputInfo = inputInfo.Remove(0, stringPart.Length);

                string toString = stringPart.Groups["string"].Value;
                int toDigit = int.Parse(stringPart.Groups["digit"].Value);

                stringAndDigit[toString] = toDigit;
            }

            Console.WriteLine($"Unique symbols used: {countUniqueSymbols}");
            
            foreach (var kvp in stringAndDigit)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    Console.Write(kvp.Key.ToUpper());
                }
            }
        }
    }
}
