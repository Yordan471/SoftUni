using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mealsInput = Console.ReadLine()
                .Split();

            int[] caloriesPerDayInput = Console.ReadLine()
                .Split()
                .Select(c => int.Parse(c))
                .ToArray();

            Dictionary<string, int> mealsAndCalories = new Dictionary<string, int>()
            {
                {"salad", 350},
                {"soup", 490},
                {"pasta", 680},
                {"steak", 790}
            };
            Dictionary<string, int> eatenMealsAndCalories = new Dictionary<string, int>();

            Queue<string> meals = new Queue<string>(mealsInput);
            Stack<int> caloriesPerDay = new Stack<int>(caloriesPerDayInput);

            while (meals.Count != 0 && caloriesPerDay.Count != 0)
            {
                int leftCaloriesPerDay = caloriesPerDay.Peek() - mealsAndCalories[meals.Peek()];
              
                while (leftCaloriesPerDay > 0)
                {
                    meals.Dequeue();
                    caloriesPerDay.Pop();
                    caloriesPerDay.Push(leftCaloriesPerDay);

                    if (meals.Count == 0)
                    {
                        break;
                    }

                    leftCaloriesPerDay -= mealsAndCalories[meals.Peek()];
                }
               
                if (leftCaloriesPerDay == 0)
                {
                    meals.Dequeue();
                    if (caloriesPerDay.Count >= 1)
                    {
                        caloriesPerDay.Pop();
                    }
                    
                }
                else
                {
                    caloriesPerDay.Pop();
                    meals.Dequeue();

                    if (caloriesPerDay.Count == 0)
                    {
                        break;
                    }

                    caloriesPerDay.Push(caloriesPerDay.Pop() - Math.Abs(leftCaloriesPerDay));
                }
            }
            
            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsInput.Length} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsInput.Length - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
