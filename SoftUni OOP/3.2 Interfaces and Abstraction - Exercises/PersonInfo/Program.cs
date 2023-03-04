using PersonInfo;

string name = Console.ReadLine();
int age = int.Parse(Console.ReadLine());
string id = Console.ReadLine();
string birthdate = Console.ReadLine();

Citizen citizen = new(name, age, id, birthdate);
IPerson person = new Citizen(name , age, id, birthdate);
IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
IBirthable birthable = new Citizen(name, age, id, birthdate);

Console.WriteLine(person.Name);
Console.WriteLine(person.Age);
Console.WriteLine(identifiable.ID);
Console.WriteLine(birthable.Birthdate);