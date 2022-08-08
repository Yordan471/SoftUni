using System;

namespace Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int cakePieces = width * length;

            while (cakePieces > 0)
            {
                string input = Console.ReadLine();

                if (input == "STOP")
                {
                    break;
                }
                //int currentReq = int.Parse(input);
                cakePieces -= int.Parse(input);
            }
            if (cakePieces > 0)
            {
                Console.WriteLine($"{cakePieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakePieces)} pieces more.");
            }
        }
    }
}
