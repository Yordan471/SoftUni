using System;

namespace MaidenParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double loveMassege = 0.60;
            double rose = 7.20;
            double keychains = 3.60;
            double caricature = 18.20;
            int luckSuprise = 22;

            double party = double.Parse(Console.ReadLine());
            int numLoveMasseges = int.Parse(Console.ReadLine());
            int numRoses = int.Parse(Console.ReadLine());
            int numKeychains = int.Parse(Console.ReadLine());
            int numCaricatures = int.Parse(Console.ReadLine());
            int numLuckSuprises = int.Parse(Console.ReadLine());

            double sum = loveMassege * numLoveMasseges + rose * numRoses + keychains * numKeychains + caricature * numCaricatures + luckSuprise * numLuckSuprises;
          
            int allArticules = numLoveMasseges + numRoses + numKeychains + numCaricatures + numLuckSuprises;

            if (allArticules >= 25)
            {
                sum = sum - (sum * 0.35);
            }
            sum -= sum * 0.1;

            if (sum >= party)
            {
                double leftoverMoney = sum - party;
                Console.WriteLine($"Yes! {leftoverMoney:f2} lv left.");
            }
            else
            {
                double leftoverMoney = party - sum;
                Console.WriteLine($"Not enough money! {leftoverMoney:f2} lv needed.");
            }
        }
    }
}
