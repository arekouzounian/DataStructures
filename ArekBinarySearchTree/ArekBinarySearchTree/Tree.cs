using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekBinarySearchTree
{
    public class Tree<T> where T : IComparable<T>
    {
        public static int TreeCount = 0;

        public Node<T> Root;
        public int Count = 0;

        public Tree()
        {
            TreeCount++;
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
            }
            else
            {
                // CompareTo returns a -1, 0, or 1 for less than, equal to, and greater than respectively 
                var temp = Root;
                var newNode = new Node<T>(value);
                //looping through the tree until we reach a place where we can insert the new node 
                //this loop reaches a leaf
                while (temp != null)
                {
                    if (newNode.Value.CompareTo(temp.Value) < 0)
                    {
                        if (temp.LeftChild == null)
                        {
                            temp.LeftChild = newNode;
                            newNode.Parent = temp;
                            break;
                        }
                        else
                        {
                            temp = temp.LeftChild;
                        }
                    }
                    else if (newNode.Value.CompareTo(temp.Value) > 0)
                    {
                        if (temp.RightChild == null)
                        {
                            temp.RightChild = newNode;
                            newNode.Parent = temp;
                            break;
                        }
                        else
                        {
                            temp = temp.RightChild;
                        }
                    }
                    else
                    {
                        temp.Amount++;
                        break;
                    }
                }
            }
            Count++;
        }

        public Node<T> Search(T value)
        {
            var curr = Root;
            while ((curr != null) && !(curr.Value.CompareTo(value) == 0))
            {
                if (value.CompareTo(curr.Value) < 0)
                {
                    curr = curr.LeftChild;
                }
                else if (value.CompareTo(curr.Value) > 0)
                {
                    curr = curr.RightChild;
                }
            }
            if (curr == null)
            {
                throw new ArgumentException("Node Not Found!");
            }
            else
            {
                return curr;
            }
        }

        public bool Delete(T value)
        {
            Node<T> toBeDeleted = Search(value);
            if (toBeDeleted == null || toBeDeleted.Amount < 1)
            {
                return false;
            }
            Delete(toBeDeleted);
            return true;
        }

        private void Delete(Node<T> toBeDeleted)
        {
            Node<T> parent = toBeDeleted.Parent;
            if (toBeDeleted.ChildCount == 0)
            {
                if(toBeDeleted.Amount == 1)
                {
                    if (toBeDeleted.IsLeftChild)
                    {
                        parent.LeftChild = null;
                    }
                    else if (toBeDeleted.IsRightChild)
                    {
                        parent.RightChild = null;
                    }
                    else
                    {
                        Root = null;
                    }
                }
                else
                {
                    toBeDeleted.Amount--;
                }
            }
            else if (toBeDeleted.ChildCount == 1)
            {
                if(toBeDeleted.Amount == 1)
                {
                    Node<T> child = toBeDeleted.LeftChild;
                    if (toBeDeleted.LeftChild == null)
                    {
                        child = toBeDeleted.RightChild;
                    }

                    //checking if the node to be deleted is the left child of parent node
                    if (toBeDeleted.IsLeftChild == true)
                    {
                        parent.LeftChild = child;
                    }
                    //checking if the node to be deleted is the right child of parent node
                    else
                    {
                        parent.RightChild = child;
                    }
                    child.Parent = parent;
                }
                else
                {
                    toBeDeleted.Amount--;
                }
            }
            else if(toBeDeleted.ChildCount == 2)
            {
                if(toBeDeleted.Amount == 1)
                {
                    //get candidate node
                    Node<T> candidate = Maximum(toBeDeleted.LeftChild);
                    //set the VALUE in the toBeDeleted node to the VALUE from the candidate node
                    toBeDeleted.Value = candidate.Value;
                    Delete(candidate);
                }
                else
                {
                    toBeDeleted.Amount--;
                }
            }
        }

        public Node<T> Minimum(Node<T> start)
        {
            Node<T> curr = start;
            while (curr.LeftChild != null)
            {
                curr = curr.LeftChild;
            }
            return curr;
        }

        public Node<T> Maximum(Node<T> start)
        {
            var curr = start;
            while (curr.RightChild != null)
            {
                curr = curr.RightChild;
            }
            return curr;
        }

        public int NodeCount()
        {
            return Count;
        }

        //traversals
        public List<T> PreOrder()
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            List<T> items = new List<T>();
            stack.Push(Root);
            while (stack.Count > 0)
            {
                Node<T> currentNode = stack.Pop();
                items.Add(currentNode.Value);
                if (currentNode.RightChild != null)
                {
                    stack.Push(currentNode.RightChild);
                }
                if (currentNode.LeftChild != null)
                {
                    stack.Push(currentNode.LeftChild);
                }
            }
            return items; 
        }

        public List<T> InOrder()
        {
            List<T> items = new List<T>();

            traverse(Root);

            void traverse(Node<T> current)
            {
                if (current.LeftChild != null)
                {
                    traverse(current.LeftChild);
                }

                items.Add(current.Value);

                if (current.RightChild != null)
                {
                    traverse(current.RightChild);
                }
            }
            return items; 
        }

        public List<T> PostOrder()
        {
            List<T> items = new List<T>();

            traverse(Root);
            void traverse(Node<T> current)
            {
                if (current.LeftChild != null)
                {
                    traverse(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    traverse(current.RightChild);
                }

                items.Add(current.Value);
            }
            return items; 
        }

        public List<T> BreadthFirst()
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            List<T> items = new List<T>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                items.Add(currentNode.Value);
                if (currentNode.LeftChild != null)
                {
                    queue.Enqueue(currentNode.LeftChild);
                }
                if (currentNode.RightChild != null)
                {
                    queue.Enqueue(currentNode.RightChild);
                }
            }
            return items;
        }
    }
}
