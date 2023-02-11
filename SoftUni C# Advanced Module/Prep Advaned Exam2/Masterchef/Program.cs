using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientsInBasket = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] freshnessOfIngredients = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ingredients = new Queue<int>(ingredientsInBasket);
            Stack<int> freshness = new Stack<int>(freshnessOfIngredients);

            Dictionary<int, string> freshnessAndDish = new Dictionary<int, string>()
            {
                { 150, "Dipping sauce"},
                { 250, "Green salad"},
                { 300, "Chocolate cake"},
                { 400, "Lobster"}
            };
            Dictionary<string, int> dishAndCount = new Dictionary<string, int>();

            while (ingredients.Count != 0 && freshness.Count != 0)
            {
                if (ingredients.Peek() != 0 && freshnessAndDish.ContainsKey(ingredients.Peek() * freshness.Peek()))
                {
                    if (!dishAndCount.ContainsKey(freshnessAndDish[ingredients.Peek() * freshness.Peek()]))
                    {
                        dishAndCount.Add(freshnessAndDish[ingredients.Peek() * freshness.Peek()], 0);
                    }

                    dishAndCount[freshnessAndDish[ingredients.Peek() * freshness.Peek()]]++;
                    ingredients.Dequeue();
                    //freshness.Pop();
                }
                else if (ingredients.Peek() != 0)
                {
                    //freshness.Pop();
                    int removedIngredient = ingredients.Dequeue() + 5;
                    int[] rearangeIngredients = new int[ingredients.Count + 1];
                    int count = 0;

                    while (ingredients.Count > 0)
                    {      
                        rearangeIngredients[count] = ingredients.Dequeue();
                        count++;
                    }

                    rearangeIngredients[rearangeIngredients.Length - 1] = removedIngredient;
                    ingredients = new Queue<int>(rearangeIngredients);
                }
                else
                {
                    ingredients.Dequeue();
                    continue;
                }

                freshness.Pop();
            }

            if (dishAndCount.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            
            if (ingredients.Count > 0)
            {
                int sum = ingredients.Sum();
                Console.WriteLine($"Ingredients left: {sum}");
            }

            if (dishAndCount.Count > 0)
            {
                foreach (var dish in dishAndCount.OrderBy(d => d.Key))
                {
                    Console.WriteLine($"# {dish.Key} --> {dish.Value}");
                }
            }
        }
    }
}
