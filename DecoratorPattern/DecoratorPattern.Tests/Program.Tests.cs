using System.IO;
using Xunit;
using static DecoratorPattern.Program;

namespace DecoratorPattern.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void ReadAndWriteCommands_AreValidated()
        {
            Assert.True(CheckReadWriteCommand("read"));
            Assert.True(CheckReadWriteCommand("write"));
            Assert.False(CheckReadWriteCommand("append"));
        }
    }
}
