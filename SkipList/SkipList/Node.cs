using System;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    class Node<T>
    {
        public Node<T>[] NextPool;
        public T Value;
        public int Height => NextPool.Length;

        //indexer to access neighbor nodes
        public Node<T> this[int index]
        {
            get
            {
                return NextPool[index];
            }
            set
            {
                NextPool[index] = value;
            }
        }
        //creating an overload of the constructor without a passed in value 
        //it then calls the actual constructor with the default value of T passed in as the value
        public Node(int height) : this(default, height) { }

        public Node(T value, int height)
        {
            Value = value;
            NextPool = new Node<T>[height];
        }

        public void IncrementHeight()
        {
            var temp = new Node<T>[Height + 1];
            for(int i = 0; i < Height; i++)
            {
                temp[i] = NextPool[i];
            }
            NextPool = temp; 
        }
    }
}
