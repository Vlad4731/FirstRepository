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
        public void ForeachWorksWithIntegerObjectArray()
        {
            var objArray = new ObjectArray { 1, 2, 3, 4, 5 };
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
            var objArray = new ObjectArray { "cat", " ", "mouse" };
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
            var objArray = new ObjectArray { false, false, true };
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
            var objArray = new ObjectArray { 'a', '*', 'd' };
            string test = "";
            foreach (var obj in objArray)
            {
                test += obj.ToString();
            }
            Assert.Equal("a*d", test);
        }
    }
}