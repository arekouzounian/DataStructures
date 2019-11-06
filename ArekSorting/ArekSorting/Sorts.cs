using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekSorting
{
    public static class Sorts
    {
        public static void BubbleSort(int[] numbers)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        public static void SelectionSort(int[] numbers)
        {
            int temp; 
            int smallestNumIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                smallestNumIndex = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[smallestNumIndex])
                    {
                        smallestNumIndex = j;
                    }
                }

                if (i != smallestNumIndex)
                {
                    temp = numbers[i];
                    numbers[i] = numbers[smallestNumIndex];
                    numbers[smallestNumIndex] = temp;
                }
            }
        }

        public static void InsertionSort(int[] numbers)
        {
            int temp; 
            for(int i = 0; i < numbers.Length - 1; i++)
            {
                for(int j = i + 1; j > 0; j--)
                {
                    if(numbers[j] < numbers[j - 1])
                    {
                        temp = numbers[j];
                        numbers[j] = numbers[j - 1];
                        numbers[j - 1] = temp;
                    }
                    else
                    {
                        break; 
                    }
                }
            }
        }

    }
}
