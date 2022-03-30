using Xunit;

namespace Json.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void MatchIsSuccessful()
        {
            Character test = new Character('c');
            Assert.True(test.Match("char").Success());
        }

        [Fact]
        public void RemainingTextIsReturnedCorrectly()
        {
            Character test = new Character('c');
            Assert.Equal("har", test.Match("char").RemainingText());
        }

    }
}
