int[] textilesInput = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(t => int.Parse(t))
    .ToArray();

int[] medicamentsInput = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(m => int.Parse(m))
    .ToArray();

Queue<int> textile = new(textilesInput);
Stack<int> medicaments = new(medicamentsInput);

Dictionary<int, string> resourceAndItem = new()
{
    { 30, "Patch" },
    { 40, "Bandage" },
    { 100, "MedKit" }
};

Dictionary<string, int> itemAndAmount = new();

while (textile.Count != 0 && medicaments.Count != 0)
{
    int firstTextile = textile.Peek();
    int lastMedicament = medicaments.Peek();
    int mix = firstTextile + lastMedicament;

    if (resourceAndItem.ContainsKey(mix))
    {
        string item = resourceAndItem[mix];

        if (!itemAndAmount.ContainsKey(item))
        {
            itemAndAmount.Add(item, 0);
        }

        itemAndAmount[item]++;
        medicaments.Pop();
    }
    else if (!resourceAndItem.ContainsKey(mix))
    {
        if (mix > 100)
        {
            if (!itemAndAmount.ContainsKey("MedKit"))
            {
                itemAndAmount.Add("MedKit", 0);
            }

            itemAndAmount["MedKit"]++;
            medicaments.Pop();

            int resourcesLeft = mix - 100;
            medicaments.Push(medicaments.Pop() + resourcesLeft);
        }
        else
        {
            int saveMedicament = medicaments.Pop() + 10;
            medicaments.Push(saveMedicament);
        }
    }

    textile.Dequeue();
}

if (textile.Count == 0 && medicaments.Count == 0)
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else if (!textile.Any())
{
    Console.WriteLine("Textiles are empty.");
}
else if (!medicaments.Any())
{
    Console.WriteLine("Medicaments are empty.");
}

if (itemAndAmount.Any())
{
    foreach (var item in itemAndAmount
        .OrderByDescending(i => i.Value)
        .ThenBy(i => i.Key))
    {
        Console.WriteLine($"{item.Key} - {item.Value}");
    }
}

if (medicaments.Any())
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
}

if (textile.Any())
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textile)}");
}
