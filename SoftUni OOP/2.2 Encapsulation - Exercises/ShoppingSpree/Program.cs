
using ShoppingSpree;

List<Person> people = new();
List<Product> products = new();

string[] peopleInfo = Console.ReadLine()
    .Split(";", StringSplitOptions.RemoveEmptyEntries);
string[] productsInfo = Console.ReadLine()
    .Split(";", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < peopleInfo.Length; i++)
{
    string name = peopleInfo[i].Split("=")[0].ToString();
    decimal money = decimal.Parse(peopleInfo[i].Split("=")[1].ToString());

    try
    {
        Person person = new(name, money);
        people.Add(person);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }   
}

for (int i = 0; i < productsInfo.Length; i++)
{
    string name = productsInfo[i].Split("=")[0].ToString();
    decimal money = decimal.Parse(productsInfo[i].Split("=")[1].ToString());

    try
    {
        Product product = new(name, money);
        products.Add(product);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

string command = string.Empty;

while ((command = Console.ReadLine()) != "END")
{
    string[] commandInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string name = commandInfo[0];
    string product = commandInfo[1];

    Person findPerson = new();
    Product findProduct = new();

    findProduct.GetProduct(product);
    findPerson.GetPerson(name);

    if (!findPerson.AddProduct(findProduct))
    {
        Console.WriteLine($"{findPerson.Name} can't afford {findProduct.Name}");
    }
    else
    {
        Console.WriteLine($"{findPerson.Name} bought {findProduct.Name}");
    }
}

foreach (var person in people)
{
    Console.WriteLine(person);
}

