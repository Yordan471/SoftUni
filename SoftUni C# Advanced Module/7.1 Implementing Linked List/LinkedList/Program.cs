using LinkedList;

// this works like a Stack (with AddFirst)
// Or like Queue with AddLast 
CustomLinkedList linkedList = new CustomLinkedList();

linkedList.AddLast(1);
linkedList.AddLast(2);
linkedList.AddLast(3);
linkedList.AddLast(4);
linkedList.AddLast(5);

// First in last out - Stack
// First in first out - Queue
Node node = linkedList.Head;

int[] arr = linkedList.ToArray();
Console.WriteLine("Print Array from LinkedList:");
Console.WriteLine(string.Join(" ", arr));
Console.WriteLine();

Console.WriteLine("ForEach:");
// Iterate through the linked List
linkedList.ForEach(x =>
{
    Console.WriteLine($"Node {x}");
});
Console.WriteLine();

Console.WriteLine("Reversed ForEach:");

// Reversed
linkedList.ForEachReverse(x =>
{
    Console.WriteLine($"Node {x}");
});


//while (node != null)
//{
//    Console.WriteLine(node.Value);
//    node = node.Next;
//}
