using Xunit;

namespace Json.Tests
{
    public class NumberTests
    {
        readonly Number test = new Number();

        [Fact]
        public void VoidOrEmptyAreNotMatched()
        {
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
        public void CanBeZero()
        {
            Assert.True(test.Match("0").Success());
        }

        [Fact]
        public void DoesNotContainLetters()
        {
            Assert.False(test.Match("a").Success());
        }

        [Fact]
        public void CanHaveASingleDigit()
        {
            Assert.True(test.Match("7").Success());
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            Assert.True(test.Match("70").Success());
        }

        [Fact]
        public void IsNotNull()
        {
            Assert.False(test.Match(null).Success());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Assert.False(test.Match(string.Empty).Success());
        }

    }
}
