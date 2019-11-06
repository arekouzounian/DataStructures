using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekRecursiveSorts
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeSort<int> yeehaw = new MergeSort<int>();
            QuickSortLomuto<int> lomutoYeehaw = new QuickSortLomuto<int>();
            QuickSortHoare<int> hoareYeehaw = new QuickSortHoare<int>();
            Random gen = new Random();
            int[] arrayOfNums = new int[gen.Next(5, 21)];

            for(int i = 0; i < arrayOfNums.Length; i++)
            {
                arrayOfNums[i] = gen.Next(0, 100);
                Console.Write(arrayOfNums[i] + " ");
            }

            //yeehaw.Sort(arrayOfNums, 0, arrayOfNums.Length - 1);
            //lomutoYeehaw.LomutoQuickSort(arrayOfNums, 0, arrayOfNums.Length - 1);
            hoareYeehaw.HoareQuickSort(arrayOfNums, 0, arrayOfNums.Length - 1);

            Console.WriteLine();

            for(int i = 0; i < arrayOfNums.Length; i++)
            {
                Console.Write(arrayOfNums[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
