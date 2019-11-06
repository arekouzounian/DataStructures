using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekAVLTree
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
            var newNode = new Node<T>(value);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                // CompareTo returns a -1, 0, or 1 for less than, equal to, and greater than respectively 
                var temp = Root;
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
            UpdateHeight(newNode);

            BalanceTree(newNode); 
            
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
                        Root = toBeDeleted.First;
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

            if(toBeDeleted.Parent == null)
            {
                BalanceTree(Root);
            }
            else
            {
                BalanceTree(toBeDeleted.Parent);
            }
        }

        private void RotateRight(Node<T> node) // check this 
        {
            var parent = node.Parent;
            var pivotNode = node.LeftChild;

            node.LeftChild = pivotNode.RightChild;
            pivotNode.RightChild = node;

            if (node.IsRightChild)
            {
                parent.RightChild = pivotNode;
            }
            else if (node.IsLeftChild)
            {
                parent.LeftChild = pivotNode;
            }
            else if (parent == null)
            {
                Root = pivotNode;
            }


            node.Parent = pivotNode;
            pivotNode.Parent = parent;

            UpdateHeight(node);
        }

        private void RotateLeft(Node<T> node) 
        {
            var parent = node.Parent;
            var pivotNode = node.RightChild;

            node.RightChild = pivotNode.LeftChild;
            pivotNode.LeftChild = node; 

            if (node.IsLeftChild)
            {
                parent.LeftChild = pivotNode;
            }
            else if (node.IsRightChild)
            {
                parent.RightChild = pivotNode; 
            }
            else if (parent == null)
            {
                Root = pivotNode;
            }


            node.Parent = pivotNode;
            pivotNode.Parent = parent;

            UpdateHeight(node);
        }

        private void BalanceTree(Node<T> currentNode)
        {  
            while(currentNode != null)
            {
                UpdateHeight(currentNode);
                if(currentNode.Balance > 1)
                {
                    if(currentNode.RightChild.Balance < 0)
                    {
                        RotateRight(currentNode.LeftChild);
                    }
                    RotateLeft(currentNode);
                }
                else if (currentNode.Balance < -1)
                {
                    if(currentNode.LeftChild.Balance > 0)
                    {
                        RotateLeft(currentNode.LeftChild);
                    }
                    RotateRight(currentNode);
                }
                currentNode = currentNode.Parent;
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


        private void UpdateHeight(Node<T> node)
        {
            int leftHeight = node.LeftChild == null ? 0 : node.LeftChild.Height;

            int rightHeight = node.RightChild == null ? 0 : node.RightChild.Height;

            node.Height = Math.Max(leftHeight, rightHeight) + 1;
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
