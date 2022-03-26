using Xunit;

namespace Json.Tests
{
    public class MatchFacts
    {
        [Fact]
        public void MatchIsSuccessful()
        {
            Match test = new Match("text");
            Assert.True(test.Success());
        }

        [Fact]
        public void ReminingTextIsReturned()
        {
            Match test = new Match("text");
            Assert.Equal("text", test.RemainingText());
        }
    }
}
