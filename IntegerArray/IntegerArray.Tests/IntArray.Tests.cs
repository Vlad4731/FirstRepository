using System;
using Xunit;

namespace IntegerArray.Tests
{
    public class IntArrayTests
    {
        IntArray array = new IntArray(
            new int[] {1, 2, 3}
            );

        [Fact]
        public void ArrayIsCreatedCorrectly()
        {
            int[] test = { 1, 2, 3 };
            Assert.Equal(array.numbers, test);
        }

        [Fact]
        public void ElementsAreAddedToArray()
        {
            int[] test = { 1, 2, 3, 4 };
            array.Add(4);
            Assert.Equal(array.numbers, test);
        }

        [Fact]
        public void ArrayLengthIsReturned()
        {
            Assert.Equal(3, array.Count());
        }

        [Fact]
        public void ElementAtIndexIsReturned()
        {
            Assert.Equal(3, array.Element(2));
        }

        [Fact]
        public void ElementIsSet()
        {
            array.SetElement(2, 5);
            Assert.Equal(5, array.Element(2));
        }

        [Fact]
        public void ArrayContainsElement()
        {
            Assert.True(array.Contains(3));
            Assert.False(array.Contains(5));
        }

        [Fact]
        public void IndexOfElementIsReturned()
        {
            Assert.Equal(2, array.IndexOf(3));
        }

        [Fact]
        public void ElementIsInsertedCorrectly()
        {
            array.Insert(1, 5);
            Assert.Equal(5, array.Element(1));
        }

        [Fact]
        public void ArrayIsCleared()
        {
            array.Clear();
            Assert.Equal(0, array.Count());
        }
    }
}
