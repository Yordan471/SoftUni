using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
      // private T[] array;
      //
      // private int length;
      //
      // private T item;
      //
      // public ArrayCreator()
      // {
      //     array= new T[0];
      // }
      //
      // public ArrayCreator(T[] array, int length, T item) : this()
      // {
      //     //this.array = array;
      //     this.length = length;
      //     this.item = item;
      // }

        public static T[] Create<T>(int length, T Item)
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
