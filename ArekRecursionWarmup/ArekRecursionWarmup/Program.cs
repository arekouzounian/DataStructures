using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekRecursionWarmup
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an array of 10 random numbers
            //using recursion, print out the loop and also print out the sum of the array 

            //how to implement generics when randomly generated elements can only be ints?
            Random gen = new Random(); 
            int[] values = new int[10];
            int sum = 0; 
            int index = values.Length - 1; 
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = gen.Next(1, 11);
            }
            printOut(values, index, sum);

            Console.ReadKey(); 
        }

        static void printOut(int[] values, int index, int sum)
        {
            if (index < 0)
            {
                Console.WriteLine($"Sum: {sum}");
                return; 
            }
            Console.WriteLine(values[index]);
            sum += values[index];
            printOut(values, index - 1, sum);
        }
    }
}
