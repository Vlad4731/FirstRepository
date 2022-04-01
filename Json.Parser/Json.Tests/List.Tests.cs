using Xunit;

namespace Json.Tests
{
    public class ListTests
    {

        [Fact]
        public void VoidAndNullAreMatched()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void ListIsMatchedCorrectly()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("", a.Match("1,2,3").RemainingText());
            Assert.Equal(",", a.Match("1,2,3,").RemainingText());
            Assert.Equal("a", a.Match("1a").RemainingText());
            Assert.Equal("abc", a.Match("abc").RemainingText());
        }

    }
}
