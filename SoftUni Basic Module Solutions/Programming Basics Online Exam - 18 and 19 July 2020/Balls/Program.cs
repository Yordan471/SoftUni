using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int redBalls = 0;
            int orangeBalls = 0;
            int yellowBalls = 0;
            int whiteBalls = 0;
            int blackBalls = 0;
            int diffColor = 0;
            int sum = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string balls = Console.ReadLine();

                switch (balls)
                {
                    case "red":
                        sum += 5;
                        redBalls++; break;
                    case "orange":
                        sum += 10;
                        orangeBalls++; break;
                    case "yellow":
                        sum += 15;
                        yellowBalls++; break;
                    case "white":
                        sum += 20;
                        whiteBalls++; break;
                    case "black":
                        sum /= 2;
                        blackBalls++; break;
                    default:
                        diffColor++; break;
                }
            }
            Console.WriteLine($"Total points: {sum}");
            Console.WriteLine($"Red balls: {redBalls}");
            Console.WriteLine($"Orange balls: {orangeBalls}");
            Console.WriteLine($"Yellow balls: {yellowBalls}");
            Console.WriteLine($"White balls: {whiteBalls}");
            Console.WriteLine($"Other colors picked: {diffColor}");
            Console.WriteLine($"Divides from black balls: {blackBalls}");
        }
    }
}
