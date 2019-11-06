using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekCircularlyLinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }
        
        public Node(T value, Node<T> next = null, Node<T> prev = null)
        {
            Value = value;
            Next = next;
            Prev = prev;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
