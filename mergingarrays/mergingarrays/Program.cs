using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mergingarrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Random gen = new Random();

            int[] array1 = new int[gen.Next(2, 10)];

            int[] array2 = new int[gen.Next(2, 10)];

            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = gen.Next(100);
            }

            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = gen.Next(100);
            }

            Array.Sort(array1);
            Array.Sort(array2);
            for (int i = 0; i < array1.Length; i++)
            {
                Console.Write(array1[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i] + " ");
            }

            int[] finalArray = new int[array1.Length + array2.Length];

            // merge the two arrays into a single array in order
            int array1Index = 0;
            int array2Index = 0;
            int finalArrayIndex = 0; 
            while (array1Index < array1.Length && array2Index < array2.Length)
            {
                if(array1[array1Index] < array2[array2Index])
                {
                    finalArray[finalArrayIndex] = array1[array1Index];
                    array1Index++;
                    finalArrayIndex++;
                }
                else
                {
                    finalArray[finalArrayIndex] = array2[array2Index];
                    array2Index++;
                    finalArrayIndex++;
                }
            }
            while (array1Index < array1.Length)
            {
                finalArray[finalArrayIndex] = array1[array1Index];
                finalArrayIndex++;
                array1Index++;
            }
            while (array2Index < array2.Length)
            {
                finalArray[finalArrayIndex] = array2[array2Index];
                finalArrayIndex++;
                array2Index++;
            }

            Console.WriteLine();
            for (int i = 0; i < finalArray.Length; i++)
            {
                Console.Write(finalArray[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
