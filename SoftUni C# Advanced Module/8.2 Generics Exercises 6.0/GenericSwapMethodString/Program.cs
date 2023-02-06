using GenericSwapMethodStrings;

Box<string> box = new Box<string>();

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    string item = Console.ReadLine();
    box.AddItem(item);
}

int[] indices = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

box.Swap(indices[0], indices[1]);

Console.WriteLine(box.ToString());