using System.IO;
using Xunit;
using static DecoratorPattern.Program;

namespace DecoratorPattern.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void TextFile_IsRead_ReturnsText()
        {
            Assert.Equal("Gazpacho",
                File.ReadAllText(Adress));
        }

        [Fact]
        public void TextFile_IsWritten_ReturnsText()
        {
            File.WriteAllText(Adress, "Sombrero");
            Assert.Equal("Sombrero", File.ReadAllText(Adress));
        }
    }
}
