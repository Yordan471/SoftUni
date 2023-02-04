using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        
        private List<T> list;

        private int count;

        public Box()
        {
           // count = list.Count;
            list = new List<T> { };
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Add(T element)
        {
           list.Add(element);
        }

        public T Remove()
        {
            T removedElement = list[list.Count - 1];
            list.Remove(removedElement);

            return removedElement;
        }
    }
}
