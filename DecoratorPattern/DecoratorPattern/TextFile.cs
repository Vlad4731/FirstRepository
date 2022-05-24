using System;
using System.IO;

namespace DecoratorPattern
{
    public class TextFile
    {
        public TextFile(string adress)
        {
            Adress = adress;
        }

        public string Adress { get; }

        public string ReadFromFile()
        {
            return File.ReadAllText(Adress);
        }

        public void WriteToFile(string text)
        {
            File.WriteAllText(Adress, text);
        }
    }
}