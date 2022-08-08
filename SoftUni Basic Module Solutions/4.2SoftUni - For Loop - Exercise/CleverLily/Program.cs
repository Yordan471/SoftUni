using System;

namespace CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceW = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int birthDayMoney = 10;      
            int numOdd = 0;
            
            double savedM = 0;

            for (int i = 1; i <= age; i++)
            {                       
                if (i % 2 == 0)
                {             
                   savedM += (birthDayMoney - 1);
                   birthDayMoney += 10;
                }
                else
                {
                    numOdd++;
                }
            }
            savedM += numOdd * toyPrice;
                    
            if (savedM >= priceW)
            {
                double moneyLeft = savedM - priceW;
                Console.WriteLine($"Yes! {moneyLeft:f2}");
            }
            else
            {
                double moneyNeeded = priceW - savedM;
                Console.WriteLine($"No! {moneyNeeded:f2}");
            }       
        }
    }
}
