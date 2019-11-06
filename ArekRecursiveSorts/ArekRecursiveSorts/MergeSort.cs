using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekRecursiveSorts
{
    class MergeSort<T> where T : IComparable
    {
        private void merge(T[] values, int leftArrStIndex, int middle, int rightArrStIndex)
        {
            int leftLength = middle - leftArrStIndex + 1;
            int rightLength = rightArrStIndex - middle;

            Queue<T> leftQueue = new Queue<T>(leftLength);
            Queue<T> rightQueue = new Queue<T>(rightLength);

            for(int i = 0; i < leftLength; i++)
            {
                leftQueue.Enqueue(values[leftArrStIndex + i]);
            }
            for(int i = 0; i < rightLength; i++)
            {
                rightQueue.Enqueue(values[middle + i + 1]);
            }
            
            int leftTempIndex = 0;
            int rightTempIndex = 0;
            int newArrayIndex = leftArrStIndex; 

            while(leftTempIndex < leftLength && rightTempIndex < rightLength)
            {
                if((leftQueue.Peek().CompareTo(rightQueue.Peek()) <= 0)) 
                {
                    values[newArrayIndex] = leftQueue.Dequeue();
                    leftTempIndex++;
                }
                else
                {
                    values[newArrayIndex] = rightQueue.Dequeue();
                    rightTempIndex++;
                }
                newArrayIndex++;
            }
            while(leftTempIndex < leftLength)
            {
                values[newArrayIndex] = leftQueue.Dequeue();
                leftTempIndex++;
                newArrayIndex++;
            }
            while(rightTempIndex < rightLength)
            {
                values[newArrayIndex] = rightQueue.Dequeue();
                rightTempIndex++;
                newArrayIndex++;
            }
        }

        public void Sort(T[] values, int leftArrStIndex, int rightArrStIndex)
        {
            if (leftArrStIndex < rightArrStIndex)
            {
                int middle = (leftArrStIndex + rightArrStIndex) / 2;
                Sort(values, leftArrStIndex, middle);
                Sort(values, middle + 1, rightArrStIndex);

                merge(values, leftArrStIndex, middle, rightArrStIndex);
            }
        } 
    }
}
