using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //creating the array and randomly generating nums
            Random gen = new Random();
            int[] numbers = new int[5];
            Console.Write("Unsorted Array: ");
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = gen.Next(0,11);
                Console.Write($"{numbers[i]} ");
            }
            //Bubble Sort
            //Sorts.BubbleSort(numbers);

            //Selection Sort
            //Sorts.SelectionSort(numbers);

            //Insertion Sort
            Sorts.InsertionSort(numbers);

;            Console.Write("\nSorted Array: ");
            for(int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.ReadKey(); 
        }
    }
}
