using Xunit;

namespace Json.Tests
{
    public class OneOrMoreTests
    {

        [Fact]
        public void NullAndEmptyAreNotMatched()
        {
            var a = new OneOrMore(new Character('a'));
            Assert.False(a.Match("").Success());
            Assert.Empty(a.Match("").RemainingText());
            Assert.False(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void PatternIsMatched()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.Empty(a.Match("123").RemainingText());
            Assert.Equal("a", a.Match("1a").RemainingText());
            Assert.False(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }
    }
}
