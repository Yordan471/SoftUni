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

while (node != null)
{
    Console.WriteLine(node.Value);
    node = node.Next;
}
