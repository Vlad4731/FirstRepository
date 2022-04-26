using Xunit;

namespace IntegerArray.Tests
{
    public class SortedListsTests
    {
        readonly SortedList<int> array = new SortedList<int>();

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
    }
}
