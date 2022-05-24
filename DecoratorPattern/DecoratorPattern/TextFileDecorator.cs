using System;

namespace DecoratorPattern
{
    public class TextFileDecorator : ITextFile
    {
        private readonly ITextFile textFile;

        public TextFileDecorator(ITextFile textFile)
        {
            this.textFile = textFile;
        }

        public string Adress { get => textFile.Adress; }

        public virtual void WriteToFile() => textFile.WriteToFile();

        public string ReadFromFile() => textFile.ReadFromFile();
    }
}
