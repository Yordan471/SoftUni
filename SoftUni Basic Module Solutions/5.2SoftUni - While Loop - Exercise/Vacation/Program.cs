using System;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double excursionMoney = double.Parse(Console.ReadLine());
            double startingMoney = double.Parse(Console.ReadLine());
            int counterDays = 0;
            int spendingDays = 0;

            while (startingMoney < excursionMoney && spendingDays < 5)
            {
                string spendSave = Console.ReadLine();
                double spendSavedSum = double.Parse(Console.ReadLine());
                counterDays++;
               
               if (spendSave == "save")
                {
                    startingMoney += spendSavedSum;
                    spendingDays = 0;
                }

               else if (spendSave == "spend")
                {
                    startingMoney -= spendSavedSum;
                    spendingDays++;
                    
                    if (startingMoney <= 0)
                    {
                        startingMoney = 0;
                    }    
                }
            }

            if (spendingDays == 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine($"{counterDays}");
            }
            
            if (startingMoney >= excursionMoney)
            {             
                Console.WriteLine($"You saved the money for {counterDays} days.");
            }    
        }
    }
}
