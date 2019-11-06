using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekCircularlyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new CircularlyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(15);
            list.AddLast(25);
            list.AddLast(35);
            list.AddLast(45);

            foreach (var item in list)
            {
                ;
            }
            Console.ReadKey();
        }
    }
}
