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

        [Fact]
        public void EncryptDecryptCommands_ReturnTruthValue()
        {
            Assert.True(Encrypt("encrypt=P@ssvv0rd"));
            Assert.True(Decrypt("decrypt=P@ssvv0rd"));
            Assert.False(Decrypt("password=P@ssvv0rd"));
        }

        [Fact]
        public void ReturnPassword_ReturnsPasswordOrError()
        {
            Assert.Equal("P@ssvv0rd", ReturnPassword("encrypt=P@ssvv0rd", Encrypt));
        }
    }
}
