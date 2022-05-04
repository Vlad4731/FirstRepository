using Xunit;
using System;

namespace IntegerArray.Tests
{
    public class ListTests
    {
        List<int> array = new List<int>();

        [Fact]
        public void ElementsAreAddedToArray()
        {
            int[] test = { 1, 2, 3, 4 };
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            Assert.Equal(array.Count, test.Length);
        }

        [Fact]
        public void ArrayLengthIsReturned()
        {
            array.Add(1);
            array.Add(2);
            Assert.Equal(2, array.Count);
        }

        [Fact]
        public void ElementAtIndexIsReturned()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(3, array[2]);
        }

        [Fact]
        public void ElementIsSet()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array[2] = 5;
            Assert.Equal(5, array[2]);
        }

        [Fact]
        public void ArrayContainsElement()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Contains(3, array);
            Assert.DoesNotContain(5, array);
        }

        [Fact]
        public void IndexOfElementIsReturned()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(2, array.IndexOf(3));
        }

        [Fact]
        public void ElementIsInsertedCorrectly()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Insert(1, 5);
            Assert.Equal(5, array[1]);
        }

        [Fact]
        public void ArrayIsCleared()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Clear();
            Assert.Equal(0, array.Count);
        }

        [Fact]
        public void ElementIsRemoved()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Remove(2);
            Assert.Equal(2, array.Count);
        }

        [Fact]
        public void ElementAtIndexIsRemoved()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.RemoveAt(1);
            Assert.Equal(3, array[1]);
        }

        [Fact]
        public void GetSet_InvalidIndexException_IsCought()
        {
            array.Add(1);
            Assert.Throws<ArgumentException>(() => array[10]);
            Assert.Throws<ArgumentException>(() => array[10] = 1);
        }

        [Fact]
        public void Insert_InvalidIndexException_IsCought()
        {
            array.Add(1);
            Assert.Throws<ArgumentException>(() => array.Insert(3,3));
        }

        [Fact]
        public void CopyTo_InvalidIndexException_IsCought()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            int[] newArray = new int[2];
            Assert.Throws<ArgumentException>(() => array.CopyTo(newArray, 5));
        }

        [Fact]
        public void CopyTo_OverflowException_IsCought()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            int[] newArray = new int[2];
            Assert.Throws<OverflowException>(() => array.CopyTo(newArray, 0));
        }

    }
}
