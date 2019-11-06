using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekStacks
{
    class ArrayStack<T>
    {
        T[] data;
        public int index = 0; 

        public ArrayStack(int capacity)
        {
            data = new T[capacity];
        }

        public void Push(T value)
        {
            if(index < data.Length)
            {
                data[index] = value;
                index++;
            }
            else
            {
                throw new ArgumentException("The Stack is Full! Use the Resize tool if you would like to make the stack larger.");
            } 
        }

        public T Pop()
        {
            T poppedVar = data[index - 1];
            index--;
            return poppedVar;
        }

        public T Peek()
        {
            T topOfStack = data[index - 1];

            return topOfStack; 
        }

        public void Resize(int size)
        {
            if(size < 0)
            {
                throw new ArgumentException("Invalid Size.");
            }

            T[] tempArray = new T[size];

            if (size > index)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    tempArray[i] = data[i];
                }
            }
            else if(size < index)
            {
                for(int i = 0; i < size; i++)
                {
                    tempArray[i] = data[i];
                }
            }

            index = size;
            data = tempArray;
        }

        public void Clear()
        {
            index = 0; 
        }

        public bool isEmpty()
        {
            if(index == 0)
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }

        public void PrintOut()
        {
            for(int i = index - 1; i >= 0; i--)
            {
                Console.WriteLine(data[i]);
            }
            if (index == 0)
            {
                Console.WriteLine("This List is Empty!");
            }
        }
    }
}
