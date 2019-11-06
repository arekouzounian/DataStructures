using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekDynamicArray
{
    class GenericList<T>
    {
        //create a list using generics
        T[] values;
        public GenericList()
        {
            values = new T[0];
        }

        public void Add(T newItem)
        {
            T[] tempArray = new T[values.Length + 1];
            for (int i = 0; i < values.Length; i++)
            {
                tempArray[i] = values[i];
            }
            tempArray[tempArray.Length - 1] = newItem;
            values = tempArray; 
        }

        // contains - returns true if in list, false otherwise
        public bool Contains(T item)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if(values[i].Equals(item))
                {
                    return true; 
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            int index = -1; 
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Equals(item))
                {
                    index = i;
                    break; 
                }
            }
            return index; 
        }

        public void Remove(T itemRemoved)
        {
            int index = IndexOf(itemRemoved);
            if (index == - 1)
            {
                return; 
            }
            T[] tempArray = new T[values.Length - 1];
            int count = 0; 
            for (int i = 0; i < values.Length; i++)
            {
                if (i != index)
                {
                    tempArray[count] = values[i];
                    count++;
                }
            }
            values = tempArray; 
        }

        public void PrintList()
        {
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"{values[i]}");
            }
        }
    }
}
