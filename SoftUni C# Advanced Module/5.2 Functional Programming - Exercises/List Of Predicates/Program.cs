using System;

int endOfRange = int.Parse(Console.ReadLine());

List<Predicate<int>> predicates = new();

HashSet<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(num => int.Parse(num))
    .ToHashSet();

int[] numbers  = Enumerable.Range(1, endOfRange).ToArray();

foreach (int divider in dividers)
{
    predicates.Add(num => num % divider == 0);
}

foreach (int number in numbers)
{
    bool isDivisible = true;

    foreach (var match in predicates)
    {
        if (!match(number))
        {
            isDivisible = false;
        }
    }

    if (isDivisible)
    {
        Console.WriteLine($"{number} ");
    }
}

