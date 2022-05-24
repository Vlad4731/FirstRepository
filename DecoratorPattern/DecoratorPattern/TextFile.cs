using System;
using System.IO;

namespace DecoratorPattern
{
    public class TextFile : ITextFile
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

        public void WriteToFile()
        {
            File.WriteAllText(Adress, Console.ReadLine());
        }
    }
}