using System;

namespace SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pensPack, markerPack, preparationPack;

            pensPack = 5.80;
            markerPack = 7.20;
            preparationPack = 1.20;

            Console.WriteLine(" ");
            double numPens = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            double numMarkers = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            double liters = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            double discount = int.Parse(Console.ReadLine());

            double sumAll = numPens * pensPack + numMarkers * markerPack + liters * preparationPack;
            double resultDiscount = sumAll - (sumAll * discount / 100);

            Console.WriteLine(resultDiscount);
        }
    }
}
