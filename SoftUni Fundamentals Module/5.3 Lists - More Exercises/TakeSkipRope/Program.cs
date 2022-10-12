using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeSkipRope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] separator = new string[] { " " };
            string stringInput = Console.ReadLine();

            List<char> stringToChar = new List<char>(stringInput);

            List<int> saveNumbersFromListOfString = new List<int>();
            List<char> saveChar = new List<char>();
            List<char> takeList = new List<char>();
            List<char> skipList = new List<char>();

            for (int i = 0; i < stringToChar.Count; i++)
            {
                if (stringToChar[i] >= '0' && stringToChar[i] <= '9')
                {
                    saveNumbersFromListOfString.Add(stringToChar[i]);
                }
                else
                {
                    saveChar.Add(stringToChar[i]);
                }
            }

            for (int i = 0; i < saveNumbersFromListOfString.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add((char)saveNumbersFromListOfString[i]);
                }
                else
                {
                    skipList.Add((char)saveNumbersFromListOfString[i]);
                }
            }

            int counter = 0;
            string result = String.Empty;
            int skipChars = 0;

            while (counter < takeList.Count)
            {
                for (int i = 0; i < skipList.Count; i++)
                {
                    if (takeList[i] != 0)
                    {
                        for (int j = 0 + ; j < takeList[i]; j++)
                        {
                            result += saveChar[takeList[j]];
                        }            
                    }
                }

                
            }
        }
    }
}
