using Xunit;

namespace Json.Tests
{
    public class NumberTests
    {
        [Fact]
        public void VoidOrEmptyAreNotMatched()
        {
            Number test = new Number();
            Assert.False(test.Match("").Success());
            Assert.False(test.Match(null).Success());
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("0")]
        [InlineData("-4312")]
        [InlineData("1000002")]
        public void IntegerNumbersAreMatched(string text)
        {
            Number test = new Number();
            Assert.True(test.Match(text).Success());
        }

        [Theory]
        [InlineData("1234.56")]
        [InlineData("0.123")]
        [InlineData("-12.30000")]
        [InlineData("1.001")]
        public void FractionalNumbersAreMatched(string text)
        {
            Number test = new Number();
            Assert.True(test.Match(text).Success());
        }

        [Theory]
        [InlineData("1234e4")]
        [InlineData("0.123E013")]
        [InlineData("-12.30000e-12")]
        [InlineData("1.0E0001")]
        public void ExponentialNumbersAreMatched(string text)
        {
            Number test = new Number();
            Assert.True(test.Match(text).Success());
        }

        [Fact]
        public void DoesNotContainLettersOrSymbols()
        {
            Number test = new Number();
            Assert.False(test.Match("abc").Success());
            Assert.False(test.Match("*/").Success());
        }

        [Fact]
        public void ObviousWrongNumberIsNotMatched()
        {
            Number test = new Number();
            Assert.False(test.Match("001.123.E++124").Success());
            Assert.Equal("001.123.E++124", test.Match("001.123.E++124").RemainingText());
        }
    }
}
