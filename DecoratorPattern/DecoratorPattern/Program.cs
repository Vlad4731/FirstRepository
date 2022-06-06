using System;
using System.IO;
using System.Text;

namespace DecoratorPattern
{
    public class Program
    {
        public static string Adress { get; set; } = @"C:\Users\Vlad\Documents\GitHub\FirstRepository\DecoratorPattern\DecoratorPattern\bin\Debug\netcoreapp3.1\test.txt";

        public static FileStream ReadFromFile(FileStream fileStream)
        {
            StreamReader readStream = new StreamReader(fileStream);
            readStream.ReadToEnd();
            readStream.Close();
            fileStream = File.Open(Adress, FileMode.Open);
            return fileStream;
        }

        public static FileStream WriteToFile(FileStream fileStream)
        {
            StreamWriter writeStream = new StreamWriter(fileStream);
            writeStream.WriteLine("This is a test.");
            writeStream.Close();
            fileStream = File.Open(Adress, FileMode.Open);
            return fileStream;
        }

        static void Main()
        {
            using FileStream fileStream = File.Open(Adress, FileMode.Open);
        }
    }
}
