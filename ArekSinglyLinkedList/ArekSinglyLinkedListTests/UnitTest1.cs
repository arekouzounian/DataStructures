using System;
using Xunit;
using ArekSinglyLinkedList;

namespace ArekSinglyLinkedListTests
{
    public class UnitTest1
    {
        [Fact]
        public void SinglyLinkedListEmptyCountIsZero()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            //implement a "Count" function in the SinglyLinkedList class
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void SinglyLinkedListEmptyHeadIsNull()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            
            Assert.Null(list.GetHead());
        }

        [Fact]
        public void SinglyLinkedListCountIsOne()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.AddFirst(3);

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void SinglyLinkedListCountIsTen()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.AddFirst(1);
            for (int i = 2; i < 11; i++)
            {
                list.AddAfter(i - 1, i);
            }

            Assert.Equal(10, list.Count);
        }
        //test the clear function --
        //test the removeFirst function --
        //test the removeLast function -- 
        //test the contains function --

        [Fact]
        public void SinglyLinkedListClearFunctionCalled()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            for (int i = 0; i < 6; i++)
            {
                list.AddFirst(i);
            }
            list.Clear();
            Assert.Equal(0, list.Count);
            Assert.Null(list.GetHead());
        }
        [Fact]
        public void RemovedFirstSecondIsHead()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            for (int i = 10; i > 0; i--)
            {
                list.AddFirst(i);
            }
            list.RemoveFirst();
            Assert.Equal(2, list.GetHead().Item);
        }

        [Fact]
        public void RemovedLastSecondToLastNextIsNull()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            for (int i = 10; i > 0; i--)
            {
                list.AddFirst(i);
            }
            list.RemoveLast();
            var temp = list.GetHead();
            while(temp.Next != null)
            {
                temp = temp.Next; 
            }
            Assert.Equal(9, temp.Item);
        }

        [Fact]
        public void ListContainsSpecifiedValue()
        {
            bool containsNums = false;
            SinglyLinkedList<int> list = new SinglyLinkedList<int>(); 
            for (int i = 10; i > 0; i--)
            {
                list.AddFirst(i);
            }
            if(list.Contains(4) && list.Contains(10))
            {
                containsNums = true; 
            }
            Assert.True(containsNums);
        }

        //[Theory]
        //[InlineData(3)]
        //[InlineData(5)]
        //[InlineData(6)]
        //public void NumberIsOdd(int value)
        //{
        //    Assert.True(IsOdd(value));
        //}

        //bool IsOdd(int value)
        //{
        //    return value % 2 == 1;
        //}
    }
}
