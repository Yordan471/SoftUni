using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (i <= 9)
                {
                    if (i == 5 || i == 7)
                    {
                        Console.WriteLine($"{i} -> True");
                    }
                    else
                    {
                        Console.WriteLine($"{i} -> False");
                    }
                }
                else if (i >= 10)
                {
                    int firstNum = i / 10;
                    int secondNum = i % 10;

                    if (firstNum + secondNum == 5 || firstNum + secondNum == 7 ||
                        firstNum + secondNum == 11)
                    {
                        Console.WriteLine($"{i} -> True");
                    }
                    else
                    {
                        Console.WriteLine($"{i} -> False");
                    }
                }
            }
        }
    }
}
