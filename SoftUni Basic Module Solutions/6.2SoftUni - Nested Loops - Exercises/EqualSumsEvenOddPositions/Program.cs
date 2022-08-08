using System;

namespace EqualSumsEvenOddPositions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lowerValue = int.Parse(Console.ReadLine());
            int upperValue = int.Parse(Console.ReadLine());

            for (int i = lowerValue; i <= upperValue; i++)
            {
                string currentNum = i.ToString();
                int oddSum = 0;
                int evenSum = 0;
                for (int j = 0; j < currentNum.Length; j++)
                {
                    int currentDigit = int.Parse(currentNum[j].ToString());

                    if (j % 2 == 0)
                    {
                        evenSum += currentDigit;
                    }
                    else
                    {
                        oddSum += currentDigit;
                    }    
                }
                if (oddSum == evenSum)
                {
                    Console.Write(i + " ");
                }
            }           
        }
    }
}
