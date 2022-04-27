using Xunit;

namespace IntegerArray.Tests
{
    public class ObjectIENumeratorTests
    {
        ObjectArrayCollection array = new ObjectArrayCollection();

        [Fact]
        public void ElementsAreAddedToArray()
        {
            var objArray = new ObjectArrayCollection { 1, 2, 3, 4 };
            Assert.Equal(4, objArray[3]);
        }

        [Fact]
        public void ForeachWorksWithIntegerObjectArray()
        {
            var objArray = new ObjectArrayCollection { 1, 2, 3, 4, 5 };
            string test = "";
            foreach(var obj in objArray)
            {
                test += (int)obj;
            }
            Assert.Equal("12345", test);
        }

        [Fact]
        public void ForeachWorksWithStringObjectArray()
        {
            var objArray = new ObjectArrayCollection { "cat", " ", "mouse" };
            string test = "";
            foreach (var obj in objArray)
            {
                test += (string)obj;
            }
            Assert.Equal("cat mouse", test);
        }

        [Fact]
        public void ForeachWorksWithBoolObjectArray()
        {
            var objArray = new ObjectArrayCollection { false, false, true };
            string test = "";
            foreach (var obj in objArray)
            {
                test += obj.ToString();
            }
            Assert.True(string.Equals("falsefalsetrue", test, System.StringComparison.CurrentCultureIgnoreCase));
        }

        [Fact]
        public void ForeachWorksWithCharObjectArray()
        {
            var objArray = new ObjectArrayCollection { 'a', '*', 'd' };
            string test = "";
            foreach (var obj in objArray)
            {
                test += obj.ToString();
            }
            Assert.Equal("a*d", test);
        }
    }
}