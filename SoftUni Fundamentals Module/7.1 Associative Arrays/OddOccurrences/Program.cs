using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sequenceOfElements = Console.ReadLine()
                .Split(' ')
                .ToArray();

            sequenceOfElementsToLower(sequenceOfElements);

            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            AddingToDictionary(sequenceOfElements, keyValuePairs);

            List<string> oddByOccurrences = new List<string>();

            OddOccurrencesElements(keyValuePairs, oddByOccurrences);

            Console.WriteLine(string.Join(" ", oddByOccurrences));
        }

        private static void OddOccurrencesElements(Dictionary<string, int> keyValuePairs, List<string> oddByOccurrences)
        {
            foreach (KeyValuePair<string, int> keyValue in keyValuePairs)
            {
                if (keyValue.Value % 2 != 0)
                {
                    oddByOccurrences.Add(keyValue.Key.ToLower());
                }
            }
        }

        private static void AddingToDictionary(string[] sequenceOfElements, Dictionary<string, int> keyValuePairs)
        {
            foreach (string element in sequenceOfElements)
            {
                if (keyValuePairs.ContainsKey(element))
                {
                    keyValuePairs[element]++;
                }
                else
                {
                    keyValuePairs.Add(element, 1);
                }
            }
        }

        private static void sequenceOfElementsToLower(string[] sequenceOfElements)
        {
            for (int i = 0; i < sequenceOfElements.Length; i++)
            {
                sequenceOfElements[i] = sequenceOfElements[i].ToLower();
            }
        }
    }
}
