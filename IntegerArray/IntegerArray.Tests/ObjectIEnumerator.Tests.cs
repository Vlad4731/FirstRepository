using Xunit;

namespace IntegerArray.Tests
{
    public class ObjectIENumeratorTests
    {
        ObjectArray array = new ObjectArray();

        [Fact]
        public void ElementsAreAddedToArray()
        {
            var objArray = new ObjectArray { 1, 2, 3, 4 };
            Assert.Equal(4, objArray[3]);
        }
    }
}