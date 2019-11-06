using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekRecursiveSorts
{
    class QuickSortHoare<T> where T : IComparable
    {
        public QuickSortHoare() { }

        private int HoarePartition(T[] array, int startIndex, int endIndex)
        {
            int leftIndicator = startIndex - 1;
            int rightIndicator = endIndex + 1;
            T pivot = array[startIndex];

            while (true) 
            {
                do
                {
                    leftIndicator++;
                } while (array[leftIndicator].CompareTo(pivot) < 0);

                do
                {
                    rightIndicator--;
                } while (array[rightIndicator].CompareTo(pivot) > 0);

                if (leftIndicator < rightIndicator)
                {
                    Swap(array, leftIndicator, rightIndicator);
                }
                if(leftIndicator >= rightIndicator)
                {
                    return rightIndicator;
                }
            } 
        }
        public void HoareQuickSort(T[] array, int startIndex, int endIndex)
        {
            if(startIndex < endIndex)
            {
                int hoarePartitionIndex = HoarePartition(array, startIndex, endIndex);

                HoareQuickSort(array, startIndex, hoarePartitionIndex);
                HoareQuickSort(array, hoarePartitionIndex + 1, endIndex);
            }
        }


        void Swap(T[] array, int index1, int index2)
        {
            //swaps two items in an array
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
