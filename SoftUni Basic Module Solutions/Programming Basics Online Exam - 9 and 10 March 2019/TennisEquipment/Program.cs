using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tennisRаcket = double.Parse(Console.ReadLine());
            int numTennisRackets = int.Parse(Console.ReadLine());
            int numPairTrainers = int.Parse(Console.ReadLine());

            double pairTrainersPrice = tennisRаcket * (1 * 1.0 / 6 * 1.0);
            double allPairsTrainersPrice = pairTrainersPrice * numPairTrainers * 1.0;
            double allTennisRacketsPrice = numTennisRackets * 1.0 * tennisRаcket;

            double sumOfPairdTrainersAndTennisRackets = allPairsTrainersPrice + allTennisRacketsPrice;
            double otherThingsPrice = sumOfPairdTrainersAndTennisRackets * 0.20;

            double sumOfAll = otherThingsPrice + sumOfPairdTrainersAndTennisRackets;

            double priceFromDjokovic = sumOfAll * (1 * 1.0 / 8 * 1.0);
            double priceFromSponsors = sumOfAll * (7 * 1.0 / 8 * 1.0);

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(priceFromDjokovic)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(priceFromSponsors)}");
        }
    }
}
