using Xunit;

namespace Json.Tests
{
    public class SequenceTests
    {
        [Theory]
        [InlineData("ax")]
        [InlineData("def")]
        [InlineData("")]
        [InlineData(null)]
        public void CharactersAreMatchedInSequence(string text)
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            Assert.False(ab.Match(text).Success());
        }

        [Fact]
        public void OnMatchFailureWholeTextIsReturned()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            Assert.Equal("ax", ab.Match("ax").RemainingText());
        }

        [Fact]
        public void CharactersAreMatchInSequenceArray()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
                );

            Assert.Equal("d", abc.Match("abcd").RemainingText());
        }

        [Fact]
        public void CharactersAreMatchedInHexSequence()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            Assert.True(hexSeq.Match("u1234").Success());
            Assert.Equal("ef", hexSeq.Match("uabcdef").RemainingText());
            Assert.Equal(" ab", hexSeq.Match("uB005 ab").RemainingText());
            Assert.False(hexSeq.Match("abc").Success());
        }
    }
}
