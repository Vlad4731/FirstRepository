using System;
using System.IO;

namespace DecoratorPattern
{
    internal class EncryptDecorator : TextFileDecorator
    {
        public EncryptDecorator(ITextFile textFile) : base(textFile)
        {
        }

        public override void WriteToFile()
        {
            base.WriteToFile();
            File.Encrypt(Adress);
        }
    }
}
