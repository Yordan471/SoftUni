using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());

            if (firstSymbol < secondSymbol)
            {
                PrintAllSymbolsInBetween(firstSymbol, secondSymbol);
            }
            else
            {
                IfSecondSymbolIsLessThenFirstSymbol(firstSymbol, secondSymbol);
            }
            
        }

        static void PrintAllSymbolsInBetween(char firstSymbol, char secondSymbol)
        {
            int letter = firstSymbol + 1;

            while (letter != secondSymbol)
            {
                Console.Write((char)letter + " ");

                letter += 1;
            }
        }

        static void IfSecondSymbolIsLessThenFirstSymbol(char firstSymbol, char secondSymbol)
        {
            char saveFirstSymbol = firstSymbol;

            if (firstSymbol > secondSymbol)
            {
                firstSymbol = secondSymbol;
                secondSymbol = saveFirstSymbol;
            }

            PrintAllSymbolsInBetween(firstSymbol, secondSymbol);
        }
    }
}
