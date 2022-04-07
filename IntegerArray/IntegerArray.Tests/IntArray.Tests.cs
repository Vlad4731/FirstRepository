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
    }
}
