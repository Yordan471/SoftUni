using Threeuple;

string[] personInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] nameAndAmountOfBeer = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

CustumThreeuple<string, string, string> nameAndAdress = new($"{personInfo[0]} {personInfo[1]}", personInfo[2], string.Join(" ", personInfo[3..]));

CustumThreeuple<string, int, bool> nameAndBeer = new(nameAndAmountOfBeer[0], int.Parse(nameAndAmountOfBeer[1]), nameAndAmountOfBeer[2] == "drunk");

CustumThreeuple<string, double, string> nums = new(numbers[0], double.Parse(numbers[1]), numbers[2]);

Console.WriteLine(nameAndAdress);
Console.WriteLine(nameAndBeer);
Console.WriteLine(nums);