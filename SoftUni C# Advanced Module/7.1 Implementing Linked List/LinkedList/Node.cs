using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node
    {
        public Node() { }
        public Node(int value)
        {
            Value = value;
        }

        public Node(int value, Node next, Node previouse)
        {
            Value = value;
            Next = next;
            Previouse = previouse;
        }

        public int Value { get; set; }

        public Node Next { get; set; }

        public Node Previouse { get; set; }

        public override string ToString()
        {
            return $"{Previouse?.Value} <- {Value} -> {Next?.Value.ToString()}";
        }
    }
}
