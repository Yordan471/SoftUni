
using GenericCountMethodString;

Box<string> box = new Box<string>();

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    string item = Console.ReadLine();
    box.AddItem(item);
}

string compareItem = Console.ReadLine();

Console.WriteLine(box.Count(compareItem));