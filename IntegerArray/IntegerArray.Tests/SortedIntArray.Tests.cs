using Xunit;

namespace IntegerArray.Tests
{
    public class SortedIntArrayTests
    {
        SortedIntArray array = new SortedIntArray();

        [Fact]
        public void ElementIsAddedToArray()
        {
            array.Add(1);
            Assert.Equal(1, array[0]);
        }

        [Fact]
        public void ElementsAreAddedToArray()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);

            Assert.Equal(5, array.Count);
            Assert.Equal(2, array[1]);
        }

        [Fact]
        public void ElementsAreSorted()
        {
            array.Add(5);
            array.Add(1);
            array.Add(4);
            Assert.Equal(4, array[1]);
        }

        [Fact]
        public void WrongElementCannotBeAdded()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Insert(1, 5);
            array[1] = 5;
            Assert.Equal(2, array[1]);
        }

        [Fact]
        public void ElementCanBeInserted()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array[2] = 5;
            array[0] = 5;
            Assert.Equal(5, array[2]);
            Assert.Equal(1, array[0]);
        }
    }
}
