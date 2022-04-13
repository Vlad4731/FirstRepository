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

        [Fact]
        public void ForeachWorksWithObjectArray()
        {
            var objArray = new ObjectArray { 1, 2, 3, 4, 5 };
            string test = "";
            foreach(var obj in objArray)
            {
                test += (int)obj;
            }
            Assert.Equal("12345", test);
        }
    }
}