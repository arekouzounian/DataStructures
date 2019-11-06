using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArekCircularlyLinkedList; 

namespace ArekStacks
{
    class LinkedListStack<T>
    {
        public CircularlyLinkedList<T> data = new CircularlyLinkedList<T>(); 

        public LinkedListStack()
        {

        }

        public void Push(T value)
        {
            if(data.IsEmpty)
            {
                data.AddFirst(value);
            }
            else
            {
                data.AddLast(value);
            }            
        }

        public T Pop()
        {
            T temp = data.Head.Value;
            data.RemoveFirst();
            return temp; 
        }

        public T Peek()
        {
            return data.Tail.Value;
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool isEmpty()
        {
            bool temp = data.IsEmpty;

            return temp; 
        }

        public void PrintOut()
        {
            var temp = data.Tail;
            do
            {
                Console.WriteLine(temp.Value);
                temp = temp.Prev; 
            } while (temp != data.Tail);
        }
    }
}
