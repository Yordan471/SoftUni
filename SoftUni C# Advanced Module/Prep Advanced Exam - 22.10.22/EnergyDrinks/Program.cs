using System.ComponentModel.Design;

int[] miligramsOfCaffein = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(m => int.Parse(m))
    .ToArray();

int[] energyDrinks = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(m => int.Parse(m))
    .ToArray();

Stack<int> caffeine = new(miligramsOfCaffein);
Queue<int> eDrinks = new(energyDrinks);

int maxCaffeine = 0;
bool noCaffeine = false;
bool noDrinks = false;

while (caffeine.Count != 0 && eDrinks.Count != 0)
 {
    if (!(caffeine.Peek() * eDrinks.Peek() + maxCaffeine > 300))
    {
        maxCaffeine += caffeine.Pop() * eDrinks.Dequeue();
    }
    else
    {
        caffeine.Pop();
        int saveDrink = eDrinks.Dequeue();

        int[] shuffleDrinks = new int[eDrinks.Count + 1];
        shuffleDrinks[eDrinks.Count] = saveDrink;
        int countIndex = 0;

        while (eDrinks.Count != 0)
        {
            shuffleDrinks[countIndex++] = eDrinks.Dequeue();
        }

        eDrinks = new(shuffleDrinks);

        if (!(maxCaffeine - 30 < 0))
        {
            maxCaffeine -= 30;
        }        
    }
}

if (caffeine.Count == 0 && eDrinks.Count !=0)
{
    Console.WriteLine($"Drinks left: {string.Join(", ", eDrinks)}");
}
else
{
    Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
}

Console.WriteLine($"Stamat is going to sleep with {maxCaffeine} mg caffeine.");


