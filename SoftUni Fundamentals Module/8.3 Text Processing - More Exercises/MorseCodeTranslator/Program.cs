using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MorseCodeTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("A", ".-");
            dic.Add("B", "-...");
            dic.Add("C", "-.-.");
            dic.Add("D", "-..");
            dic.Add("E", ".");
            dic.Add("F", "..-.");
            dic.Add("G", "--.");
            dic.Add("H", "....");
            dic.Add("I", "..");
            dic.Add("J", ".---");
            dic.Add("K", "-.-");
            dic.Add("L", ".-..");
            dic.Add("M", "--");
            dic.Add("N", "-.");
            dic.Add("O", "---");
            dic.Add("P", ".--.");
            dic.Add("Q", "--.-");
            dic.Add("R", ".-.");
            dic.Add("S", "...");
            dic.Add("T", "-");
            dic.Add("U", "..-");
            dic.Add("V", "...-");
            dic.Add("W", ".--");
            dic.Add("X", "-..-");
            dic.Add("Y", "-.--");
            dic.Add("Z", "--..");

            string result = string.Empty;
            
            var key = dic.ToDictionary(x => x.Value, x => x.Key);

            string inputMorseCode = Console.ReadLine();
           // inputMorseCode = inputMorseCode.Replace(" ", "");
           // inputMorseCode = inputMorseCode.Replace("|", " ");
            string[] morseCodeToArray = inputMorseCode
                .Split("|");

            for (int i = 0; i < morseCodeToArray.Length; i++)
            {
                string[] letters = morseCodeToArray[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < letters.Length; j++)
                {
                    
                    foreach (var d in dic)
                    {
                        if (letters[j] == d.Value)
                        {
                            result += d.Key;
                            break;
                        }
                    }
                }
               
                result += " ";
            }

            Console.WriteLine(result);
        }
    }
}
