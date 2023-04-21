using BorderControl;

string command = string.Empty;

List<IMammal> mammals = new();
IMammal mammal;

while ((command = Console.ReadLine()) != "End")
{
    string[] inputInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (inputInfo.Length == 5)
    {
        string name = inputInfo[1];
        int age = int.Parse(inputInfo[2]);
        string id = inputInfo[3];
        string birthdate = inputInfo[4];

        mammal = new Citizen(name, age, id, birthdate);
        mammals.Add(mammal);
    }
    else if (inputInfo[0] == "Robot")
    {
        string model = inputInfo[1];
        string id = inputInfo[2];
    }
    else if (inputInfo[0] == "Pet")
    {
        string name = inputInfo[1];
        string birthdate = inputInfo[2];

        mammal = new Pet(name, birthdate);
        mammals.Add(mammal);
    }

    
}

string year = Console.ReadLine();

foreach (IMammal mammall in mammals)
{
    if (mammall.Birthdate.Contains(year))
    {
        Console.WriteLine(mammall.Birthdate);
    }
}
