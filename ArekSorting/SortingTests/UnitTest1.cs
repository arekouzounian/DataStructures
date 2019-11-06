using System;
using Xunit;
using ArekSorting; 

namespace SortingTests
{
    public class UnitTest1
    {
        [Fact]
        public void BubbleSortTest()  
        {
            int[] expectedResult = new int[5];
            for(int i = 0; i < expectedResult.Length; i++)
            {
                expectedResult[i] = i + 1;
            }
            int[] numbers = new int[5];
            numbers[0] = 3;
            numbers[1] = 2;
            numbers[2] = 5;
            numbers[3] = 1;
            numbers[4] = 4;

            Sorts.BubbleSort(numbers);
            Assert.Equal(expectedResult, numbers);
        }

        [Fact]
        public void SelectionSortTest()
        {
            int[] expectedResult = new int[5];
            for(int i = 0; i < expectedResult.Length; i++)
            {
                expectedResult[i] = i + 6;
            }
            int[] numbers = new int[5];
            numbers[0] = 7;
            numbers[1] = 9;
            numbers[2] = 10;
            numbers[3] = 6;
            numbers[4] = 8;
            Sorts.SelectionSort(numbers);

            Assert.Equal(expectedResult, numbers);
        }

        [Fact]
        public void InsertionSortTest()
        {
            int[] expectedResult = new int[5];
            for(int i = 0; i < expectedResult.Length; i++)
            {
                expectedResult[i] = i + 11;
            }
            int[] numbers = new int[5];
            numbers[0] = 14;
            numbers[1] = 11;
            numbers[2] = 15;
            numbers[3] = 13;
            numbers[4] = 12;
            Sorts.InsertionSort(numbers);

            Assert.Equal(expectedResult, numbers);
        }
    }
}
