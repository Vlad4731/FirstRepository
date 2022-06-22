using System;
using Xunit;
using static DecoratorPattern.Program;

namespace DecoratorPattern.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void ReadAndWriteCommands_AreValidated()
        {
            Assert.True(Read("read"));
            Assert.True(Write("write"));
            Assert.False(Read("append"));
            Assert.False(Write("append"));
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
            Assert.Throws<ArgumentException>(() => ReturnPassword("password=P@ssvv0rd", Encrypt));
        }
    }
}
