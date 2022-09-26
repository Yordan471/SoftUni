using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeVariable = Console.ReadLine();

            switch (typeVariable)
            {
                case "int":
                    int inputOne = int.Parse(Console.ReadLine());
                    int inputTwo = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(inputOne, inputTwo)); 
                    break;
                case "char":
                    char charInputOne = char.Parse(Console.ReadLine());
                    int charInputTwo = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax((char)charInputOne,(char)charInputTwo)); 
                    break;
                case "string":
                    string stringInputOne = Console.ReadLine();
                    string stringInputTwo = Console.ReadLine();
                    Console.WriteLine(GetMax(stringInputOne, stringInputTwo)); 
                    break;
            }
        }

        static int GetMax(int inputOne, int inputTwo)
        {
            if (inputOne > inputTwo)
            {
                return inputOne;
            }
            else
            {
                return inputTwo;
            }
        }

        static char GetMax(char inputOne, char inputTwo)
        {
            if (inputOne > inputTwo)
            {
                return inputOne;
            }
            else
            {
                return inputTwo;
            }
        }

        static string GetMax(string inputOne, string inputTwo)
        {
            int result = inputOne.CompareTo(inputTwo);

            if (result > 0)
            {
                return inputOne;
            }
            else
            {
                return inputTwo;
            }              
        }
    }
}
