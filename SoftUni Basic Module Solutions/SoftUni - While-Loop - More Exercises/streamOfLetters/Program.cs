﻿using System;

namespace streamOfLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression, result = "";
            bool isItCCommand = false, isItOCommand = false, isItNCommand = false;

            while (true)
            {
                expression = Console.ReadLine();

                if (isItCCommand == true && isItNCommand == true && isItOCommand == true)
                {
                    Console.Write(result + " ");
                    result = "";
                    isItCCommand = false;
                    isItOCommand = false;
                    isItNCommand = false;
                }
                
                if (expression == "End")
                {
                    break;
                }

                char letter = char.Parse(expression);

                if (((int)letter >= 65 && (int)letter <= 90 || ((int)letter >= 97 && (int)letter <= 122)))
                    {
                    if (letter == 'c' && isItCCommand == false)
                    {
                        isItCCommand = true;
                        continue;
                    }
                    else if (letter == 'c' && isItCCommand == true)
                    {
                        result = result + "" + letter;
                        continue;
                    }
                    
                    if (letter == 'o' && isItOCommand == false )
                    {
                        isItOCommand = true;
                        continue;
                    }
                    else if (letter == 'o' && isItOCommand == true)
                    {
                        result = result + "" + letter;
                        continue;
                    }

                    if (letter == 'n' && isItNCommand == false)
                    {
                        isItNCommand = true;
                        continue;
                    }
                    else if (letter == 'n' && isItNCommand == true)
                    {
                        result = result + "" + letter;
                        continue;
                    }

                    result = result + "" + letter;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
