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
        public void ObviousWrongNumberIsNotMatched()
        {
            Number test = new Number();
            Assert.False(test.Match("001.123.E++124").Success());
            Assert.Equal("001.123.E++124", test.Match("001.123.E++124").RemainingText());
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

        [Fact]
        public void DoesNotStartWithZero()
        {
            Assert.False(test.Match("07").Success());
        }

        [Fact]
        public void CanBeNegative()
        {
            Assert.True(test.Match("-26").Success());
        }

        [Fact]
        public void CanBeMinusZero()
        {
            Assert.True(test.Match("-0").Success());
        }

        [Fact]
        public void CanBeFractional()
        {
            Assert.True(test.Match("12.34").Success());
        }

        [Fact]
        public void TheFractionCanHaveLeadingZeros()
        {
            Assert.True(test.Match("0.00000001").Success());
            Assert.True(test.Match("10.00000001").Success());
        }

        [Fact]
        public void DoesNotEndWithADot()
        {
            Assert.Equal(".", test.Match("12.").RemainingText());
            Assert.False(test.Match("12.").Success());
        }

        [Fact]
        public void DoesNotHaveTwoFractionParts()
        {
            Assert.False(test.Match("12.34.56").Success());
        }

        [Fact]
        public void TheDecimalPartDoesNotAllowLetters()
        {
            Assert.False(test.Match("12.3x").Success());
        }

        [Fact]
        public void CanHaveAnExponent()
        {
            Assert.True(test.Match("12e3").Success());
        }

        [Fact]
        public void TheExponentCanStartWithCapitalE()
        {
            Assert.True(test.Match("12E3").Success());
        }

        [Fact]
        public void TheExponentCanHavePositive()
        {
            Assert.True(test.Match("12e+3").Success());
        }

        [Fact]
        public void TheExponentCanBeNegative()
        {
            Assert.True(test.Match("61e-9").Success());
        }

        [Fact]
        public void CanHaveFractionAndExponent()
        {
            Assert.True(test.Match("12.34E3").Success());
        }

        [Fact]
        public void TheExponentDoesNotAllowLetters()
        {
            Assert.False(test.Match("22e3x3").Success());
        }

        [Fact]
        public void DoesNotHaveTwoExponents()
        {
            Assert.False(test.Match("22e323e33").Success());
        }

        [Fact]
        public void TheExponentIsAlwaysComplete()
        {
            Assert.False(test.Match("22e").Success());
            Assert.False(test.Match("22e+").Success());
            Assert.False(test.Match("23E-").Success());
        }

        [Fact]
        public void TheExponentIsAfterTheFraction()
        {
            Assert.False(test.Match("22e3.3").Success());
        }
    }
}
