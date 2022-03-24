using Xunit;
using static Json.Range;

namespace Json.Tests
{
    public class ChoiceFacts
    {
        [Theory]
        [InlineData("012")]
        [InlineData("12")]
        [InlineData("92")]
        public void DigitsAreMatched(string text)
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            Assert.True(digit.Match(text));
        }

        [Theory]
        [InlineData("A")]
        [InlineData("abc")]
        [InlineData("ABC")]
        public void CharactersAreMatched(string text)
        {
            var character = new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            Assert.True(character.Match(text));
        }

        [Theory]
        [InlineData("012")]
        [InlineData("12")]
        [InlineData("92")]
        [InlineData("a9")]
        [InlineData("f8")]
        [InlineData("A9")]
        public void HexIsMatched(string text)
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
            );

            Assert.True(hex.Match(text));
        }

        [Theory]
        [InlineData("g8")]
        [InlineData("G8")]
        [InlineData("")]
        [InlineData(null)]
        public void NonHexInputIsRejected(string text)
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
            );

            Assert.False(hex.Match(text));
        }
    }
}
