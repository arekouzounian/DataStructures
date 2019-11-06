using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekSinglyLinkedList
{
    public class SinglyLinkedList<T>
    {
        SinglyLinkedNode<T> Head { get; set; }
        public int Count { get; private set; }

        //AddLast(value) --
        //AddFirst(value) --
        //AddAfter(Node, value) --
        //AddBefore(Node, value) (optional)
        //bool Contains(value)
        //Node Find(value) --

        public SinglyLinkedList()
        {
            Head = null;
            Count = 0;
        }

        public SinglyLinkedNode<T> GetHead()
        {
            return Head;
        }

        public void AddFirst(T value)
        {
            var temp = new SinglyLinkedNode<T>(value, Head);
            Head = temp;
            Count++;
        }

        public void AddLast(T value)
        {
            var temp = Head;
            while(temp.Next != null)
            {
                temp = temp.Next;
            }
            var last = new SinglyLinkedNode<T>(value, null);
            temp.Next = last;
            Count++;
        }

        public void AddAfter(T item, T value)
        {
            var temp = Find(item);
            var newNode = new SinglyLinkedNode<T>(value, temp.Next);
            Find(item).Next = newNode;
            Count++;
        }

        public void AddBefore(T item, T value)
        {
            var temp = Head;
            while (temp.Next != Find(item))
            {
                temp = temp.Next; 
            }
            var temp2 = new SinglyLinkedNode<T>(value, Find(item));
            temp.Next = temp2;
            Count++;
        }

        public bool Contains(T value)
        {
            var temp = Head; 
            while (temp != null)
            {
                temp = temp.Next;
                if(temp.Item.Equals(value))
                {
                    return true; 
                }
            }
            return false; 
            //does this work?
        }


        public void RemoveFirst()
        {
            if(Count == 0)
            {
                return; 
            }
            Head = Head.Next; 
        }

        public void RemoveLast()
        {
            if (Count == 0)
            {
                return; 
            }
            var temp = Head;
            var temp2 = Head; 
            while(temp2.Next != null)
            {
                temp2 = temp2.Next; 
            }
            while (temp.Next != temp2)
            {
                temp = temp.Next; 
            }
            temp.Next = null; 
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public SinglyLinkedNode<T> Find(T value)
        {
            var curr = Head;
            while(curr != null)
            {
                if(curr.Item.Equals(value))
                {
                    return curr;
                }
                curr = curr.Next;
            }
            return null;
        }

    }
}
