using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    class SkipList<T> : ICollection<T>
    {
        //declaring vars
        private Node<T> Head { get; set; }
        public int Count { get; private set; }
        public IComparer<T> Comparer { get; private set; }
        public bool IsReadOnly => false;



        public SkipList(IComparer<T> comparer)
        {
            Count = 0;
            Head = new Node<T>(1);
            Comparer = comparer ?? Comparer<T>.Default;
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value, ChooseRandomHeight(Head.Height + 1));

            if(newNode.Height > Head.Height)
            {
                Head.IncrementHeight();
            }

            var curr = Head;
            int level = Head.Height - 1;
            while(level >= 0)
            {
                //makes use of the ternary operator ('?') to check if curr[level] is null. 
                //if it is, then set comparison to 1. if not, then compare its value to the passed in value, and store the result into comparison
                //as an integer between -1 and 1, inclusive.
                int comparison = curr[level] == null ? 1 : Comparer.Compare(curr[level].Value, value);

                if(comparison > 0) //move down
                {
                    if(newNode.Height > level)
                    {
                        curr[level] = newNode;
                    }
                    level--;
                }
                else if (comparison < 0) //move right
                {
                    curr = curr[level];
                }
                else if (comparison == 0) //values are equal
                {
                    throw new Exception("duplicate value");
                }
            }
            Count++;
        }
        public int ChooseRandomHeight(int maxHeight)
        {
            int currHeight = 1;
            Random coinFlip = new Random();
            while (currHeight < maxHeight && coinFlip.Next(0, 101) > 50)
            {
                currHeight++;
            }
            return currHeight;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            bool success = false;
            var current = Head;
            int level = Head.Height - 1;
            while (level >= 0)
            {
                int comparison = current[level] == null ? 1 : Comparer.Compare(current[level].Value, value);

                if (comparison > 0) //move down
                {
                    level--;
                }
                else if (comparison < 0) //move right
                {
                    current = current[level];
                }
                else if (comparison == 0) //values are equal
                {
                    success = true; 
                }
            }
            return success;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T value)
        {
            bool removalSuccessful = false;
            var current = Head;
            int level = Head.Height - 1;
            while (level >= 0)
            {
                int comparison = current[level] == null ? 1 : Comparer.Compare(current[level].Value, value);

                if (comparison > 0) //move down
                {
                    level--;
                }
                else if (comparison < 0) //move right
                {
                    current = current[level];
                }
                else if (comparison == 0) //values are equal ->unlink the found value and then move down
                {
                    removalSuccessful = true;
                    current[level] = current[level][level];
                    level--;
                }
            }
            if (removalSuccessful)
                Count--;
            return removalSuccessful;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
