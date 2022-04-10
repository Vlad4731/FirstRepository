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
            for(int i = 0; i < 6; i++)
            {
                array[i] = i + 1;
            }

            Assert.Equal(5, array.Count);
            Assert.Equal(2, array[1]);
        }
    }
}
