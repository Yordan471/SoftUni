using BorderControl;

string command = string.Empty;

List<IIdentifiable> identifiers = new();
IIdentifiable identifier;

while ((command = Console.ReadLine()) != "End")
{
    string[] inputInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (inputInfo.Length == 3)
    {
        string name = inputInfo[0];
        int age = int.Parse(inputInfo[1]);
        string id = inputInfo[2];

        identifier = new Citizen(name, age, id);
    }
    else
    {
        string model = inputInfo[0];
        string id = inputInfo[1];

        identifier = new Robot(model, id);
    }

    identifiers.Add(identifier);
}

string lastDigitsOfFakeId = Console.ReadLine();

foreach (IIdentifiable ident in identifiers)
{
    if (ident.Id.Substring(ident.Id.Length - lastDigitsOfFakeId.Length, lastDigitsOfFakeId.Length)
        .Equals(lastDigitsOfFakeId))
    {
        //string sub = ident.Id.Substring(ident.Id.Length - 3, 3);
        Console.WriteLine(ident.Id);
    }
}
