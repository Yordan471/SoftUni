using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] ticketsArray = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string regexPattern = @"(\@{6,}|\${6,}|\^{6,}|\#{6,})";

            Regex regex = new Regex(regexPattern);

            for (int i = 0; i < ticketsArray.Length; i++)
            {
                if (ticketsArray[i].Length == 20)
                {
                    Match leftHalf = regex.Match(ticketsArray[i].Substring(0, 10));
                    Match rightHalf = regex.Match(ticketsArray[i].Substring(10));
                    int minLength = Math.Min(leftHalf.Length, rightHalf.Length);

                    if (leftHalf.Success && rightHalf.Success)
                    {
                        string winLeftHalf = leftHalf.Value.Substring(0, minLength);
                        string winRightHalf = rightHalf.Value.Substring(0, minLength);

                        if (winLeftHalf == winRightHalf)
                        {
                            if (winLeftHalf.Length == 10)
                            {
                                Console.WriteLine($"ticket \"{ticketsArray[i]}\" - " +
                                    $"{minLength}{winLeftHalf.Substring(0, 1)} Jackpot!");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{ticketsArray[i]}\" - " +
                                    $"{minLength}{winLeftHalf.Substring(0, 1)}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticketsArray[i]}\" - " +
                                $"no match");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticketsArray[i]}\" - " +
                                $"no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }               
            }
        }
    }
}
