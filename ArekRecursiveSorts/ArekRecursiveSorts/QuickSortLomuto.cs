using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekRecursiveSorts
{
    class QuickSortLomuto<T> where T : IComparable
    {
        public QuickSortLomuto() { }
        private int lomutoPartition(T[] array, int startIndex, int endIndex)
        {
            int wallIndex = startIndex - 1;
            T pivot = array[endIndex];
            for(int i = startIndex; i <= endIndex - 1; i++)
            {
                if(array[i].CompareTo(pivot) <= 0)
                {
                    wallIndex++;

                    Swap(array, i, wallIndex);
                }
            }
            Swap(array, wallIndex + 1, endIndex);
            return (wallIndex + 1);
        }

        public void LomutoQuickSort(T[] array, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int partitionIndex = lomutoPartition(array, startIndex, endIndex);

                LomutoQuickSort(array, startIndex, partitionIndex-1);
                LomutoQuickSort(array, partitionIndex + 1, endIndex);
            }
        }

        void Swap(T[] array, int index1,  int index2)
        {
            //swaps the items at index1 and index2 in the given array 
            T temp = array[index1];

            array[index1] = array[index2];

            array[index2] = temp;
        }
    }
}
