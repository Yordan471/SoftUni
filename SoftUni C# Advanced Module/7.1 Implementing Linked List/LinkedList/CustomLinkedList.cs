using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class CustomLinkedList
    {
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(int value)
        {
            // This is how the code for Stack works
            // Taking Count of the nodes
            Count++;

            Node node = new Node(value);

            // If Head is null  then Head and Tail will take the same Value
            // They are the same element
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            // This is for Stack!
            // This new node (if they are more then 1) will be Head
            // The old Head will be Tail (if there are only 2 eleents)
            node.Next = Head;
            // 
            Head.Previouse = node;
            // Head now is the new node
            Head = node;
        }

        public void AddLast(int value)
        {
            // This is how the code for Queue works
            Count++;
            Node node = new Node(value);

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            // This is for Queue!
            node.Previouse = Tail;
            Tail.Next = node;
            Tail = node;
        }

        public void RemoveFirst(int value)
        {
            // Remove element from the start
            // For Stack
            Count--;

            // If we dont have more elements to remove
            if (Head.Next == null)
            {
                Head = null;
                Tail = null;
            }

            Node oldHead = Head;

            Head = Head.Next;

            oldHead.Next = null;

            Head.Previouse = null;
        }

        public void RemoveLast(int value)
        {
            Count--;
            // Removing element for Queue
            if (Tail.Previouse == null)
            {
                Tail = null;
                Head = null;
            }
            Node oldTail = Tail;

            Tail = Tail.Previouse;

            oldTail.Previouse = null;

            Tail.Next = null;
        }

        public void ForEach(Action<int> callback)
        {
            // With this method we iterate through the linkedList
            Node current = Head;

            while (current != null)
            {
                callback(current.Value);
                current = current.Next;
            }
        }

        public void ForEachReverse(Action<int> callback)
        {
            // reversed iteration 
            Node current = Tail;

            while (current != null)
            {
                callback(current.Value);
                current = current.Previouse;
            }
        }

        public int[] ToArray()
        {
            // Fill an array from our LinkedList
            int[] array = new int[Count];
            int i = 0;
            // for every index "i" in array add node;
            ForEach(n =>
            {
                array[i++] = n;
            });

            return array;
        }
    }
}
