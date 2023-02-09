using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomHashSet
{
    public class MyHashSet
    {
        // Matrix, with List of strings arrays;
        private List<string>[] internalArray;

        // Keep count so we know if we have to resize our array
        private int count = 0;

        public MyHashSet()
        {
            // Default length of our array
            internalArray = new List<string>[8];
        }

        public void Add(string element)
        {
            // Here we get the index from the HashFunction method, where our string will be stored
            int index = HashFunction(element, internalArray.Length);

            // If we don't have defined Array at this index, we create one
            if (internalArray[index] == null)
            {
                internalArray[index] = new List<string>();
            }

            // Add element at position index
            internalArray[index].Add(element);
            count++;

            if (count / (float)internalArray.Length * 100 > 60)
            {
                Resize();
            }
        }

        private void Resize()
        {
            var newArray = new List<string>[internalArray.Length * 2];
            // Use for cicle == array's Length
            for (int i = 0; i < internalArray.Length; i++)
            {
                // If given index array in our List is not null
                if (internalArray[i] != null)
                {
                    // If any given element in our current index Array is == to
                    // the element at these "coordinates"
                    for (int j = 0; j < internalArray[i].Count; j++)
                    {
                        string elementToReHash = internalArray[i][j];

                        // Rehash the position (index) of that element
                        int index = HashFunction(elementToReHash, newArray.Length);

                        // If we don't have defined Array at this index, we create one
                        if (newArray[index] == null)
                        {
                            newArray[index] = new List<string>();
                        }

                        // Add element at position index
                        newArray[index].Add(elementToReHash);
                    }
                }
            }

            internalArray = newArray;
        }

        public bool Contains(string element)
        {
            int index = HashFunction(element, internalArray.Length);

            if (internalArray[index] != null)
            {
                // Iterate through index position array 
                for (int i = 0; i < internalArray[index].Count; i++)
                {
                    // Check if there are more then 1 element == element
                    if (internalArray[index][i] == element)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private int HashFunction(string element, int count)
        {
            int sum = 0;

            for (int i = 0; i < element.Length; i++)
            {
                // Calculate Index for our element(string) through Hesh function
                sum += element[i];
            }
                    
            // Return number == index of our internalArray
            // That's the index position our string will be stored
            // Using count, so we always have the correct size of the internalArray
            return sum % count;
        }
    }
}
