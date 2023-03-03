
using ShoppingSpree;

List<Person> people = new();
List<Product> products = new();

string[] peopleInfo = Console.ReadLine()
    .Split(";");
string[] productsInfo = Console.ReadLine()
    .Split(";");

try
{
    foreach (string peopleInf in peopleInfo)
    {
        string name = peopleInf.Split("=")[0].ToString();
        decimal money = decimal.Parse(peopleInf.Split("=")[1].ToString());

        Person person = new(name, money);
        people.Add(person);
    }
                  
    foreach (string productInf in productsInfo)
    {
        string name = productInf.Split("=").ToString();
        decimal money = decimal.Parse(productInf.Split("=").ToString());

        Product product = new(name, money);
        products.Add(product);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}


string command = string.Empty;

while ((command = Console.ReadLine()) != "END")
{
    string[] commandInfo = command
        .Split(" ");

    string name = commandInfo[0];
    string product = commandInfo[1];

    Product findProduct = products.FirstOrDefault(p => p.Name == product);
    Person findPerson = people.FirstOrDefault(p => p.Name == name);

    
    if (findPerson is not null && findProduct is not null)
    {
        Console.WriteLine(findPerson.AddProduct(findProduct));
    }   
}

if (people.Count > 0)
{
    Console.WriteLine(string.Join(Environment.NewLine, people));
}


