using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekDynamicArray
{
    class List<T>
    {
        T[] numbers;
        public List()
        {
            numbers = new T[0];
        }

        public void Add(T newItem)
        {
            T[] tempArray = new T[numbers.Length + 1];
            for(int i = 0; i < numbers.Length; i++)
            {
                tempArray[i] = numbers[i];
            }
            tempArray[tempArray.Length - 1] = newItem;
            numbers = tempArray; 
        }

        // create a function called IndexOf which takes a number and returns the index of it, -1 if not found
        public int IndexOf(T item)
        {
            int index = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].Equals(item))
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
            if (index == -1)
            {
                return;
            }
            
            T[] tempArray = new T[numbers.Length - 1];
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if(i != index)
                {
                    tempArray[count] = numbers[i];
                    count++;
                }
            }
            numbers = tempArray; 
        }

        public void PrintList()
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]} ");
            } 
        }
    }
}
