using Xunit;

namespace Json.Tests
{
    public class TextTests
    {

        [Fact]
        public void NullImputIsNotMatched()
        {
            var test = new Text("test");
            Assert.False(test.Match(null).Success());
            Assert.Null(test.Match(null).RemainingText());
        }

        [Fact]
        public void ImputIsCorrectlyMatched()
        {
            var trueText = new Text("true");
            Assert.Empty(trueText.Match("true").RemainingText());
            Assert.Equal("x", trueText.Match("truex").RemainingText());
            Assert.Equal("false", trueText.Match("false").RemainingText());
        }

        [Fact]
        public void EmptyImputIsMatched()
        {
            var empty = new Text("");
            Assert.True(empty.Match("true").Success());
            Assert.Equal("true", empty.Match("true").RemainingText());
        }
    }
}
