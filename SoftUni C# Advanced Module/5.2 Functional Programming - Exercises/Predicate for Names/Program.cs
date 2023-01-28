int namesLength = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Predicate<string> match = name => name.Length <= namesLength;
Func<string[], Predicate<string>, List<string>> asd = (names, match) =>
{
    List<string> currNames = new List<string>();

    foreach (string name in names)
    {
        if (match(name))
        {
            currNames.Add(name);
        }
    }

    return currNames;
};

List<string> filteredNames = new();

filteredNames = asd(names, match);

Console.WriteLine(string.Join(Environment.NewLine, filteredNames));


    
