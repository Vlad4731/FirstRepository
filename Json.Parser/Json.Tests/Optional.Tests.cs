using Xunit;

namespace Json.Tests
{
    public class OptionalTests
    {

        [Fact]
        public void VoidAndNullAreMatched()
        {
            var x = new Optional(new Character('x'));
            Assert.Empty(x.Match("").RemainingText());
            Assert.Null(x.Match(null).RemainingText());
        }

        [Fact]
        public void PatternIsMatched()
        {
            var a = new Optional(new Character('a'));
            Assert.Equal("bc", a.Match("abc").RemainingText());
            Assert.Equal("abc", a.Match("aabc").RemainingText());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }
    }
}
