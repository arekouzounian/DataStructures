using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekBinarySearchTree
{
    class Program
    {

        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            Tree<int> tree2 = new Tree<int>();
            Tree<int> tree3 = new Tree<int>();
            Tree<int> tree4 = new Tree<int>();

            Console.WriteLine(Tree<int>.TreeCount);

            Console.ReadKey();
        }
    }
}
