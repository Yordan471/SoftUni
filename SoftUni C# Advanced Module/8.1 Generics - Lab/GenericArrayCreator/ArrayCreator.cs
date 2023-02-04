using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericArrayCreator
{
    public class ArrayCreator<T>
    {
        private T[] array;

        static T[] Creater(int length, T Item)
        {
            T[] array = new T[length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Item;
            }

            return array;
        }        
    }
}
