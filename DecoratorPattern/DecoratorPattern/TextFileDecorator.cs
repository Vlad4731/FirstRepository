using System;

namespace DecoratorPattern
{
    internal class TextFileDecorator
    {
        private readonly TextFile textFile;

        public TextFileDecorator(TextFile textFile)
        {
            this.textFile = textFile;
        }

        public string Adress { get => textFile.Adress; }

        public virtual void WriteToFile() => textFile.WriteToFile();

        public string ReadFromFile() => textFile.ReadFromFile();
    }
}
