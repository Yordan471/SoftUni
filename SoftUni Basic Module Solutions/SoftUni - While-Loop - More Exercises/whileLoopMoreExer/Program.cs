using System;

namespace whileLoopMoreExer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numBottles = int.Parse(Console.ReadLine());

            int bottle = 750;
            string command = "";
            int counter = 0;
            int allDishes = 0;
            int dish = 5;
            int pot = 15;
            bool lessThenZero = false;
            bool enough = false;
            int numDishes = 0;
            int allPots = 0;
           
            int bottlesValue = numBottles * bottle;

            while (command != "End")
            {
                command = Console.ReadLine();

                if (command == "End")
                {
                    enough = true;
                    break;
                }

                numDishes = int.Parse(command);                
                counter++;                

                if (counter % 3 != 0)
                {
                    allDishes += numDishes;
                    int numDishesValue = numDishes * dish;
                    bottlesValue -= numDishesValue;

                    if (bottlesValue <= 0)
                    {
                        lessThenZero = true;
                        break;
                    }
                }

                else
                {
                    allPots += numDishes;
                    int numDishesValue = numDishes * pot;
                    bottlesValue -= numDishesValue;

                    if (bottlesValue <= 0)
                    {
                        lessThenZero = true;
                        break;
                    }
                }
            }
            if (enough)
            {               
                Console.WriteLine($"Detergent was enough!");
                Console.WriteLine($"{allDishes} dishes and {allPots} pots were washed.");
                Console.WriteLine($"Leftover detergent {Math.Abs(bottlesValue)} ml.");
            }
            if (lessThenZero)
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(bottlesValue)} ml. more necessary!");
            }
        }
    }
}
