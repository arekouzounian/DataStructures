using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekDynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //an array that you can add to or remove from 
            GenericList<double> myList = new GenericList<double>();
            myList.Add(3.14159);
            myList.Add(8.11);
            myList.Remove(3.14159);
            myList.PrintList();

            // create a class that takes two generics and print out their value
            Print<int, string> values = new Print<int, string>(22, "Hello");

            Console.ReadKey();
        }
    }
}
