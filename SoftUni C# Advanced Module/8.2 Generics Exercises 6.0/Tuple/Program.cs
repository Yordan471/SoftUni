using Tuple;

string[] personInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] nameAndAmountOfBeer = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

CustomTuple<string, string> nameAndAdress = new($"{personInfo[0]} {personInfo[1]}", personInfo[2]);

CustomTuple<string, int> nameAndBeer = new(nameAndAmountOfBeer[0], int.Parse(nameAndAmountOfBeer[1]));

CustomTuple<int, double> nums = new(int.Parse(numbers[0]), double.Parse(numbers[1]));

Console.WriteLine(nameAndAdress);
Console.WriteLine(nameAndBeer);
Console.WriteLine(nums);