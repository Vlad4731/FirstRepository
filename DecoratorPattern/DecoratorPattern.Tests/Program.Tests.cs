using System;
using System.IO;
using Xunit;

namespace DecoratorPattern.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void TextFile_IsRead_ReturnsText()
        {
            Assert.Equal("Gazpacho",
                File.ReadAllText(@"C:\Users\Vlad\Documents\GitHub\FirstRepository\DecoratorPattern\DecoratorPattern\bin\Debug\netcoreapp3.1\test.txt"));
        }
    }
}
