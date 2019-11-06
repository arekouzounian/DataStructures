using System;
using System.Collections.Generic;
using ArekAVLTree;

namespace ArekAVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Insert(22);
            tree.Insert(20);
            tree.Insert(21);
            tree.Insert(23);
            tree.Insert(24);

            tree.Delete(tree.Root.Value);

            List<int> output = tree.BreadthFirst();
            for(int i = 0; i < output.Count; i++)
            {
                Console.WriteLine(output[i]);
            }

            Console.ReadKey();            
        }
    }
}
