namespace BaristaContest
{
    public class Program
    {
        public static void Main()
        {
            int[] coffeeQuantities = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(c => int.Parse(c))
                 .ToArray();

            int[] milkQuantities = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => int.Parse(c))
                .ToArray();

            Queue<int> coffeeQ = new(coffeeQuantities);
            Stack<int> milkQ = new(milkQuantities);

            Dictionary<string, Dictionary<int, int>> coffeeAndPriceQuantity = new Dictionary<string, Dictionary<int, int>>
             {
                 { "Cortado",
                 new Dictionary<int, int> {{ 50, 0 }}}
                 ,
                 { "Espreso",
                     new Dictionary<int, int> {{75, 0}}
                 },
                 { "Capuccino",
                     new Dictionary<int, int> {{100, 0}}
                 },
                 { "Americano",
                     new Dictionary<int, int>{{ 150, 0 }}
                 },
                 {"Latte",
                     new Dictionary < int, int > {{ 200, 0 }}
                 }
             };

            while (coffeeQ.Count != 0 && milkQ.Count != 0)
            {
                int mixedAmount = 0;
                mixedAmount = coffeeQ.Peek() + milkQ.Peek();

                if (coffeeAndPriceQuantity.Values.Any(c => c.ContainsKey(mixedAmount)))
                {
                    foreach (var coffe in coffeeAndPriceQuantity.Values)
                    {
                        if (coffe.ContainsKey(mixedAmount))
                        {
                            coffe[mixedAmount]++;
                            coffeeQ.Dequeue();
                            milkQ.Pop();
                            continue;
                        }
                    }
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
                Console.WriteLine($"Coffee left: {string.Join(", ", milkQ)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }
        }
    }
}



