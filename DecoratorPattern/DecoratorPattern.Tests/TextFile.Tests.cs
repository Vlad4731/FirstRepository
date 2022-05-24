using System.IO;
using Xunit;
using static DecoratorPattern.Program;

namespace DecoratorPattern.Tests
{
    public class TextFileTests
    {
        TextFile textFile = new TextFile(Adress);

        [Fact]
        public void TextFile_IsRead_ReturnsText()
        {
            Assert.Equal("Gazpacho",
                textFile.ReadFromFile());
        }

        [Fact]
        public void TextFile_IsWritten_ReturnsNewText()
        {
            textFile.WriteToFile();
            Assert.Equal("Sombrero", textFile.ReadFromFile());
        }
    }
}
