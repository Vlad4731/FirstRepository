using Xunit;

namespace Json.Tests
{
    public class ValueTests
    {
        readonly Value test = new Value();

        [Fact]
        public void VoidArrayIsNotMatched()
        {
            Assert.False(test.Match(null).Success());
        }

        [Fact]
        public void EmptyArrayIsMatched()
        {
            Assert.True(test.Match("[ ]").Success());
        }

        [Fact]
        public void ArrayIsMatched()
        {
            string text = "[1, 23, 456, 7890]";
            Assert.True(test.Match(text).Success());
            Assert.Equal("", test.Match(text).RemainingText());
        }

        [Fact]
        public void StringIsMatched()
        {
            string text = "absulte 123 *\u0043";

            Assert.True(test.Match(Quoted(text)).Success());
        }

        [Fact]
        public void ElementsAreMatched()
        {
            string text = "{ \"test\" : 14}";

            Assert.True(test.Match(text).Success());
        }

        [Fact]
        public void NumbersAreMatched()
        {
            string text = "14";

            Assert.True(test.Match(text).Success());
        }

        [Fact]
        public void BoolValuesAreMatched()
        {
            string text = "false";

            Assert.True(test.Match(text).Success());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";

    }
}
