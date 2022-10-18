using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace TakeSkipRope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string decryptedMessage = Console.ReadLine();
            List<char> lettersFromMessage = new List<char>();

            List<int> digitsFromMessage = new List<int>();

            for (int i = 0; i < decryptedMessage.Length; i++)
            {
                if (char.IsDigit(decryptedMessage[i]))
                {
                    digitsFromMessage.Add(int.Parse(decryptedMessage[i].ToString()));
                }
                else
                {
                    lettersFromMessage.Add(decryptedMessage[i]);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            
            for (int i = 0; i < digitsFromMessage.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(digitsFromMessage[i]);
                }
                else
                {
                    skipList.Add(digitsFromMessage[i]);
                }
            }

            string result = string.Empty;
            int skipCount = 0;
            int takeCount = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                if (takeList[i] > 0)
                {
                    for (int j = skipCount + takeCount; j < takeList[i] + takeCount + skipCount; j++)
                    {
                        if (j == lettersFromMessage.Count)
                        {
                            break;
                        }
                        result += lettersFromMessage[j];
                    }                  
                }

                skipCount += skipList[i];
                takeCount += takeList[i];
            }

            Console.WriteLine(result);
        }
    }
}
