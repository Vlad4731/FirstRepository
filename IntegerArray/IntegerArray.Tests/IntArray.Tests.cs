using Xunit;

namespace IntegerArray.Tests
{
    public class IntArrayTests
    {
        IntArray array = new IntArray(new int[4]);


        [Fact]
        public void ElementsAreAddedToArray()
        {
            int[] test = { 1, 2, 3, 4 };
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            Assert.Equal(array.Count(), test.Length);
        }

        [Fact]
        public void ArrayLengthIsReturned()
        {
            array.Add(1);
            array.Add(2);
            Assert.Equal(2, array.Count());
        }

        [Fact]
        public void ElementAtIndexIsReturned()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(3, array.Element(2));
        }

        [Fact]
        public void ElementIsSet()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.SetElement(2, 5);
            Assert.Equal(5, array.Element(2));
        }

        [Fact]
        public void ArrayContainsElement()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.True(array.Contains(3));
            Assert.False(array.Contains(5));
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
            Assert.Equal(5, array.Element(1));
        }

        [Fact]
        public void ArrayIsCleared()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Clear();
            Assert.Equal(0, array.Count());
        }

        [Fact]
        public void ElementIsRemoved()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Remove(2);
            Assert.Equal(2, array.Count());
        }

        [Fact]
        public void ElementAtIndexIsRemoved()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.RemoveAt(1);
            Assert.Equal(3, array.Element(1));
        }
    }
}
