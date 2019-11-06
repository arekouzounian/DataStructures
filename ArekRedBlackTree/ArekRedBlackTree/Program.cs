using System;


namespace ArekRedBlackTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);

            tree.Delete(2);
            Console.WriteLine(tree.Count);

            Console.WriteLine(tree.Root.Value);
            Console.WriteLine(tree.Root.isBlack);
            Console.WriteLine(tree.Root.LeftChild.Value);


            Console.ReadKey(true);
        }
    }
}
