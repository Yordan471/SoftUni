

using GenericCountMethodDouble;

Box<double> box = new Box<double>();

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    double item = double.Parse(Console.ReadLine());
    box.AddItem(item);
}

double compareItem = double.Parse(Console.ReadLine());

Console.WriteLine(box.Count(compareItem));