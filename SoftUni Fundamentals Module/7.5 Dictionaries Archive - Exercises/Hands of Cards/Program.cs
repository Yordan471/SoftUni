using System;
using System.Collections.Generic;
using System.Linq;

namespace Hands_of_Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary<string, string> nameAndValue = new Dictionary<string, string>();

            string cards = string.Empty;

            while ((command = Console.ReadLine()) != "JOKER")
            {
                string[] commandToArray = command
                    .Split(": ");

                string name = commandToArray[0];
                cards = commandToArray[1];                
               
                if (!nameAndValue.ContainsKey(name))
                {
                    nameAndValue.Add(name, cards);
                }
                else
                {

                    nameAndValue[name] += $", {cards}";
                }                           
            }

            List<string> cardsToList = new List<string>();
            Dictionary <string, int> nameAndPoints = new Dictionary<string, int>(); 
                
            foreach (var name in nameAndValue)
            {
                cardsToList = name.Value
                    .Split(", ")
                    .Distinct()
                    .ToList();

                int value = 0;               

                for (int i = 0; i < cardsToList.Count; i++)
                {
                    int firstDigit = 0;
                    int secondDigit = 0;

                    foreach (char ch in cardsToList[i])
                    {                      
                        if (char.IsDigit(ch))
                        {
                            firstDigit = int.Parse(ch.ToString());
                        }
                        else
                        {
                            switch (ch)
                            {
                                case 'A':
                                    firstDigit = 14;
                                    break;
                                case 'K':
                                    firstDigit = 13;
                                    break;
                                case 'Q':
                                    firstDigit = 12;
                                    break;
                                case 'J':
                                    firstDigit = 11;
                                    break;
                                case 'S':
                                    secondDigit = 4;
                                    break;
                                case 'H':
                                    secondDigit = 3;
                                    break;
                                case 'D':
                                    secondDigit = 2;
                                    break;
                                case 'C':
                                    secondDigit = 1;
                                    break;
                            }

                            if (cardsToList[i].Count() == 3)
                            {
                                firstDigit = 10;
                            }
                        }
                    }

                    value += firstDigit * secondDigit;
                }

                if (!nameAndPoints.ContainsKey(name.Key))
                {
                    nameAndPoints.Add(name.Key, value);
                }
            }
          
            foreach (var namePoints in nameAndPoints)
            {
                Console.WriteLine($"{namePoints.Key}: {namePoints.Value}");
            }
        }
    }
}
