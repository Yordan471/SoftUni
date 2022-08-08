using System;

namespace FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double obem = length * width * height;
            double obemL = obem * 0.001;
            double neededLiters = obemL * (1 - percent / 100);

            Console.WriteLine(neededLiters);
        }
    }
}
