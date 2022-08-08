
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RandomPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumFirstDigitStart = int.Parse(Console.ReadLine());
            int firstNumSecondDigitStart = int.Parse(Console.ReadLine());
            int secondNumFirstDigitStart = int.Parse(Console.ReadLine());
            int secondNumSecondDigitStart = int.Parse(Console.ReadLine());
            int counter = 0;
            bool hasEnded = false;

            for (int firstNumFirstDig = firstNumFirstDigitStart; firstNumFirstDig <= 8; firstNumFirstDig++)
            {
                for (int firstNumSecondDig = 9; firstNumSecondDig >= firstNumSecondDigitStart; firstNumSecondDig--)
                {
                    for (int secondNumFirstDig = secondNumFirstDigitStart; secondNumFirstDig <= 8; secondNumFirstDig++)
                    {
                        for (int secondNumSecondDig = 9; secondNumSecondDig >= secondNumSecondDigitStart; secondNumSecondDig--)
                        {
                            bool isValid = firstNumFirstDig % 2 == 0 &&
                                secondNumFirstDig % 2 == 0 &&
                                firstNumSecondDig % 2 != 0 &&
                                secondNumSecondDig % 2 != 0;

                            int firstNum = firstNumFirstDig * 10 + firstNumSecondDig;
                            int secondNum = secondNumFirstDig * 10 + secondNumSecondDig;

                            if (isValid && firstNum == secondNum)
                            {
                                Console.WriteLine($"Cannot change the same player.");
                            }
                            else if (isValid && firstNum != secondNum)
                            {
                                Console.WriteLine($"{firstNumFirstDig}{firstNumSecondDig} - {secondNumFirstDig}{secondNumSecondDig}");
                                counter++;
                            }
                            if (counter >= 6)
                            {
                                hasEnded = true;
                            }
                            if (hasEnded)
                            {
                                break;
                            }
                        }
                        if (hasEnded)
                        {
                            break;
                        }
                    }
                    if (hasEnded)
                    {
                        break;
                    }
                }
                if (hasEnded)
                {
                    break;
                }
            }
        }
    }
}

