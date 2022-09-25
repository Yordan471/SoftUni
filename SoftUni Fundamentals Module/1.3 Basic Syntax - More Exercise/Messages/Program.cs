using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string sNumber = Console.ReadLine();
            int number = int.Parse(sNumber);

            int mainDigit = 0;
            int offset = 0;
            int letterIndex = 0;
            int counter = -1;
            int counterTwo = -1;
            bool letter = false;
            string word = "";
            

            for (int j = 1; j <= number; j++)
            {
                //reading user input
                string sNumbers = Console.ReadLine();

                //parsing int so I can use it later;
                int numbers = int.Parse(sNumbers);

                //checking if we have 0 as a number, cuz it is empty space
                if (numbers == 0)
                {
                    word += " ";
                    continue;
                }
           
                //delete with remainder to pick the mainDigit in number
                mainDigit = numbers % 10;

                //getting offset
                offset = (mainDigit - 2) * 3;

                
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset += 1;
                }

                letterIndex = (offset + sNumbers.Length - 1);

                //two loops so we can asign letter to letterIndex
                for (int k = 0; k <= 26; k++)
                {
                    counter++;

                    if (k == letterIndex)
                    {

                        for (int l = 97; l <= 122; l++)
                        {
                            counterTwo++;

                            if (counter == counterTwo)
                            {
                                word += (char)l;
                                letter = true;
                                break;
                            }
                        }
                    }

                    if (letter)
                    {
                        break;
                    }
                }

                letter = false;
            }

            Console.WriteLine(word);
        }
    }
}
