using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaContestOldV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coffeeQuantities = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => int.Parse(c))
                .ToArray();

            int[] milkQuantities = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => int.Parse(c))
                .ToArray();

            Queue<int> coffeeQ = new Queue<int>(coffeeQuantities);
            Stack<int> milkQ = new Stack<int>(milkQuantities);

            Dictionary<string, int> coffeeAndAmount = new Dictionary<string, int>();

            Dictionary<int, string> coffeeAndPrice = new Dictionary<int, string>();
            coffeeAndPrice.Add(50, "Cortado");
            coffeeAndPrice.Add(75, "Espresso");
            coffeeAndPrice.Add(100, "Capuccino");
            coffeeAndPrice.Add(150, "Americano");
            coffeeAndPrice.Add(200, "Latte");

            while (coffeeQ.Count != 0 && milkQ.Count != 0)
            {
                int mixedAmount = 0;
                mixedAmount = coffeeQ.Peek() + milkQ.Peek();

                if (coffeeAndPrice.ContainsKey(mixedAmount))
                {
                    string coffeeName = coffeeAndPrice[mixedAmount];

                    if (!coffeeAndAmount.ContainsKey(coffeeName))
                    {
                        coffeeAndAmount.Add(coffeeName, 0);
                    }

                    coffeeQ.Dequeue();
                    milkQ.Pop();
                    coffeeAndAmount[coffeeName]++;
                    continue;
                }

                coffeeQ.Dequeue();
                int currMilk = milkQ.Pop() - 5;
                milkQ.Push(currMilk);
            }

            if (coffeeQ.Count == 0 && milkQ.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeQ.Count > 0)
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffeeQ)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milkQ.Count > 0)
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milkQ)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }

            foreach (var coffee in coffeeAndAmount.OrderBy(a => a.Value).ThenByDescending(c => c.Key))
            {
                Console.WriteLine($"{coffee.Key}: {coffee.Value}");
            }
        }
    }
}
