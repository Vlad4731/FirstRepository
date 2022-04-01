using Xunit;

namespace Json.Tests
{
    public class ManyTests
    {

        [Fact]
        public void CharacterPatternIsMatched()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("bc", a.Match("abc").RemainingText());
            Assert.Equal("bc", a.Match("aaaaabc").RemainingText());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void DigitPatternIsMatched()
        {
            var a = new Many(new Range('0', '9'));
            Assert.Equal("ab123", a.Match("12345ab123").RemainingText());
            Assert.Equal("ab", a.Match("ab").RemainingText());
        }

        [Fact]
        public void NullAndEmptyAreMatched()
        {
            var a = new Many(new Character('a'));
            Assert.Empty(a.Match("").RemainingText());
            Assert.Null(a.Match(null).RemainingText());
        }
    }
}
