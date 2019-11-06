using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArekStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayStack<int> intStack = new ArrayStack<int>(3);
            //intStack.Push(1);
            //intStack.Push(2);
            //intStack.Push(3);

            LinkedListStack<int> intStack = new LinkedListStack<int>();
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);

            intStack.PrintOut();

            Console.ReadKey(); 
        }
    }
}
