using System;

namespace fowLoopMore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inheritanceMoney = double.Parse(Console.ReadLine());
            int ageToLive = int.Parse(Console.ReadLine());
            double moneySpendEvem = 12000;
           // double moneySpendOdd = 12050;
            int oddCounter = 0;
            int evenCounter = 0;
            int ageCounter = 17;
            int eachAgeMoney = 0;

            for (int i = 1800; i <= ageToLive; i++)
            {
                ageCounter++;
                if (i % 2 != 0)
                {
                    oddCounter++;
                    eachAgeMoney += ageCounter * 50;
                }

                else if (i % 2 == 0)
                {
                    evenCounter++;                  
                }
            }
            double allMoneySpend = moneySpendEvem * evenCounter + moneySpendEvem * oddCounter + eachAgeMoney;

            if (allMoneySpend <= inheritanceMoney)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {Math.Abs(allMoneySpend - inheritanceMoney):f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(inheritanceMoney - allMoneySpend):f2} dollars to survive.");
            }
        }
    }
}
