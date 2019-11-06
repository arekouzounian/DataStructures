using System;
using Xunit;

using ArekCircularlyLinkedList;

namespace ArekCircularlyLinkedList
{
    public class UnitTest1
    {
        [Fact]
        public void AddFirstChangesHeadToNewValue()
        {
            var list = new CircularlyLinkedList<int>();
            for (int i = 0; i < 11; i++)
            {
                list.AddFirst(i);
            }
            Assert.Equal(10, list.Head.Value);
        }

        [Fact]
        public void ListOnlyHasOneNodeHeadIsTail()
        {
            var list = new CircularlyLinkedList<int>();
            list.AddFirst(1);
            Assert.Equal(list.Head, list.Tail);
        }

        [Fact]
        public void RemovingHeadMakesNextValueNewHead()
        {
            var list = new CircularlyLinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);
            list.RemoveFirst();
            Assert.Equal(2, list.Head.Value);
        }

        [Fact]
        public void RemovingLastTailIsShiftedToNewValue()
        {
            var list = new CircularlyLinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.RemoveLast();
            Assert.Equal(3, list.Tail.Value);
        }

        [Fact]
        public void RemovingValueSetsPreviousValuesNextToTheRemovedValuesNext()
        {
            var list = new CircularlyLinkedList<int>();
            list.AddFirst(1);
            list.AddLast(3);
            list.AddLast(5);
            list.AddLast(7);
            list.Remove(5);
            Assert.Equal(7, list.Find(3).Next.Value);
        }

        [Fact]
        public void ListOnlyHasTwoTermsNextValueIsEqualToPrevious()
        {
            var list = new CircularlyLinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);
            Assert.Equal(list.Find(2), list.Head.Prev);
        }

        [Theory]
        [InlineData (1, 2)]
        [InlineData (3, 23)]
        public void HeadPrevIsTailAndTailNextIsHead(int first, int last)
        {
            var list = new CircularlyLinkedList<int>();
            list.AddFirst(first);
            list.AddLast(last);
            Assert.Equal(list.Find(last), list.Find(first).Prev);
            Assert.Equal(list.Find(first), list.Find(last).Next);
        }

        [Fact]
        public void AddingLastMakesNewValueTheTail()
        {
            var list = new CircularlyLinkedList<int>(); 
            for(int i = 10; i > 0; i--)
            {
                list.AddLast(i);
            }
            Assert.Equal(1, list.Tail.Value);
        }

        [Fact]
        public void AddingAndRemovingIncrementsAndDecrementsTheCount()
        {
            var list = new CircularlyLinkedList<int>();
            list.AddFirst(1);
            list.AddAfter(list.Find(1), 3);
            list.AddBefore(list.Find(3), 2);
            list.AddLast(4);
            Assert.Equal(4, list.Count);
            list.RemoveFirst();
            list.RemoveLast();
            list.Remove(3);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void LastItemNextIsHead()
        {
            var list = new CircularlyLinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddAfter(list.Find(2), 3);
            Assert.Equal(1, list.Tail.Next.Value);
            //Assert.Equal(3, list.Head.Prev.Value);
        }
    }
}
