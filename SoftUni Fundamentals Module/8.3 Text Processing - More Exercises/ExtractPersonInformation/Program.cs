using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            List<string> gatherInfo = new List<string>();
            char[] separatos = { '@', '|', '#', '*' };

            for (int i = 0; i < numberOfLines; i++)
            {
                string information = Console.ReadLine();

                int firstSymbol = information.LastIndexOf(separatos[0]);
                int secondSymbol = information.IndexOf(separatos[1]);
                int lengthName = secondSymbol - firstSymbol;

                int thirdSymbol = information.LastIndexOf(separatos[2]);
                int fourthSymbol = information.IndexOf(separatos[3]);
                int lengthAge = fourthSymbol - thirdSymbol;

                string name = information.Substring(firstSymbol + 1, lengthName - 1);
                string age = information.Substring(thirdSymbol + 1, lengthAge - 1);

                gatherInfo.Add($"{name} is {age} years old.");
            }

            foreach (string information in gatherInfo)
            {
                Console.WriteLine(information);
            }
        }
    }
}
