using Xunit;

namespace Json.Tests
{
    public class StringTests
    {
        String test = new String();

        [Fact]
        public void VoidOrEmptyAreNotMatched()
        {
            Assert.False(test.Match("").Success());
            Assert.False(test.Match(null).Success());
        }

        [Theory]
        [InlineData("a")]
        [InlineData("abc")]
        [InlineData("ABC")]
        [InlineData("1ABC2")]
        [InlineData("EEEE!! Macarenaa!")]
        public void NormalTextIsMatched(string text)
        {
            Assert.True(test.Match(Quoted(text)).Success());
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            Assert.False(test.Match("abc\"").Success());
        }

        [Fact]
        public void DoesNotContainControlCharacters()
        {
            Assert.False(test.Match(Quoted("a\nb\rc")).Success());
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            Assert.True(test.Match(Quoted(@"\""a\"" b")).Success());
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            Assert.True(test.Match(Quoted(@"a \\ b")).Success());
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            Assert.True(test.Match(Quoted(@"a \/ b")).Success());
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            Assert.True(test.Match(Quoted(@"a \b b")).Success());
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            Assert.True(test.Match(Quoted(@"a \f b")).Success());
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            Assert.True(test.Match(Quoted(@"a \n b")).Success());
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            Assert.True(test.Match(Quoted(@"a \r b")).Success());
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            Assert.True(test.Match(Quoted(@"a \t b")).Success());
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            Assert.True(test.Match(Quoted(@"a \u26Be b")).Success());
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            Assert.False(test.Match(Quoted(@"a\x")).Success());
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            Assert.False(test.Match(Quoted(@"a\")).Success());
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            Assert.False(test.Match(Quoted(@"a\u")).Success());
            Assert.False(test.Match(Quoted(@"a\u123")).Success());
        }

        [Fact]
        public void JsonHexNumberIsValid()
        {
            Assert.True(test.Match(Quoted(@"abc \u002f")).Success());
            Assert.False(test.Match(Quoted(@"abc \u00j2")).Success());
        }

        [Fact]
        public void ValidateMostHorrificJSONString()
        {
            Assert.True(test.Match(Quoted(@"abc \\\/ \u476872  /")).Success());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
