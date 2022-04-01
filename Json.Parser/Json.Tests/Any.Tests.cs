using Xunit;

namespace Json.Tests
{
    public class AnyTests
    {

        [Fact]
        public void VoidAndNullAreNotMatched()
        {
            var e = new Any("eE");
            Assert.Equal("", e.Match("").RemainingText());
            Assert.Null(e.Match(null).RemainingText());
        }

        [Fact]
        public void CharactersAreMatchedCorrectly()
        {
            var e = new Any("eE");
            Assert.Equal("a", e.Match("ea").RemainingText());
            Assert.Equal("a", e.Match("Ea").RemainingText());
            Assert.Equal("a", e.Match("a").RemainingText());
        }

        [Fact]
        public void SymbolsAreMatched()
        {
            var sign = new Any("-+");
            Assert.Equal("3", sign.Match("+3").RemainingText());
            Assert.Equal("2", sign.Match("-2").RemainingText());
            Assert.Equal("2", sign.Match("2").RemainingText());
        }
    }
}
