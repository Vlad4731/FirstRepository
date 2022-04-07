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
    }
}
