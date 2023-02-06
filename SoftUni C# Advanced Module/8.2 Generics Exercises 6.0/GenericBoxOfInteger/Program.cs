using GenericBoxOfInteger;

Box<int> box = new Box<int>();

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    int item = int.Parse(Console.ReadLine());
    box.AddItem(item);
}

Console.WriteLine(box.ToString());