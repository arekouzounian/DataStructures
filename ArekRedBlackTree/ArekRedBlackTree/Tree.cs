using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekRedBlackTree
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
            Root = pInsert(value, Root);
            Root.isBlack = true;
        }

        private Node<T> pInsert(T value, Node<T> current)
        {
            //insertion
            if (current == null)
            {
                Count++;
                return new Node<T>(value);
            }

            //splitting 
            if (isRed(current.LeftChild) && isRed(current.LeftChild))
            {
                FlipColor(current);
            }

            //going down the tree           
            if (value.CompareTo(current.Value) == 0)
            {
                current.Amount++;
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                current.RightChild = pInsert(value, current.RightChild);
            }
            else
            {
                current.LeftChild = pInsert(value, current.LeftChild);
            }

            //going back up the tree
            if (isRed(current.RightChild))
            {
                current = RotateLeft(current);
            }
            if (isRed(current.LeftChild) && isRed(current.LeftChild.LeftChild))
            {
                current = RotateRight(current);
            }

            return current;
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
            int initialCount = Count;
            if (Root != null)
            {
                Root = Delete(Root, value);
                if (Root != null)
                {
                    Root.isBlack = true;
                }
            }

            return initialCount != Count;
        }

        private Node<T> Delete(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.LeftChild != null)
                {
                    if(!isRed(node.LeftChild) && !isRed(node.LeftChild.LeftChild))
                    {
                        node = MoveRedLeft(node);
                    }

                    node.LeftChild = Delete(node.LeftChild, value);
                }
            }
            else
            {
                if(isRed(node.LeftChild))
                {
                    node = RotateRight(node);
                }

                if(value.CompareTo(node.Value) == 0 && node.ChildCount == 0)
                {
                    Count--;
                    return null;
                }

                if(node.RightChild != null)
                {
                    if(!isRed(node.RightChild) && !isRed(node.RightChild.LeftChild))
                    {
                        node = MoveRedRight(node);
                    }

                    if(value.CompareTo(node.Value) == 0)
                    {
                        Node<T> minimum = Minimum(node.RightChild);
                        node.Value = minimum.Value;
                        node.RightChild = Delete(node.RightChild, minimum.Value);
                    }
                    else
                    {
                        node.RightChild = Delete(node.RightChild, value);
                    }
                }
            }

            return Fixup(node);
        }

        private Node<T> RotateRight(Node<T> node)
        {
            Node<T> pivot = node.LeftChild;

            node.LeftChild = pivot.RightChild;
            pivot.RightChild = node;

            pivot.isBlack = node.isBlack;
            node.isBlack = false;

            return pivot;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            Node<T> pivot = node.RightChild;

            node.RightChild = pivot.LeftChild;
            pivot.LeftChild = node;

            pivot.isBlack = node.isBlack;
            node.isBlack = false;

            return pivot;
        }

        //private void BalanceTree(Node<T> currentNode)
        //{
        //    while (currentNode != null)
        //    {
        //        UpdateHeight(currentNode);
        //        if (currentNode.Balance > 1)
        //        {
        //            if (currentNode.RightChild.Balance < 0)
        //            {
        //                RotateRight(currentNode.LeftChild);
        //            }
        //            RotateLeft(currentNode);
        //        }
        //        else if (currentNode.Balance < -1)
        //        {
        //            if (currentNode.LeftChild.Balance > 0)
        //            {
        //                RotateLeft(currentNode.LeftChild);
        //            }
        //            RotateRight(currentNode);
        //        }
        //        currentNode = currentNode.Parent;
        //    }
        //}

        private Node<T> MoveRedLeft(Node<T> node)
        {
            FlipColor(node);
            if (isRed(node.RightChild.LeftChild))
            {
                node.RightChild = RotateRight(node.RightChild);
                node = RotateLeft(node);

                FlipColor(node);

                if (isRed(node.RightChild.RightChild))
                {
                    node.RightChild = RotateLeft(node.RightChild);
                }
            }

            return node;
        }

        private Node<T> MoveRedRight(Node<T> node)
        {
            FlipColor(node);
            if (isRed(node.LeftChild.LeftChild))
            {
                node = RotateRight(node);
                FlipColor(node);
            }

            return node;
        }

        private Node<T> Fixup(Node<T> node)
        {
            if (isRed(node.RightChild))
            {
                node = RotateLeft(node);
            }

            if (isRed(node.LeftChild) && isRed(node.LeftChild.LeftChild))
            {
                node = RotateRight(node);
            }

            if (isRed(node.LeftChild) && isRed(node.RightChild))
            {
                FlipColor(node);
            }

            if ((node.LeftChild != null) && isRed(node.LeftChild.RightChild) && !isRed(node.LeftChild.LeftChild))
            {
                node.LeftChild = RotateLeft(node.LeftChild);

                if (isRed(node.LeftChild))
                {
                    node.LeftChild = RotateRight(node.LeftChild);
                }

            }

            return node;
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

        public bool isRed(Node<T> node)
        {
            if (node == null)
            {
                return false;
            }
            return !node.isBlack;
        }

        private void FlipColor(Node<T> node)
        {
            if (node == null) return;

            node.isBlack = !node.isBlack;
            if (node.LeftChild != null)
            {
                node.LeftChild.isBlack = isRed(node.LeftChild);
            }
            if (node.RightChild != null)
            {
                node.RightChild.isBlack = isRed(node.RightChild);
            }
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
