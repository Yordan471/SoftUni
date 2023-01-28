using System.Security.Cryptography.X509Certificates;

List<string> people = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string command = string.Empty;

while ((command = Console.ReadLine()) != "Party!")
{
    string[] operations = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string operation = operations[0];
    string filter = operations[1];
    string value = operations[2];

    if (operation == "Remove")
    {
        people.RemoveAll(GetPredicate(filter, value));
    }
    else
    {
        List<string> peopleToDouble = people.FindAll(GetPredicate(filter, value));

        foreach (string person in peopleToDouble)
        {
            int index = people.FindIndex(p => p == person);
            people.Insert(index, person);
        }
    }
}

if (people.Any())
{
    Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}

static Predicate<string> GetPredicate(string filter, string value)
{
    switch (filter)
    {
        case "StartsWith":
            return x => x.StartsWith(value);
        case "EndsWith":
            return x => x.EndsWith(value);
        case "Length":
            return x => x.Length == int.Parse(value);
        default:
            return default;
    }
}
