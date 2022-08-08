using System;

namespace HairSalon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goalOfTheDay = int.Parse(Console.ReadLine());
            string command = "";
            int sum = 0;

            while (command != "closed")
            {
                command = Console.ReadLine();
                if (command == "closed")
                {
                    break;
                }

                string haircut = Console.ReadLine();

                if (haircut == "mens")
                {
                    sum += 15;
                }
                else if (haircut == "ladies")
                {
                    sum += 20;
                }
                else if (haircut == "kids")
                {
                    sum += 10;
                }
                
                if (sum >= goalOfTheDay)
                {
                    break;
                }
                             
                if (haircut == "touch up")
                {
                    sum += 20;
                }
                else if (haircut == "full color")
                {
                    sum += 30;
                }

                if (sum >= goalOfTheDay)
                {
                    break;
                }
            }
            if (sum >= goalOfTheDay)
            {
                double earnedMoney = sum - goalOfTheDay;
                Console.WriteLine($"You have reached your target for the day!");
                Console.WriteLine($"Earned money: {sum}lv.");
            }
            else
            {
                double earnedMoney = goalOfTheDay - sum;
                Console.WriteLine($"Target not reached! You need {earnedMoney}lv. more.");
                Console.WriteLine($"Earned money: {sum}lv.");
            }
        }
    }
}
