using LinkedList;
using System.Diagnostics;

int Insertions = 100000;
Stopwatch watch = Stopwatch.StartNew();
Console.WriteLine("Insert numbers in List:");
watch.Start();
// insert numbers in List<int>
InsertFirst(Insertions);

watch.Stop();
Console.WriteLine($"{watch.ElapsedMilliseconds} milliseconds");
Console.WriteLine($"{watch.ElapsedMilliseconds / 100 * 1.00:f2} seconds");
Console.WriteLine();

Console.WriteLine("Add numbers in CustomLinkedList:");
//Stopwatch watchLinkedList = Stopwatch.StartNew();
watch = Stopwatch.StartNew();
// insert numbers in List<int>
InsertLinkedList(Insertions);

watch.Stop();
Console.WriteLine($"{watch.ElapsedMilliseconds} milliseconds");
Console.WriteLine($"{watch.ElapsedMilliseconds / 100 * 1.00:f2} seconds");

void InsertFirst(int insertions)
{
    List<int> list = new();

    for (int i = 0; i < insertions; i++)
    {
        list.Insert(0, i);
    }
}

void InsertLinkedList(int insertions)
{
    CustomLinkedList linkedList = new();

    for (int i = 0; i < insertions; i++)
    {
        linkedList.AddFirst(i);
    }
}