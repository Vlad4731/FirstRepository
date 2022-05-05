using Xunit;
using System;

namespace IntegerArray.Tests
{
    public class ReadonlyListTests
    {
        readonly ReadonlyList<int> readonlyArray = new ReadonlyList<int>(new int[] { 1, 2 });

        [Fact]
        public void Set_ReadonlyArrayException_IsCought()
        {
            Assert.Throws<NotSupportedException>(() => readonlyArray[1] = 5);
        }

        [Fact]
        public void Add_ReadonlyArrayException_IsCought()
        {
            Assert.Throws<NotSupportedException>(() => readonlyArray.Add(2));
        }

        [Fact]
        public void Insert_ReadonlyArrayException_IsCought()
        {
            Assert.Throws<NotSupportedException>(() => readonlyArray.Insert(1, 3));
        }

        [Fact]
        public void RemoveAt_ReadonlyArrayException_IsCought()
        {
            Assert.Throws<NotSupportedException>(() => readonlyArray.RemoveAt(0));
        }
    }
}
