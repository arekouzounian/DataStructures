using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekDynamicArray
{
    class Print<T, U>
    {
        public Print(T firstValue, U secondValue)
        {
            Console.WriteLine(firstValue);
            Console.WriteLine(secondValue);
        }
    }
}
