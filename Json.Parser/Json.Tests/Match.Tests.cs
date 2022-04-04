using Xunit;

namespace Json.Tests
{
    public class MatchFacts
    {
        [Fact]
        public void MatchIsSuccessful()
        {
            SuccessMatch test = new SuccessMatch("text");
            Assert.True(test.Success());
        }

        [Fact]
        public void RemainingTextIsReturned()
        {
            SuccessMatch test = new SuccessMatch("text");
            Assert.Equal("text", test.RemainingText());
        }
    }
}
