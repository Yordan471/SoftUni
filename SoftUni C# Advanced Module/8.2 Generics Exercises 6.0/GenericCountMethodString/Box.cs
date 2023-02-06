using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodString
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> items { get; set; }

        public Box()
        {
            items = new List<T>();
        }

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            // tupple
            (items[secondIndex], items[firstIndex]) =
                (items[firstIndex], items[secondIndex]);
        }

        public int Count(T itemToCompare)
        {
            int count = 0;

            foreach (T item in items)
            {
                if (item.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
