using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekCircularlyLinkedList
{
    public class CircularlyLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail
        {
            get
            {
                if(Head.Prev == null)
                {
                    return Head; 
                }
                return Head.Prev;
            }
        }
        public int Count;
        public Node<T> Find(T value)
        {
            var temp = Head;
            do
            {
                if(temp.Value.Equals(value))
                {
                    return temp;
                }
                temp = temp.Next;
            } while(temp != Head);

            return null;  
        }

        public void AddFirst(T value)
        {
            Node<T> temp = new Node<T>(value);


            if(Head == null)
            {
                Head = temp;
                Head.Next = Head;
                Head.Prev = Head; 
            }
            else if (Head != null)
            {
                temp.Next = Head;
                Head = temp;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            if (IsEmpty)
            {
                Head = new Node<T>( value);
                Head.Next = Head;
                Head.Prev = Head;
                Count++;
                return;
            }

            var temp = new Node<T>( value, Head, Tail);
            Tail.Next = temp;
            Head.Prev = temp;
            Count++;
        }

        public void AddBefore(Node<T> node, T value)
        {
            if (IsEmpty)
            {
                Head = new Node<T>(value);
                Head.Prev = Head;
                Count++;
                return;
            }

            var temp = new Node<T>(value);
            node.Prev.Next = temp;
            node.Prev = temp;
            temp.Next = node;
            Count++;
            
        }

        //pass in node and link
        public void AddAfter(Node<T> node, T value)
        {
            var temp = new Node<T>(value);
            if(Head == null)
            {
                Head = temp; 
            }
            else if(Head != null)
            {
                node.Next.Prev = temp;
                temp.Next = node.Next;
                node.Next = temp;
                temp.Prev = node;
            }
            Count++;
        }

        public void Remove (T value)
        {
            if(Count == 0)  
            {
                Console.WriteLine("The List is Empty!");
            }
            else
            {
                var temp = Find(value);
                temp.Prev.Next = temp.Next;
                temp.Next.Prev = temp.Prev;
                Count--;
                //set prev link of next node
            }
        }

        public void RemoveFirst()
        {
            if(Count == 0)
            {
                Console.WriteLine("The List is Empty!");
            }
            else
            {
                var temp = Head.Next;
                temp.Prev = Tail;
                Tail.Next = temp;
                Head = temp;
                Count--;
            }
        }

        public void RemoveLast()
        {
            if (Count == 0)
            {
                Console.WriteLine("The List is Empty!");
            }
            else
            {
                var temp = Tail;
                temp.Prev.Next = Head;
                Head.Prev = temp.Prev;
                Count--;
                //head prev
            }
        }

        public bool Contains(T item)
        {
            if (Find(item).Equals(null))
            {
                return false;
            }
            else
            {
                return true; 
            }
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public void PrintList()
        {
            if (IsEmpty == false)
            {
                var current = Head;
                do
                {
                    Console.WriteLine(current);
                    current = current.Next;
                } while (current != Head && current != null);
            }
            else
            {
                Console.WriteLine("This List is Empty!");
            }
        }

        public bool IsEmpty
        {
            get
            {
                return Head == null;
            }
        }


        //AddFirst(T Value) --
        //AddLast(T Value) --
        //AddBefore(Node<T> node, T value) --
        //AddAfter(Node<T> node, T value) --
        //Remove(T value) --
        //RemoveFirst -- 
        //RemoveLast --
        //Node Find(T Value) --
        //Contains(T value) -- 
        //Clear -- 

    }
}
