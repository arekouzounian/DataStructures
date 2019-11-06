using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekRedBlackTree
{
    public class Node<T>
    {
        public Node<T> Parent;
        public Node<T> LeftChild;
        public Node<T> RightChild;
        public T Value;
        public int Amount;
        public int Height;

        public bool isBlack;


        public uint ChildCount
        {
            get
            {
                uint count = 0;
                if (LeftChild != null) count++;
                if (RightChild != null) count++;
                return count;
            }
        }

        public Node<T> First
        {
            get
            {
                if (LeftChild != null)
                    return LeftChild;
                if (RightChild != null)
                    return RightChild;

                return null;
            }
        }

        public bool IsLeftChild
        {
            get
            {
                if (Parent != null && Parent.LeftChild == this)
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
            Height = 1;
            isBlack = false; 
        }

        public bool isLeaf(Node<T> node)
        {
            if (node.ChildCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Balance
        {
            get
            {
                int leftHeight = LeftChild == null ? 0 : LeftChild.Height;
                int rightHeight = RightChild == null ? 0 : RightChild.Height;
                return rightHeight - leftHeight;
            }
        }
    }
}
