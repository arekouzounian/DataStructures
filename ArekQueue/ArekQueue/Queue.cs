using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArekCircularlyLinkedList; 

namespace ArekQueue
{
    class Queue<T>
    {
        private CircularlyLinkedList<T> data = new CircularlyLinkedList<T>();

        public Queue()
        {

        }

        public void Enqueue(T value)
        {
            data.AddLast(value);
        }

        public T Dequeue()
        {
            var temp = data.Head;
            data.RemoveFirst();
            return temp.Value; 
        }

        public T Peek()
        {
            var temp = data.Head;
            return temp.Value;
        }

        public void Clear()
        {
            data.Clear(); 
        }

        public bool isEmpty()
        {
            return data.IsEmpty;  
        }
    }
}
