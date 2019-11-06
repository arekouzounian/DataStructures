using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HeapTree
{
    public class HeapTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        //reference:
        //array[(index - 1) / 2]  -> gives the parent node of the node at the given index
        //array[(2*index) + 1] -> gives the left child of the node at the given index
        //array[(2*index) + 2] -> gives the right child of the node at the given index

        public T[] heapTree;

        public int Count { get; private set; }
        //constructor
        public HeapTree(T[] startingArray)
        {
            heapTree = startingArray;
            Count = heapTree.Length;
        }

        private void HeapifyUp(int index)
        {
            if (index == 0) //check is made before vars declared because if index is 0 then currNodeParent will throw an error
            {
                return;
            }

            if (heapTree[index].CompareTo(heapTree[(index - 1) / 2]) < 0) //check if the node at the given index is less than its parent node 
            {
                Swap(index, (index - 1) / 2);
                HeapifyUp((index - 1) / 2);
            }
        }

        private void HeapifyDown(int index)
        {
            if(isLeafNode(index))
            {
                return;
            }

            //T currNode = heapTree[index];
            //T currNodeRightChild = heapTree[(2 * index) + 2];
            //T currNodeLeftChild = heapTree[(2 * index) + 1];

            if(heapTree[index].CompareTo(heapTree[(2 * index) + 2]) > 0) //check if the node at the given index is greater than its right child
            {
                Swap(index, (2 * index) + 2);
                HeapifyDown((2*index) + 2);
            }
            else if(heapTree[index].CompareTo(heapTree[(2 * index) + 1]) > 0) //check if the node at the given index is greater than its left child
            {
                Swap(index, (2 * index) + 1);
                HeapifyDown((2 * index) + 1);
            }
        }

        public T Pop()
        {
            T rootNode = heapTree[0];

            heapTree[0] = heapTree[Count - 1];
            heapTree[Count - 1] = default;

            Count--;

            HeapifyDown(0);

            return rootNode;
        }

        //public void Heapify()
        //{
        //    for(int i = 0; i < Count; i++)
        //    {
                
        //    }
        //}

        #region interface_functions
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region helper_functions
        public bool isLeafNode(int index)
        {
            if(heapTree[index + 1] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Swap(int index1, int index2)
        {
            var temp = heapTree[index1];
            heapTree[index1] = heapTree[index2];
            heapTree[index2] = temp;
        }
        #endregion
    }
}
