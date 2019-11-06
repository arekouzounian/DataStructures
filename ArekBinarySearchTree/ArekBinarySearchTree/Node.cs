using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekBinarySearchTree
{
    public class Node<T>
    {
        public Node<T> Parent; 
        public Node<T> LeftChild;
        public Node<T> RightChild;
        public T Value;
        public int Amount; 

        public int ChildCount
        {
            get
            {
                int count = 0;
                if (LeftChild != null) count++;
                if (RightChild != null) count++;
                return count;
            }
        }
        
        public bool IsLeftChild
        {
            get
            {
                if(Parent != null && Parent.LeftChild == this)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (Parent != null && Parent.RightChild == this)
                {
                    return true;
                }
                return false;
            }
        }

        public Node(T value, Node<T> leftChild = null, Node<T> rightChild = null, Node<T> parent = null, int amount = 1)
        {
            Value = value;
            Parent = parent; 
            LeftChild = leftChild;
            RightChild = rightChild;
            Amount = amount; 
        }
    }
}
