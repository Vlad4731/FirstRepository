using Xunit;

namespace Json.Tests
{
    public class StringTests
    {
        [Fact]
        public void VoidOrEmptyAreNotMatched()
        {
            String test = new String();
            Assert.False(test.Match("").Success());
            Assert.False(test.Match(null).Success());
        }

        [Theory]
        [InlineData("a")]
        [InlineData("abc")]
        [InlineData("ABC")]
        [InlineData("1ABC2")]
        public void NormalTextIsMatched(string text)
        {
            String test = new String();
            Assert.True(test.Match(Quoted(text)).Success());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
