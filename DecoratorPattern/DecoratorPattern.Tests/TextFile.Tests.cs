using System.IO;
using Xunit;
using static DecoratorPattern.Program;

namespace DecoratorPattern.Tests
{
    public class TextFileTests
    {
        [Fact]
        public void TextFile_IsRead_ReturnsText()
        {
            Assert.Equal("Gazpacho",
                ReadFromFile());
        }

        [Fact]
        public void TextFile_IsWritten_ReturnsNewText()
        {
            WriteToFile("Sombrero");
            Assert.Equal("Sombrero", ReadFromFile());
        }
    }
}
