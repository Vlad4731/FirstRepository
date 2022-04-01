using Xunit;

namespace Json.Tests
{
    public class ListTests
    {

        [Fact]
        public void VoidAndNullAreMatched()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }

    }
}
