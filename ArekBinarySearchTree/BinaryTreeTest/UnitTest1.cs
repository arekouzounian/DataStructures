using System;
using System.Collections.Generic;
using Xunit;
using ArekBinarySearchTree;

namespace BinaryTreeTest
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest()
        {
            Tree<int> tree = new Tree<int>();
            Random gen = new Random(5);
            for (int i = 0; i < 100; i++)
            {
                tree.Insert(gen.Next(0, 101));
            }
            Assert.True(isValid(tree));
        }

        public bool isValid(Tree<int> tree)
        {
            return preOrder(tree);
        }

        private bool preOrder(Tree<int> tree)
        {
            List<int> items = tree.PreOrder();
            if((items[0] > items[1]) && (items[0] > items[2]))
            {
                return true; 
            }
            return false;
        }

        private bool inOrder(Tree<int> tree)
        {
            List<int> items = tree.InOrder();

            for(int i = items.Count - 1; i > 0; i--)
            {
                if(items[i] < items[i - 1])
                {
                    return false; 
                }
            }

            return true; 
        }

        private bool postOrder(Tree<int> tree)
        {
            List<int> items = tree.PostOrder();

            if ((items[0] == tree.Minimum(tree.Root).Value) && (items[items.Count - 1] == tree.Root.Value))
            {
                return true;
            }
            return false;
        }

        private bool breadthFirst(Tree<int> tree)
        {
            List<int> items = tree.BreadthFirst();

            Node<int> lastNode = tree.Search(items[items.Count - 1]); 

            if ((lastNode.LeftChild == null) && (lastNode.RightChild == null))
            {
                return true;
            }
            return false; 
        }
    }
}
