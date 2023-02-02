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




