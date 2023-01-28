using System.Security.Cryptography.X509Certificates;

List<string> people = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Dictionary<string, Predicate<string>> filters = new();

string command = string.Empty;

while ((command = Console.ReadLine()) != "Print")
{
    string[] operations = command
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    string operation = operations[0];
    string filter = operations[1];
    string value = operations[2];

    if (operation == "Add filter")
    {
        filters.Add(filter + value, GetPredicate(filter, value));
    }
    else
    {
        filters.Remove(filter + value);
    }
}

foreach (var filter in filters)
{
    people.RemoveAll(filter.Value);
}

 Console.WriteLine(string.Join(" ", people));


static Predicate<string> GetPredicate(string filter, string value)
{
    switch (filter)
    {
        case "Starts with":
            return x => x.StartsWith(value);
        case "Ends with":
            return x => x.EndsWith(value);
        case "Contains":
            return x => x.Contains(value);
        case "Length":
            return x => x.Length == int.Parse(value);
        default:
            return default;
    }
}
