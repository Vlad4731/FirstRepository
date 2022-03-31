using Xunit;

namespace Json.Tests
{
    public class RangeFacts
    {
        [Theory]
        [InlineData("abc")]
        [InlineData("fab")]
        [InlineData("bcd")]
        public void TextIsInRange(string text)
        {
            Range interval = new Range('a', 'f');
            Assert.True(interval.Match(text).Success());
        }


        [Theory]
        [InlineData("1ab")]
        [InlineData("*ab")]
        [InlineData("\nbd")]
        public void TextIsOutsideRange(string text)
        {
            Range interval = new Range('a', 'f');
            Assert.False(interval.Match(text).Success());
        }
    }
}
